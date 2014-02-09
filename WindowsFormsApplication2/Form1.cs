using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GifCreator;
using System.Drawing.Imaging;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        int start_x;
        int start_y;

        int end_x;
        int end_y;

        public Form1()
        {
            InitializeComponent();
            Console.WriteLine(@"Form1 start");
        }

        private void MouseMoveTest(object sender, MouseEventArgs e)
        {
            //フォーム上の座標でマウスポインタの位置を取得する
            //画面座標でマウスポインタの位置を取得する
            System.Drawing.Point sp = System.Windows.Forms.Cursor.Position;
            //画面座標をクライアント座標に変換する
            System.Drawing.Point cp = this.PointToClient(sp);
            //X座標を取得する
            int x = cp.X;
            //Y座標を取得する
            int y = cp.Y;

            this.label1.Text = x + " : " + y;
       
        }

        private void MouseDownTest(object sender, MouseEventArgs e)
        {
            System.Drawing.Point sp = System.Windows.Forms.Cursor.Position;
            System.Drawing.Point cp = this.PointToClient(sp);
            this.start_x = cp.X;
            this.start_y = cp.Y;
            
            this.label2.Text = this.start_x + " : " + start_y;
        }

        private void MouseUpTest(object sender, MouseEventArgs e)
        {
            System.Drawing.Point sp = System.Windows.Forms.Cursor.Position;
            System.Drawing.Point cp = this.PointToClient(sp);
            this.end_x = cp.X;
            this.end_y = cp.Y;

            this.label3.Text = this.end_x + " : " + end_y;

            //　フォームを消して見る

            this.Hide();

            // 画像キャプチャー処理
            // スクリーン・キャプチャする範囲を決定
            Rectangle rc;
           
            // Bitmapオブジェクトにスクリーン・キャプチャ

            int widht = this.end_y - start_y;
            int height = this.end_x - this.start_x;
            Bitmap bmp = new Bitmap(
                widht, height, PixelFormat.Format32bppArgb);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(new Point(start_x, start_y), new Point(end_x, end_y),  bmp.Size);

                // ビット・ブロック転送方式の切り替え例：
                //g.FillRectangle(Brushes.LightPink,
                //  0, 0, rc.Width, rc.Height);
                //g.CopyFromScreen(rc.X, rc.Y, 0, 0,
                //  rc.Size, CopyPixelOperation.SourceAnd);
                //g.Dispose();
            }

            // ビットマップ画像として保存して表示
            string filePath = @"C:\tmp\screen.gif";
            bmp.Save(filePath, ImageFormat.Gif);
            //Process.Start(filePath);

            //List<string> files = new List<string>(new string[] { @"c:\tmp\1.gif", @"c:\tmp\2.gif" });
            //GifCreator.GifCreator.CreateAnimatedGif(files, 5, @"c:\tmp\out.gif");

            this.Show();

            this.label4.Text = this.start_x + ":" + this.start_y + "\n" + this.end_x + ":" + this.end_y;
        }



      
    }
}
