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
    public partial class Changelist : Form
    {
        public List<OrderDetails> testList = new List<OrderDetails>();
        XmlSerializer xs = new XmlSerializer(typeof(List<OrderDetails>));
        public Changelist()
        {
            InitializeComponent();
        }
        string newa, newb, newc, newd, newe, newf,newg;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try { newa = this.textBox1.Text; }
            catch { };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (FileStream a = new FileStream("order.xml", FileMode.Open))
            {
                testList = (List<OrderDetails>)xs.Deserialize(a);
            }
            int n = 0;
            foreach (OrderDetails order in testList)
            {
                n += 1;
                if (n == Convert.ToInt32(newa))
                {
                    order.num = newb;
                    order.name = newc;
                    order.customer = newd;
                    order.price = Convert.ToInt32(newe);
                    order.phone = Convert.ToInt64(newf);
                    order.order = Convert.ToInt64(newg);
                }
            }
             using (FileStream a = new FileStream("order.xml", FileMode.Create))
            {
                xs.Serialize(a, testList);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try { newb = this.textBox2.Text; }
            catch { };
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try { newc = this.textBox3.Text; }
            catch { };
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try { newd = this.textBox4.Text; }
            catch { };
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try { newe = this.textBox5.Text; }
            catch { };
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            try { newf = this.textBox6.Text; }
            catch { };
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            try { newg = this.textBox7.Text; }
            catch { };
        }

    }
}
