using System;
using System.Configuration;
using System.Diagnostics;

namespace NodeWorker
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                var start = new ProcessStartInfo
                {
                    Arguments = "app/index.js",
                    FileName = "node.exe",
                    UseShellExecute = false
                };

                // Copy all the appSettings into environment variables. This allows them to be accessed from process.env in your node code.
                foreach (var setting in ConfigurationManager.AppSettings.AllKeys)
                {
                    start.EnvironmentVariables.Add(setting, ConfigurationManager.AppSettings[setting]);
                }

                using (var process = Process.Start(start))
                {
                    process.WaitForExit();
                    Environment.Exit(process.ExitCode); // Pass through the exit code on a successful run. This puts node in control of worker lifetime.
                }
            }
            catch (Exception e)
            {
                // Something has gone wrong.
                // By exiting with a zero code here the process will not be run again until the app is deployed again
                // In production you may want it to continue running after errors, so exit with a non-zero code
                Environment.Exit(0);
            }
        }
    }
}