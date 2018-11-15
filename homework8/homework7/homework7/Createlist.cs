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
            using (FileStream a = new FileStream("order.xml", FileMode.Open))
            {
                testList = (List<OrderDetails>)xs.Deserialize(a);
            }
            OrderDetails order = new OrderDetails();
            order.num = x;
            order.name = b;
            order.customer = c;
            order.price = Convert.ToInt32(d);
            order.phone = Convert.ToInt64(p);
            order.order = Convert.ToInt64(o);
            bool repeatnum = false;
            foreach (OrderDetails i in testList)
            {
                if (order.order == i.order)
                {
                    MessageBox.Show("repeat", "remind:", MessageBoxButtons.OK);
                    repeatnum = true;
                }
            }
            testList.Add(order);
            if (repeatnum)
            {
                testList.Remove(order);
            }
            if (order.phone < 10000000000 || order.phone> 16000000000)
            {
                MessageBox.Show("error!please retry to input your phone number", "remind:", MessageBoxButtons.OK);
                testList.Remove(order);
            }
            try
            {
                string year = o.Substring(0, 4);
                string month = o.Substring(4, 2);
                string day = o.Substring(6, 2);
                if (order.order > 20000000000 && order.order < 26000000000)
                {
                    if (Convert.ToInt32(year) > 1999 && Convert.ToInt32(year) < 3000 && Convert.ToInt32(month) < 13
                      && Convert.ToInt32(month) > 0 && Convert.ToInt32(day) < 32
                      && Convert.ToInt32(day) > 0) { }
                    else
                    {
                        MessageBox.Show("error! retry to input order id number", "remind:", MessageBoxButtons.OK);
                        testList.Remove(order);
                    }
                }
                else
                {
                    MessageBox.Show("error! retry to input order id number", "remind:", MessageBoxButtons.OK);
                    testList.Remove(order);
                }
            }
            catch
            {
                MessageBox.Show("error! retry to input order id number", "remind:", MessageBoxButtons.OK);
                testList.Remove(order);
            }
            using (FileStream a = new FileStream("order.xml", FileMode.Create))
            {
                xs.Serialize(a, testList);
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
