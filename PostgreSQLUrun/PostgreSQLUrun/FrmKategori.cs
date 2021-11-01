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
    public partial class FrmKategori : Form
    {
        public FrmKategori()
        {
            InitializeComponent();
        }

        NpgsqlConnection baglanti = new NpgsqlConnection("Server = localHost; port = 5433 ; Database = dburunler ; user Id =postgres ; password = 0203");
        private void BtnListele_Click(object sender, EventArgs e)
        {
            string sorgu = "select* from kategoriler";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string ekle = "insert into kategoriler (kategoriid,kategoriad) values (@p1,@p2)";
            NpgsqlCommand komut1 = new NpgsqlCommand(ekle,baglanti);
            komut1.Parameters.AddWithValue("@p1",Convert.ToInt32(TxtKAtegoriId.Text));
            komut1.Parameters.AddWithValue("@p2", TxtKategıoriAd.Text);
            komut1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kategori ekleme işi başarılı bir şekilde gerçekleşti !");



        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string sil = "delete from kategoriler where kategoriid =@p1";
            NpgsqlCommand komut = new NpgsqlCommand(sil , baglanti);
            komut.Parameters.AddWithValue("@p1",Convert.ToInt32(TxtKAtegoriId.Text));
            DialogResult dr = new DialogResult();

            dr = MessageBox.Show($"{TxtKategıoriAd.Text} kategorisini silmek istediğinize emin misiniz ?","Bilgi",MessageBoxButtons.YesNo,MessageBoxIcon.Stop);
            if (dr == DialogResult.Yes)
            {
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Silme işlemi başarılı bir şekilde tamamlandı !","İnformation !" ,MessageBoxButtons.OK,MessageBoxIcon.Stop);

            }
            else
            {
                MessageBox.Show("Silme işlemi başarısız !","Uyarı!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            
          
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut = new NpgsqlCommand("update kategoriler set kategoriad=@p2 where kategoriid=@p1",baglanti);
            komut.Parameters.AddWithValue("@p1",Convert.ToInt32(TxtKAtegoriId.Text));
            komut.Parameters.AddWithValue("@p2", TxtKategıoriAd.Text.ToString());
            komut.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Güncelleme işlemi başarılı bir şekilde tamalandı!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FrmMainPage main = new FrmMainPage();
            main.Show();
            this.Hide();

        }
    }
}
