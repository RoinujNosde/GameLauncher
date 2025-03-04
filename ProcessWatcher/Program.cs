using System.Diagnostics;

namespace ProcessWatcher
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.Error.WriteLine("Input 2 args for the processes IDs");
                Environment.Exit(1);
                return;
            }
            try
            {
                string mainId = args[0];
                string secondaryId = args[1];

                Console.WriteLine($"Main: {mainId}, Secondary: {secondaryId}");

                var main = Process.GetProcessById(int.Parse(mainId));

                Console.WriteLine("Main process found");
                
                main.WaitForExit();
                
                Console.WriteLine("Main process exited");
                Console.WriteLine("Killing secondary...");
                
                Process.GetProcessById(int.Parse(secondaryId)).Kill();
            }
            catch (ArgumentException)
            {
                Console.WriteLine($"Process {args[0]} not found");
            }
        }
    }
}