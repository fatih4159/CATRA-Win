using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CATRA.helper
{
    internal class MethodContainer
    {
        private static string logify(String logstring)
        {

            return LoggingHelper.logify(logstring);
        }


        public static void DoProvision(TextBox tb_log)
        {
            String output = AdbHelper.runShell("dpm set-device-owner com.agx.catra/com.agx.catra.control.AdminReceiver");
            tb_log.AppendText(logify(output));
            tb_log.ScrollToEnd();
        }
        public static void DoUnProvision(TextBox tb_log)
        {
            String output = AdbHelper.runShell("dpm remove-active-admin com.agx.catra/com.agx.catra.control.AdminReceiver");
            tb_log.AppendText(logify(output));
            output = AdbHelper.runAdb("uninstall com.agx.catra");
            tb_log.AppendText(logify(output));
            tb_log.ScrollToEnd();
        }
        public static void DoCheckAdmins(TextBox tb_log)
        {
            String output = AdbHelper.runShell("dumpsys device_policy | grep \"/\"");
            tb_log.AppendText(logify(output));
            tb_log.ScrollToEnd();
            tb_log.ScrollToEnd();
        }


    }
}
