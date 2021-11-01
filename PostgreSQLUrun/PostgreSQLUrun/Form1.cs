using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PostgreSQLUrun
{
    public partial class FrmMainPage : Form
    {
        public FrmMainPage()
        {
            InitializeComponent();
        }

        private void btnUrun_Click(object sender, EventArgs e)
        {
            FrmUrun urun = new FrmUrun();
            urun.Show();
            this.Hide();
        

        }

        private void btnKategori_Click(object sender, EventArgs e)
        {
            FrmKategori kategori = new FrmKategori();
            kategori.Show();
            this.Hide();
            
        }
    }
}
