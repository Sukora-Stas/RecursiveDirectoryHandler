using System;
using System.Windows.Forms;

namespace RecursiveDirectoryHandler_RDH_
{
    public partial class Logo : Form
    {
        public Logo()
        {
            InitializeComponent();
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
                timer1.Stop();
                Hide();
                (new FrmMain()).ShowDialog();   
                Dispose();
            }
        }
    }
}
