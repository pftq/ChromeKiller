using System;
using System.Diagnostics;
using System.Threading;

namespace ChromeKiller
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ChromeKiller started. Checking every 5 minutes.");

            while (true)
            {
                try
                {
                    Process[] chromeProcesses = Process.GetProcessesByName("chrome");

                    if (chromeProcesses.Length > 0)
                    {
                        Console.WriteLine($"[{DateTime.Now}] Found {chromeProcesses.Length} chrome process(es). Killing...");
                    }

                    foreach (Process proc in chromeProcesses)
                    {
                        try { proc.Kill(); } catch { }
                        proc.Dispose();
                    }
                }
                catch { }

                Thread.Sleep(TimeSpan.FromMinutes(5));
            }
        }
    }
}
