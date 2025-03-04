using System.Diagnostics;
using System.Runtime.Versioning;
using craftersmine.SteamGridDBNet;

namespace GameLauncher
{
    [SupportedOSPlatform("windows")]
    public class Program
    {

        public static readonly SteamGridDb SteamGridDb = new(""); // TODO: API key, move somewhere
        private static Game? game;
        private static Process? launcherProcess;
        private static Process? gameProcess;

        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            if (args.Length == 0)
            {
                Application.Run(new MainForm());
                return;
            }
            var gameId = uint.Parse(args[0]);
            game = StorageManager.GetGame(gameId);
            if (game == null)
            {
                MessageBox.Show("Game not found!");
                return;
            }

            StartLauncher(game.LauncherExecutable);
            Thread.Sleep(5000);
            StartGame(game.GameExecutable);
            LookForGameProcess(game.ProcessName);
        }

        public static string GetExecutablePath()
        {
            return Application.ExecutablePath;
        }

        private static void WatchProcess(int id)
        {
            var startInfo = new ProcessStartInfo("ProcessWatcher.exe");
            startInfo.Arguments = Environment.ProcessId + " " + id;
            startInfo.UseShellExecute = true;
            Process.Start(startInfo);
        }

        private static void LookForGameProcess(string processName)
        {
            Console.WriteLine("Looking for process");
            int tries = 0;
            while (gameProcess == null)
            {
                tries++;
                Process[] processes = Process.GetProcessesByName(processName);
                if (processes.Length > 0)
                {
                    gameProcess = processes[0];
                    WatchProcess(processes[0].Id);
                    Console.WriteLine("Process found!");
                    gameProcess.WaitForExit();
                    Console.WriteLine("Game exited!");
                    break;
                }
                if (tries == 60)
                {
                    var result = MessageBox.Show("Is the game still loading?", "GameLauncher", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        tries = 0;
                        continue;
                    }
                    Console.WriteLine($"Stopping after {tries} tries");
                    break;
                }
                Thread.Sleep(1000);
            }
            Thread.Sleep(2000);
            launcherProcess?.Kill();
        }

        private static void StartGame(string path)
        {
            Console.WriteLine("Starting game...");
            ProcessStartInfo info = new(path)
            {
                WorkingDirectory = Path.GetDirectoryName(path)
            };
            gameProcess = Process.Start(info);
            if (gameProcess != null)
            {
                WatchProcess(gameProcess.Id);
            }
            gameProcess?.WaitForExit();
            gameProcess = null;
        }

        private static void StartLauncher(string path)
        {
            string processName = Path.GetFileNameWithoutExtension(path);
            Process? oldProcess = Process.GetProcessesByName(processName).FirstOrDefault();
            if (oldProcess != null)
            {
                Console.WriteLine($"Killing old launcher process: {oldProcess.Id}");
                oldProcess.Kill();
            }
            Console.WriteLine("Starting Launcher...");
            launcherProcess = Process.Start(path);
            WatchProcess(launcherProcess.Id);
        }

    }
}