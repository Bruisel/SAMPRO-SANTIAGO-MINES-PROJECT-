using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAMPRO__SANTIAGO_MINES_PROJECT_
{
    public partial class TERCERAHOJA : Form
    {
        public TERCERAHOJA()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form segundollamado = new SEGUNDAHOJA();
            segundollamado.ShowDialog();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form llamado5 = new CUARTAHOJA();
            llamado5.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form llamado6 = new SEGUNDAHOJA(); 
            llamado6.ShowDialog();

        }
    }
}
