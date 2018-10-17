using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace program2
{
    public partial class Form1 : Form
    {
        static int leftangle = 30, rightangle = 20;
        static double per1 = 0.6;
        static double per2 = 0.6;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try { leftangle = Convert.ToInt32(this.textBox1.Text); }
            catch { };
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try { rightangle = Convert.ToInt32(this.textBox2.Text); }
            catch { };
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try { per1 = Convert.ToDouble(this.textBox3.Text); }
            catch { };
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try { per2 = Convert.ToDouble(this.textBox4.Text); }
            catch { };
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
        private Graphics graphics;
       
        

        void drawCayleyTree(int n, double x0, double y0, double leng, double th)
        {
            if (n == 0) return;
            double x1 = x0 + leng * Math.Cos(th);
            double x2 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
            double y2 = y0 + 0.5 * leng * Math.Sin(th);
            drawLine(x0, y0, x1, y1);
            double th1 = leftangle * Math.PI / 180;
            double th2 = rightangle * Math.PI / 180;
            drawCayleyTree(n - 1, x2, y2, per1 * leng, th + th1);
            drawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2);
        }
        void drawLine(double x0, double y0, double x1, double y1)
        {
            graphics.DrawLine(
                Pens.Blue, (int)x0, (int)y0, (int)x1, (int)y1);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (graphics == null) graphics = this.CreateGraphics();
            drawCayleyTree(10, 400, 310, 100, -Math.PI / 2);
        }     
        public Form1()
        {
            InitializeComponent();
        }
   
    }
}
