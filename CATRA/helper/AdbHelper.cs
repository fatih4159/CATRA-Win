using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CATRA.helper
{
    static class AdbHelper
    {

        public static String runShell(String shellCommand)
        {
            String output = "";
            Process process = new Process
            {
                StartInfo =
                {
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    FileName = "adb.exe",
                    Arguments = "shell "+shellCommand
                    }
            };
            process.Start();
            process.WaitForExit();
            if (process.HasExited)
            {
                output = process.StandardOutput.ReadToEnd();
                Trace.WriteLine(output);

            }

            return output;
        }
        public static String runAdb(String Adbcommand)
        {
            String output = "";
            Process process = new Process
            {
                StartInfo =
                {
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    FileName = "adb.exe",
                    Arguments = Adbcommand
                    }
            };
            process.Start();
            process.WaitForExit();
            if (process.HasExited)
            {
                output = process.StandardOutput.ReadToEnd();
                Trace.WriteLine(output);

            }

            return output;
        }

    }
}
