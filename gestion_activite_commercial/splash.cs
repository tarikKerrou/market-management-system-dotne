using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gestion_activite_commercial
{
    public partial class splash : Form
    {
        public splash()
        {
            InitializeComponent();
        }

        private void splash_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
        int startpoint = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
        
            
            startpoint += 1;
            prgrss.Value = startpoint;
            if (prgrss.Value == 100)
            {
                prgrss.Value = 0;
                timer1.Stop();
                Form1 log= new Form1(); 
                this.Hide();
                log.Show();
            }
        }
    }
}
