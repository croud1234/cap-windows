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
            this.FormBorderStyle = FormBorderStyle.None;
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

               
            
            // 枠を選択して、今からスタートするというショートカットキー、終了させるためのショートカットキーがいる
            // これで任意の時刻でキャプチャーがとれるようになる
            // 画面全体にもしたい

            //　フォームを消して見る

            this.Hide();

            // 画像キャプチャー処理
            // スクリーン・キャプチャする範囲を決定
     
            // Bitmapオブジェクトにスクリーン・キャプチャ

            Rectangle rc = Screen.PrimaryScreen.Bounds;

            rc.Location = new Point(this.start_x, this.start_y);
            rc.Width = this.end_x - this.start_x;
            rc.Height = this.end_y - this.start_y;

            this.label4.Text = rc.Location.X + ": " + rc.Location.Y +"\n"+rc.Width + " : " + rc.Height;

            Bitmap bmp = new Bitmap(rc.Width, rc.Height,PixelFormat.Format32bppArgb);

            
            for (int i = 0; i < 5; i++)
            {
                //マウスポイントを取得
                this.Cursor = new Cursor(Cursor.Current.Handle);
                Point curPoint = Cursor.Position;

                this.label4.Text = curPoint.X +":"+curPoint.Y;
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.CopyFromScreen(this.start_x, this.start_y, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);
                    //マウスカーソルを書き込む
                    this.Cursor.Draw(g, new Rectangle(curPoint, this.Cursor.Size));
                }
               

                string filePath = @"C:\tmp\test"+ i +".gif";

                bmp.Save(filePath, ImageFormat.Gif);
                Thread.Sleep(500);
               
            
            }

            List<string> files = new List<string>( Directory.GetFiles( @"c:\tmp\", "test*.gif") );
            GifCreator.GifCreator.CreateAnimatedGif(files, 70, @"c:\tmp\out.gif");
           
            this.Close();
            //this.Show();
            
        }

        private void KeyPressTest(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar) && e.KeyChar != ((char)Keys.A | (char)Keys.ControlKey))

            {
                MessageBox.Show("Pressed " + Keys.Control);
            }
            
            /*
            Debug.WriteLine(e.KeyChar == (char)Keys.A);
            Debug.WriteLine(e.KeyChar == Keys.Control);

            if ((Control.ModifierKeys & Keys.Control) == Keys.Control && e.KeyChar == (char)Keys.A)
            {
                Console.WriteLine("Ctrlキーとaが押されています。");
            }

           if(Control.ModifierKeys == Keys.Shift){
               Debug.WriteLine("おしたよ");
           }
             */

            /*
            if (e.KeyCode == Keys.F1)
                Console.WriteLine("F1キーが押されました。");
             */
        }
    }
}
