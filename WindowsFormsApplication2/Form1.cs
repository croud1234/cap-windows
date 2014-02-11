using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using GifCreator;
using System.Threading;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;


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
            this.WindowState = FormWindowState.Maximized;
        }

        
        private void MouseDownTest(object sender, MouseEventArgs e)
        {
            Point sp = Cursor.Position;
            Point cp = this.PointToClient(sp);
            this.start_x = cp.X;
            this.start_y = cp.Y;
            
            this.label2.Text = this.start_x + " : " + start_y;
        }

        private void MouseUpTest(object sender, MouseEventArgs e)
        {
            
            System.Drawing.Point sp = Cursor.Position;
            System.Drawing.Point cp = this.PointToClient(sp);
            this.end_x = cp.X;
            this.end_y = cp.Y;

            this.label3.Text = this.end_x + " : " + end_y;

            //　フォームを消して見る

            this.Hide();

            // 画像キャプチャー処理
            // スクリーン・キャプチャする範囲を決定
     
            // Bitmapオブジェクトにスクリーン・キャプチャ

            Rectangle rc = Screen.PrimaryScreen.Bounds;

            rc.Location = new Point(this.start_x, this.start_y);
            rc.Width = this.end_x - this.start_x;
            rc.Height = this.end_y - this.start_y;

            Bitmap bmp = new Bitmap(rc.Width, rc.Height,PixelFormat.Format32bppArgb);

            for (int i = 0; i < 10; i++)
            {

                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.CopyFromScreen(rc.X, rc.Y, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);
                }
                string filePath = @"C:\tmp\test"+ i +".gif";
                bmp.Save(filePath, ImageFormat.Gif);
                Thread.Sleep(1000);
            }

            List<string> files = new List<string>( Directory.GetFiles( @"c:\tmp\", "test*.gif") );
            GifCreator.GifCreator.CreateAnimatedGif(files, 70, @"c:\tmp\out.gif");
           
            this.Close();
        }
    }
}
