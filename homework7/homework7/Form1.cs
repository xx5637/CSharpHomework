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
    public partial class Form1 : Form
    {
        List<OrderDetails> testList = new List<OrderDetails>();
        XmlSerializer xs = new XmlSerializer(typeof(List<OrderDetails>));
        public void Showlist(List<OrderDetails> testList)
        {
            string t = "";
            foreach (OrderDetails od in testList)
            {

                t = t + od.ToString() + "\n";

            }
            label1.Text = t;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Createlist  List = new Createlist();
            List.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Deletelist List = new Deletelist();
            List.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Changelist List = new Changelist();
            List.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (FileStream a = new FileStream("order.xml", FileMode.Open))
            {
                testList = (List<OrderDetails>)xs.Deserialize(a);

            }
            Showlist(testList);
        }
    }
}
