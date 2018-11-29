using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Xml;
using System.IO; 

namespace homework7
{
    public partial class Createlist : Form
    {
        public List<OrderDetails> testList = new List<OrderDetails>();
        XmlSerializer xs = new XmlSerializer(typeof(List<OrderDetails>));
        string x, b, c, d,p,o;
        public Createlist()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try { x = this.textBox1.Text; }
            catch { };
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try { b = this.textBox2.Text; }
            catch { };
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try { c = this.textBox3.Text; }
            catch { };
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try { d = this.textBox4.Text; }
            catch { };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OrderDetails order = new OrderDetails();
            order.num = x;
            order.name = b;
            order.customer = c;
            order.price = Convert.ToInt32(d);
            order.phone = Convert.ToInt64(p);
            order.order = Convert.ToInt64(o);
            using (var db = new OrderDB())
            {
                try
                {
                    db.Order.Add(order);
                    db.SaveChanges();
                    MessageBox.Show("success", "remind：", MessageBoxButtons.OK);
                }
                catch { MessageBox.Show("error，number repeat！ ", "remind：", MessageBoxButtons.OK); }

            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try { p = this.textBox5.Text; }
            catch { };
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            try { o = this.textBox6.Text; }
            catch { };
        }
    }
}
