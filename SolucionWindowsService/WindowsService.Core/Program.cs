using System.ServiceProcess;

namespace WindowsService.Core
{
    static class Program
    {
        static void Main()
        {
            Scheduler service = new Scheduler();
            ServiceBase.Run(service);
        }
    }
}
