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
    public partial class Deletelist : Form
    {
        List<OrderDetails> testList = new List<OrderDetails>();
        XmlSerializer xs = new XmlSerializer(typeof(List<OrderDetails>));
        public Deletelist()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (FileStream a = new FileStream("people.xml", FileMode.Open))
            {
                testList = (List<OrderDetails>)xs.Deserialize(a);

            }
            int x;
            try { x = Convert.ToInt32(textBox1.Text); testList.RemoveAt(x - 1); }
            catch { }
            using (FileStream a = new FileStream("order.xml", FileMode.Create))
            {
                xs.Serialize(a, testList);
            }
        }
    }
}
