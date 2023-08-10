using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAMPRO__SANTIAGO_MINES_PROJECT_.MENU_INICIO
{
    public partial class NOSOTROS : Form
    {
        public NOSOTROS()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form llamado4 = new SEGUNDAHOJA();
            llamado4.ShowDialog();
        }
    }
}
