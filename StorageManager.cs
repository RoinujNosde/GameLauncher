using System.Text.Json;
using Microsoft.Win32;
using VDFParser.Models;
using VDFParser;


namespace GameLauncher
{
    internal class StorageManager
    {

        private static readonly string appFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\GameLauncher";
        private static readonly string gamesJsonPath = Path.Combine(appFolder, "games.json");
        private static readonly JsonSerializerOptions jsonOptions = new()
        {
            WriteIndented = true,
        };

        private StorageManager() { }

        static StorageManager()
        {
            if (!Directory.Exists(appFolder))
            {
                Directory.CreateDirectory(appFolder);
            }
        }

        public static Task<List<Game>> GetGames()
        {
            return Task.Run(() =>
            {
                if (File.Exists(gamesJsonPath))
                {
                    List<Game>? games = JsonSerializer.Deserialize<List<Game>>(File.ReadAllText(gamesJsonPath));
                    games ??= [];
                    return games;
                }
                return [];
            });
        }

        public static Game? GetGame(uint id)
        {
            List<Game> games = GetGames().Result;
            foreach (var game in games)
            {
                if (game.Id == id) { return game; }
            }
            return null;
        }

        public static Task Save(Game game)
        {
            return Task.Run(() =>
            {
                string heroPath = GetGridPath() + game.Id + "_hero" + Path.GetExtension(game.HeroPath);
                string gridPath = GetGridPath() + game.Id + "p" + Path.GetExtension(game.GridPath);
                string logoPath = GetGridPath() + game.Id + "_logo" + Path.GetExtension(game.LogoPath);

                CopyImage(game.HeroPath, heroPath);
                CopyImage(game.GridPath, gridPath);
                CopyImage(game.LogoPath, logoPath);

                game.HeroPath = heroPath;
                game.GridPath = gridPath;
                game.LogoPath = logoPath;

                List<Game> games = GetGames().Result;
                games.RemoveAll(g => game.Id == g.Id);
                games.Add(game);
                Save(games);
                AddShortcut(game);
            });
        }

        private static void CopyImage(string source, string dest)
        {
            if (source.Equals(dest)) return;
            if (!File.Exists(source)) return;

            File.Copy(source, dest, true);
        }

        private static async void Save(List<Game> games)
        {
            await File.WriteAllTextAsync(gamesJsonPath, JsonSerializer.Serialize(games, options: jsonOptions));
        }

        public static async void Delete(Game game)
        {
            var games = await GetGames();
            games.RemoveAll(g => g.Id == game.Id);
            Save(games);

            var shortcuts = await GetShortcuts();
            shortcuts.RemoveAll(s => s.appid == game.Id);
            Save(shortcuts);
        }

        private static async void AddShortcut(Game game)
        {
            VDFEntry entry = new()
            {
                appid = (int)game.Id,
                AppName = game.Name,
                Exe = Program.GetExecutablePath(),
                StartDir = Path.GetDirectoryName(Program.GetExecutablePath()),
                LaunchOptions = game.Id.ToString(),
                Icon = game.GameExecutable,
                AllowOverlay = 1,
                AllowDesktopConfig = 1,
                IsHidden = 0,
                OpenVR = 0,
                ShortcutPath = "",
                Tags = [],
                Devkit = 0,
                DevkitGameID = "",
                LastPlayTime = (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds()
            };
            var entries = await GetShortcuts();
            entries.RemoveAll(e => e.appid == entry.appid); //Removing duplicates
            entries.Add(entry);
            for (int i = 0; i < entries.Count; i++)
            {
                entries[i].Index = i + 1; //updating index
            }
            Save(entries);
        }

        private static async void Save(List<VDFEntry> entries)
        {
            await File.WriteAllBytesAsync(GetShortcutsPath(), VDFSerializer.Serialize(entries.ToArray()));
        }

        private static Task<List<VDFEntry>> GetShortcuts()
        {
            return Task.Run(() =>
            {
                VDFEntry[] entriesArray;
                try
                {
                    entriesArray = VDFParser.VDFParser.Parse(GetShortcutsPath());
                }
                catch (VDFTooShortException)
                {
                    entriesArray = [];
                }
                return new List<VDFEntry>(entriesArray);
            });
        }

        private static string GetGridPath()
        {
            return GetSteamPath() + @"\userdata\" + GetActiveUser() + @"\config\grid\";

        }
        private static string GetShortcutsPath()
        {
            return GetSteamPath() + @"\userdata\" + GetActiveUser() + @"\config\shortcuts.vdf";
        }

        public static bool IsUserLoggedIn() => GetActiveUser() != 0;

        private static int? GetActiveUser()
        {
            return (int?)Registry.GetValue(@"HKEY_CURRENT_USER\Software\Valve\Steam\ActiveProcess", "ActiveUser", null);
        }

        private static string? GetSteamPath()
        {
            const string key32bit = @"HKEY_LOCAL_MACHINE\SOFTWARE\Valve\Steam";
            const string key64bit = @"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Valve\Steam";
            const string valueName = "InstallPath";

            string? path = (string?)Registry.GetValue(key32bit, valueName, null);
            if (path == null)
            {
                path = (string?)Registry.GetValue(key64bit, valueName, null);
            }
            return path;
        }

    }
}
