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
    public partial class INFORMACIÓN : Form
    {
        public INFORMACIÓN()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form llamado5 = new SEGUNDAHOJA();
            llamado5.ShowDialog();

        }
    }
}
