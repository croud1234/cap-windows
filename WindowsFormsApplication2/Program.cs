using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WindowsFormsApplication2
{
    static class Program
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        //private static extern int GetAsyncKeyState(long vkey);
        static extern short GetAsyncKeyState(Keys vKey);

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (GetAsyncKeyState(Keys.F) < 0 && GetAsyncKeyState(Keys.ControlKey) < 0)
            {
                Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
                // Ctrl＋Aキーが押された
                Debug.WriteLine("デバッグ・メッセージを出力");
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

        }
    }
}
