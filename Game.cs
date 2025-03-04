using Force.Crc32;
using System.Text;
using System.Text.Json.Serialization;

namespace GameLauncher
{
    public class Game
    {
        public uint Id { get;  set; }
        public string Name { get;  set; }
        public string LauncherExecutable { get;  set; }
        public string GameExecutable { get;  set; }
        public string ProcessName { get;  set; }
        public string LogoPath { get; set; }
        public string HeroPath { get; set; }
        public string GridPath { get; set; }

        [JsonConstructor]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        internal Game() {
        }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public Game(string name, string launcherExecutable, string gameExecutable, string processName, string heroPath, string gridPath, string logoPath)
            : this(GenerateAppId(name), name, launcherExecutable, gameExecutable, processName, heroPath, gridPath, logoPath)
        {
        }

        public Game(UInt32 id, string name, string launcherExecutable, string gameExecutable, string processName, string heroPath, string gridPath, string logoPath)
        {
            Id = id;
            Name = name;
            LauncherExecutable = launcherExecutable;
            GameExecutable = gameExecutable;
            ProcessName = processName;
            HeroPath = heroPath;
            GridPath = gridPath;
            LogoPath = logoPath;
        }


        private static UInt32 GenerateAppId(string appName)
        {
            string target = Program.GetExecutablePath();

            UInt32 checksum = Crc32Algorithm.Compute(Encoding.UTF8.GetBytes(target + appName));
            UInt32 steamId = checksum | 0x80000000;

            return steamId;
        }
    }
}
