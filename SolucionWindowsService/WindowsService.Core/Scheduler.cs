using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using WindowsService.Library;

namespace WindowsService.Core
{
    public partial class Scheduler : ServiceBase
    {

        private Timer timer = null;

        public Scheduler()
        {
            InitializeComponent();

            UtilsDatabase.SetupDatabase();
        }

        protected override void OnStart(string[] args)
        {
            timer = new Timer();
            timer.Interval = Constants.ServiceSetup.Interval;
            timer.Enabled = true;
            timer.Elapsed += new ElapsedEventHandler(TimerTick);
        }

        protected override void OnStop()
        {
            timer.Enabled = false;
            UtilsFile.WriteErrorLog("======== The service was stopped ========");
        }

        private void TimerTick(object sender, EventArgs e)
        {
            string message = UtilsDatabase.GetRandomMessage();
            UtilsFile.WriteErrorLog(String.Format("{0} => {1}", "Timer ticked successfully", message));
        }

    }
}
