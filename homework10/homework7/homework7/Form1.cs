﻿using System;
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
using System.Xml.XPath;
using System.Xml.Xsl;

namespace homework7
{
    public partial class Form1 : Form
    {
        List<OrderDetails> testList = new List<OrderDetails>();
        XmlSerializer xs = new XmlSerializer(typeof(List<OrderDetails>));
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Createlist  List = new Createlist();
            List.ShowDialog();
            button4.PerformClick();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var db = new OrderDB())
            {
                if (bindingSource1.Current != null)
                {
                    OrderDetails order = (OrderDetails)bindingSource1.Current;
                    var order1 = db.Order.SingleOrDefault(o => o.num== order.num);
                    db.Order.Remove(order1);
                    db.SaveChanges();
                    button4.PerformClick();
                }
                else { MessageBox.Show("have not chosen order "); }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button2.PerformClick();
            MessageBox.Show("input new order");
            button1.PerformClick();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            using (var db = new OrderDB())
            {
                bindingSource1.DataSource = db.Order.ToList();
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            XslCompiledTransform trans = new XslCompiledTransform();
            trans.Load(@"order.xsl");
            trans.Transform(@"order.xml", @".\order.html");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try {
                System.Diagnostics.Process.Start("order.html");
            }
            catch { MessageBox.Show("please produce HTML document before your opening", "hint", MessageBoxButtons.OK); };
        }
    }
}
