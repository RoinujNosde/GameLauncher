using System.Text.Json;


namespace GameLauncher
{
    internal class EpicGamesImporter : LibraryImporter
    {

        private readonly string epicPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\Epic\EpicGamesLauncher\Data\Manifests";

        
        public Task<List<Game>> GetGames()
        {
            return Task.Run(() =>
            {
                var games = new List<Game>();
                var files = Directory.GetFiles(epicPath);
                foreach (var file in files)
                {

                    if (Path.GetExtension(file) != ".item") continue;
                    var epicGame = JsonSerializer.Deserialize<EpicGame>(File.ReadAllText(file));
                    if (epicGame == null) continue;

                    var name = epicGame.DisplayName;
                    var gameExecutable = epicGame.InstallLocation + @"\" + epicGame.LaunchExecutable + " " + epicGame.LaunchCommand;
                    var launcherExecutable = GetEpicLauncherPath();
                    var processName = epicGame.MainWindowProcessName == "" ? epicGame.LaunchExecutable : epicGame.MainWindowProcessName;
                    var game = new Game(name, launcherExecutable, gameExecutable, processName, "", "", "");

                    games.Add(game);
                }
                return games;
            });
        }

        private string GetEpicLauncherPath()
        {
            string basePath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
            if (Environment.Is64BitOperatingSystem)
            {
                return basePath + @"\Epic Games\Launcher\Portal\Binaries\Win64\EpicGamesLauncher.exe";
            }
            else
            {
                return basePath + @"\Epic Games\Launcher\Portal\Binaries\Win32\EpicGamesLauncher.exe";
            }
        }

    }

    internal class EpicGame
    {
        public string DisplayName { get; set; } //VALORANT
        public string InstallLocation { get; set; } //"D:\\Epic Games/VALORANT"
        public string LaunchExecutable { get; set; } //"Live.exe"
        public string LaunchCommand { get; set; } //"--launch-product=valorant --launch-patchline=live --thirdparty", sometimes empty
        public string MainWindowProcessName { get; set; } //"VALORANT-Win64-Shipping.exe", sometimes empty == LaunchExecutable
    }
}
