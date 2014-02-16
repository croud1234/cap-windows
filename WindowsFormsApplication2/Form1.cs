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
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;


namespace WindowsFormsApplication2
{
    

    public partial class Form1 : Form
    {
        int start_x;
        int start_y;

        int end_x;
        int end_y;
        Bitmap bmp;

        public Form1()
        {
            this.TopMost = true;
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
          
            InitializeComponent();
      
            Debug.WriteLine(this.AllowTransparency + "透明");
            Debug.WriteLine(this.TransparencyKey+"透明");
            Debug.WriteLine(this.BackColor + "透明");
            //this.BackColor = Color.Transparent; // 透明にはならない。白っぽい画面
           //this.TransparencyKey = this.BackColor; // これで全体が透明になる。
       
            //this.WindowState = FormWindowState.Maximized;
            //this.FormBorderStyle = FormBorderStyle.None;
           // this.BackColor = Color.Black;
          //  this.BackColor = Color.Transparent;
            //this.BackColor = this.TransparencyKey; // 透明
            //this.TransparencyKey = this.BackColor;
          // this.BackColor = Color.FromArgb(100, 255, 255, 255); // 半透明
            this.DoubleBuffered = true;
            this.Paint += new PaintEventHandler(Form1_Paint);
            this.timer1 = new System.Windows.Forms.Timer();
            this.timer1.Enabled = true;
            this.timer1.Interval = 200;
           // this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // 親コントロールを描画
            this.DrawParentControl(this.Parent, e);
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
           // this.Paint += new PaintEventHandler(Form1_Paint);
           // this.Invalidate();

            //this.Opacity = 0.0;
            /*
            Form1 form2 = new Form1();
            this.AddOwnedForm(form2);  // 親 Form が form2 を所有する
            //form2.BackColor = Color.DarkGreen;
            form2.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            form2.BackColor = Color.Transparent;
            form2.TransparencyKey = this.BackColor;
            form2.Opacity = 0.0;
            form2.Show();
            */

            // 枠を選択して、今からスタートするというショートカットキー、終了させるためのショートカットキーがいる
            // これで任意の時刻でキャプチャーがとれるようになる
            // 画面全体にもしたい

            //　フォームを消して見る

          /*  this.Hide();


            this.Close();
           */
            //this.Close();//フォームの境界線をなくす
           
            //大きさを適当に変更
            //this.Location = new Point(this.start_x, this.start_y);
            //this.Size = new Size(this.end_x - this.start_x, this.end_y - this.start_y);

           // this.Bounds = new Rectangle(this.start_x, this.start_y, this.end_x, this.end_y);
            //透明を指定する
            //this.TransparencyKey = Color.Red;
            //フォームの背景色を透明色にする
           
           

            //path.AddRectangle(new Rectangle(0, 0, 100, 100));
         
            
            // Draw the path to the screen.
   
           /*
            //e.Graphics.FillRegion(brush, region);
            Graphics g = this.CreateGraphics();
            GraphicsPath myPath = new GraphicsPath();
            myPath.AddRectangle( new Rectangle( this.start_x, this.start_y, this.end_x - this.start_x, this.end_y - this.start_y) );
            // Draw the path to the screen.
            
            Pen myPen = new Pen(Color.Black, 1);
            myPen.DashStyle = DashStyle.DashDotDot;
            //this.TransparencyKey = this.BackColor;
            g.DrawPath(myPen, myPath);
            */
          //  this.label4.Text = this.BackColor;
            //SolidBrush myBrush = new SolidBrush(this.TransparencyKey);

            

          //  this.TransparencyKey = Color.Red;
            //フォームの背景色を透明色にする
         //   this.BackColor = Color.Red;

            /*
            Graphics g = this.CreateGraphics();
           
            //g.FillRectangle(myBrush, new Rectangle(0, 0, 200, 300));;
            Rectangle r =  new Rectangle(0, 0, 600, 700);
            
            //this.BackColor = Color.Transparent; // 透明

            SolidBrush s = new SolidBrush(Color.Transparent);
            
            //SolidBrush s = new SolidBrush(Color.Red);

            
         
            g.FillRectangle(s,r);
            //this.Region = new Region(r);
            
            
            
         //   myBrush.Dispose();
            g.Dispose();
          //   this.TransparencyKey = this.BackColor; // これで全体が透明になる。
       
            */
           // Region r = new Region(this.ClientRectangle);
        //    this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            //this.BackColor =this.TransparencyKey; // 透明
     //       this.TransparencyKey = this.BackColor;
            //this.BackColor = Color.FromArgb(100, 255, 255, 255); // 半透明
          //  this.Invalidate();  // 再描画を促す
        }
        private void ScreenShot()
        {
            // 画像キャプチャー処理
            // スクリーン・キャプチャする範囲を決定

            // Bitmapオブジェクトにスクリーン・キャプチャ

            Rectangle rc = Screen.PrimaryScreen.Bounds;

            rc.Location = new Point(this.start_x, this.start_y);
            rc.Width = this.end_x - this.start_x;
            rc.Height = this.end_y - this.start_y;

            this.label4.Text = rc.Location.X + ": " + rc.Location.Y + "\n" + rc.Width + " : " + rc.Height;

            Bitmap bmp = new Bitmap(rc.Width, rc.Height, PixelFormat.Format32bppArgb);

            int i = 0;
            for (; ; )
            {
                //マウスポイントを取得
                this.Cursor = new Cursor(Cursor.Current.Handle);
                Point curPoint = Cursor.Position;

                this.label4.Text = curPoint.X + ":" + curPoint.Y;
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.CopyFromScreen(this.start_x, this.start_y, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);
                    //マウスカーソルを書き込む
                    this.Cursor.Draw(g, new Rectangle(curPoint, this.Cursor.Size));
                }

                bmp.Save(@"C:\tmp\test" + i + ".gif", ImageFormat.Gif);
                Thread.Sleep(500);
                i++;
            }

            List<string> files = new List<string>(Directory.GetFiles(@"c:\tmp\", "test*.gif"));
            GifCreator.GifCreator.CreateAnimatedGif(files, 70, @"c:\tmp\out.gif");
        }

        private void keyDownTest(object sender, KeyEventArgs e)
        {


            this.label4.Text = ":" + e.KeyCode;

            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.A:
                        //this.Select();
                        //this.Hide();
                        //this.ScreenShot();
                        //MessageBox.Show("おわり");
                        this.Close();
                        break;

                    case Keys.S:
                       // this.Show();
                        this.Close();
                        break;
                    case Keys.B:
                        MessageBox.Show("cntr * b 押した");
                        break;
                        
                }
            }
        }
        /*
        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs pevent)
        {  
            // 親コントロールを描画
            //this.DrawParentControl(this, pevent);
        }
         * */
        static int i = 0;
        private void DrawParentControl(Control c, PaintEventArgs pevent)
        {
         
            Debug.WriteLine(i++);
            Rectangle rc = Screen.PrimaryScreen.Bounds;
            using (this.bmp = new Bitmap(rc.Width, rc.Height))
            {
                Debug.WriteLine("a:" + i);
                using (Graphics g = Graphics.FromImage(this.bmp))
                {
                    Debug.WriteLine("b:" + i);
                    //Debug.WriteLine(this.ClientRectangle);
                    using (PaintEventArgs p = new PaintEventArgs(g, rc))
                    {
                        Debug.WriteLine("c:" + i);
                        this.InvokePaintBackground(this, p);
                        Debug.WriteLine("c1:" + i);
                        this.InvokePaint(this, p);
                        Debug.WriteLine("c2:" + i);
                    }
                    Debug.WriteLine("d:" + i);
                }


                Debug.WriteLine("e:" + i);
                //int offsetX = this.Left + (int)Math.Floor((double)(this.Bounds.Width - this.ClientRectangle.Width) / 2.0);
                //int offsetY = this.Top + (int)Math.Floor((double)(this.Bounds.Height - this.ClientRectangle.Height) / 2.0);
                //Debug.WriteLine(offsetX + ":" + offsetY);

                pevent.Graphics.DrawImage(
                    this.bmp,
                    this.ClientRectangle,
                    new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height),
                    GraphicsUnit.Pixel
                );
            }
            //string filePath = @"C:\tmp\test" + i + ".gif";
            //this.bmp.Save(filePath, ImageFormat.Gif);

           
        }
        /*
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            // 何もしない
            // base.OnPaintBackground(pevent);
        }
         */

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.TopMost = true;

        }
    }
    
 
}
