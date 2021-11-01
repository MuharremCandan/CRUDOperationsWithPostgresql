using Npgsql;
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
    public partial class FrmUrun : Form
    {
        public FrmUrun()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("Server = localHost; port = 5433 ; Database = dburunler ; user Id =postgres ; password = 0203");

        private string kategoriler = "select* from kategoriler";
        private string urunler = "select* from urunler";
        
       
        private string guncelle = "update urunler set urunad = @p1 , stok = @p2,alisfiyat = @p3, satisfiyat= @p4,gorsel=@p5 , kategori=@p6 where id = @p7  ";
        private void BtnListele_Click(object sender, EventArgs e)
        {

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(urunler, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmUrun_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(kategoriler, baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DisplayMember = "kategoriad";
            comboBox1.ValueMember = "kategoriid";
            comboBox1.DataSource = dt;
            baglanti.Close();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            //TxtUrunAd.Text = comboBox1.SelectedValue.ToString();
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("insert into urunler (id,urunad,stok,alisfiyat,satisfiyat,gorsel,kategori) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7)", baglanti);
            komut.Parameters.AddWithValue("@p1", Convert.ToInt32(TxtUrunId.Text));
            komut.Parameters.AddWithValue("@p2", TxtUrunAd.Text);
            komut.Parameters.AddWithValue("@p3", numericUpDown1.Value);
            komut.Parameters.AddWithValue("@p4", Convert.ToDouble(TxtAlisFiyat.Text));
            komut.Parameters.AddWithValue("@p5", Convert.ToDouble(TxtSatisFiyat.Text));
            komut.Parameters.AddWithValue("@p6", TxtGorsel.Text);
            komut.Parameters.AddWithValue("@p7", comboBox1.SelectedValue);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ürün kaydı başarılı bir şekilde gerçekleştirildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);



        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("delete from urunler where  id = @p1", baglanti);
            komut2.Parameters.AddWithValue("@p1", Convert.ToInt32(TxtUrunId.Text));
            DialogResult dr = new DialogResult();

            dr = MessageBox.Show("Silmek istediğinize emin misiniz?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                komut2.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Silme işlem başarılı bir şekilde tamamlandı! ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                MessageBox.Show("Silme işlem başarısız!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }

        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
           // private string guncelle = "update urunler set urunad = @p1 , stok = @p2,alisfiyat = @p3, satisfiyat= @p4,gorsel=@p5 , kategori=@p6 where id = @p7  ";
        baglanti.Open();
            NpgsqlCommand komut3 = new NpgsqlCommand(guncelle, baglanti);
            komut3.Parameters.AddWithValue("@p7", Convert.ToInt32(TxtUrunId.Text));
            komut3.Parameters.AddWithValue("@p1", TxtUrunAd.Text);
            komut3.Parameters.AddWithValue("@p2", Convert.ToInt32( numericUpDown1.Value.ToString()));
            komut3.Parameters.AddWithValue("@p3", Convert.ToDouble(TxtAlisFiyat.Text));
            komut3.Parameters.AddWithValue("@p4", Convert.ToDouble(TxtSatisFiyat.Text));
            komut3.Parameters.AddWithValue("@p5", TxtGorsel.Text);
            komut3.Parameters.AddWithValue("@p6", comboBox1.SelectedValue);
            komut3.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Güncellme işlemi başarılı bir şekilde gerçekleştirildi!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnGetView_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            NpgsqlCommand komut4 = new NpgsqlCommand("select * from urunlistesi",baglanti);
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(komut4);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FrmMainPage main = new FrmMainPage();
            main.Show();
            this.Hide();
        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut5 = new NpgsqlCommand("select * from urunler where id=@p1", baglanti);
            if (String.IsNullOrEmpty(TxtUrunId.Text) ||  TxtUrunId.Text.Contains(" ")  || TxtUrunId.Text.Contains("[a-Z]"))
            {
                MessageBox.Show("Lütfen id numarasını giriniz!","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                komut5.Parameters.AddWithValue("@p1", Convert.ToInt32(TxtUrunId.Text));
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(komut5);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
          
            baglanti.Close();


        }

        private void TxtUrunId_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void TxtUrunId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) ==false && !char.IsControl(e.KeyChar) == true)
            {
                e.Handled = true;
            }
        }
    }
}
