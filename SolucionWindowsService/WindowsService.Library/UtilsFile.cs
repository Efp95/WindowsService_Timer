using System;
using System.IO;

namespace WindowsService.Library
{
    public class UtilsFile
    {

        private static string GetLogFileRoute()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LogFile.txt");
        }


        public static void WriteErrorLog(string message)
        {
            try
            {
                string today = DateTime.Now.ToString();
                string content = String.Format("{0} ==> {1}", today, message);

                using (StreamWriter sw = new StreamWriter(GetLogFileRoute(), true))
                {
                    sw.WriteLine(content);
                }
            }
            catch (Exception ex)
            {
                WriteErrorLog(ex);
            }
        }

        public static void WriteErrorLog(Exception ex)
        {
            try
            {
                string today = DateTime.Now.ToString();
                string content = String.Format("{0} ==> {1}; {2}", today, ex.Source, ex.Message);

                using (StreamWriter sw = new StreamWriter(GetLogFileRoute(), true))
                {
                    sw.WriteLine(content);
                }
            }
            catch
            {
            }
        }

    }
}
