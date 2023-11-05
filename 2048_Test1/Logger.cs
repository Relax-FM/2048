using System;
using System.IO;
using System.Windows.Forms;

namespace _2048_Test1
{
    public class Logger
    {
        static public void Error(string txt)
        {
            string date = DateTime.Now.ToString("d  HH:mm:ss:fff");
            File.AppendAllText(Application.StartupPath + @"\Logs\Errors.txt", txt + date + Environment.NewLine);
        }
        static public void Info(string txt)
        {
            string date = DateTime.Now.ToString("d  HH:mm:ss:fff");
            File.AppendAllText(Application.StartupPath + @"\Logs\Info.txt", txt + date + Environment.NewLine);
        }
    }
}