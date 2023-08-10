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
    public partial class PRESENTACION : Form
    {
        public PRESENTACION()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form llamado = new SEGUNDAHOJA(); 
            llamado.ShowDialog();

        }

        
    }
}
