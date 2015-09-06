using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService.Library
{
    public class Constants
    {

        public struct ServiceSetup
        {
            public static double Interval = Double.Parse(ConfigurationManager.AppSettings["ServiceInterval"]);
        }

    }
}
