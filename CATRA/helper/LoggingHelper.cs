using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CATRA.helper
{
    static class LoggingHelper
    {
        public static String getTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssffff");
        }

        public static String logify(String logString) {
            String timestamp = getTimestamp(DateTime.Now);
            String output = "[" + timestamp + "]\n" + logString+"\n";
            return output;
        
        }


    }
}
