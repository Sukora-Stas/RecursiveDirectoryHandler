using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecursiveDirectoryHandler_RDH_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //progressBar1.Maximum = 10;
            //for (int i = 10; i > 0; i--)
            //{
            //    progressBar1.Value = progressBar1.Maximum - i;
            //    System.Threading.Thread.Sleep(15);
            //}
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < progressBar1.Maximum)
                progressBar1.Value = progressBar1.Value + 1;
            else
            {
                //progressBar1.Value = progressBar1.Minimum;
                timer1.Stop();
                Hide();
                (new Form2()).ShowDialog();   
                Dispose();
                
            }
        }
    }
}
