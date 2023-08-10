using SAMPRO__SANTIAGO_MINES_PROJECT_.MENU_INICIO;
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
    public partial class SEGUNDAHOJA : Form
    {
        public SEGUNDAHOJA()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form llamado2 = new TERCERAHOJA();
            llamado2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form llamado3 = new INFORMACIÓN();
            llamado3.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form llamado4 = new NOSOTROS();
            llamado4.ShowDialog();
        }
    }
}
