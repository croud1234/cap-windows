using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace WindowsFormsApplication2
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            
            Console.WriteLine("Main Thread Start");

            //スレッドクラスのオブジェクトを生成。
            //コンストラクタの引数として上で作成した関数をThreadStartデリゲートとして突っ込んでおく。
            Thread thr = new Thread(new ThreadStart(ThreadProcess));

            thr.Start();
        }

        //別スレッドとして実行される関数
        static void ThreadProcess()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Thread Process : {0}", i);
                //0.1秒待つ
                Thread.Sleep(100);
            }
        }
    }
}
