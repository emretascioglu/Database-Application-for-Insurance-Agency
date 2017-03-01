using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace sigortaacentasi
{
    public partial class Musteri_Ekrani : Form
    {
        private static String musteriID;     //İD ÇEKMEK İÇİN YEREL DEĞİŞKEN
        private DAO dao;

        public Musteri_Ekrani()
        {
            dao = new DAO();
            InitializeComponent();
            TabloDoldur();

        }

         /* SqlCommand komut;
          SqlConnection baglanti;
          SqlDataAdapter da;                EN SON DAO DA OLACAK ŞEKİL   */

        // ANA EKLE METODU
        private void btnEkle_Click(object sender, EventArgs e)
        {
            pnlEkle.Visible = true;
            pnlListele.Visible = false;
            pnlGuncelle.Visible = false;
            pnlAciklama.Visible = false;
        }
        //ANA LİSTELE METODU
        private void btnListele_Click(object sender, EventArgs e)
        {
            pnlEkle.Visible = false;
            pnlListele.Visible = true;
            pnlGuncelle.Visible = false;
            pnlAciklama.Visible = false;
            TabloDoldur();
        }
        //ANA GÜNCELLE BUTONU METODU
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            pnlGuncelle.Visible = true;
            pnlListele.Visible = true;
            pnlEkle.Visible = false;
            pnlAciklama.Visible = false;
            TabloDoldur();
        }
        // EKLEMEDEN SONRA KUTULARI BOŞALTAN METOD
        private void txtsil()
        {
            txtMusteriAd.Text = "";
            txtMusteriSoyad.Text = "";
            txtMusteriCepNo.Text = "";
            txtMusteriTc.Text = "";
            txtPlaka.Text = "";
            richtxtAciklama.Text = "";
        }

        // EKLE PANELİNDEKİ BUTONA YIKLAYINCA EKLEME YAPAN METOD
        private void btnMusteriKaydet_Click(object sender, EventArgs e)
        {
            String musteriad = txtMusteriAd.Text.Trim();
            String musterisoyad = txtMusteriSoyad.Text.Trim();
            String musteritc = txtMusteriTc.Text.Trim();
            String mustericepno = txtMusteriCepNo.Text.Trim();
            String musteriplaka = txtPlaka.Text.Trim();
            String aciklama = richtxtAciklama.Text.Trim();
            dao.musteriekle(musteriad, musterisoyad, musteritc, mustericepno, musteriplaka, aciklama);
            
            txtsil();  //YAZILI OLANLARI SİLDİM.
            TabloDoldur();   //KAYIT YAPILINCA

        }

        // DATAGRİDVİEW DE GÖSTERİLMESİNİ İSTEİDĞİMİZ METOD

        private void TabloDoldur()  
        {
            dataGridView1.DataSource = dao.musterilerigetir().Tables[0];
        }

        // DATAGRİDVİEW E TIKLAYINCA TEXTBOXLARA ALAN KODLAR

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //delay lagg var 
            TabloDoldur();
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            //GUNCELLEME İÇİN ÇEKİYORUZ
            musteriID = row.Cells[0].Value.ToString();
            txtGuncelad.Text = row.Cells[1].Value.ToString();
            txtGuncelsoyad.Text = row.Cells[2].Value.ToString();
            txtGunceltc.Text = row.Cells[3].Value.ToString();
            txtGuncelcepno.Text = row.Cells[4].Value.ToString();
            txtGuncelplaka.Text = row.Cells[5].Value.ToString();
            //açıklama getir bölümünü çekiyoruz.
            txtBilgi1.Text = row.Cells[1].Value.ToString();
            txtBilgi2.Text = row.Cells[2].Value.ToString();
            txtBilgi3.Text = row.Cells[3].Value.ToString();
            txtAciklama.Text = row.Cells[6].Value.ToString();
        }

        // GÜNCELLE PANELİNDE Kİ BUTONA TIKLANINCA YAPILAN İŞLEMLER !

        private void btnGuncel_Click(object sender, EventArgs e)
        {

            String musteriad = txtGuncelad.Text.Trim();
            String musterisoyad = txtGuncelsoyad.Text.Trim();
            String musteritc = txtGunceltc.Text.Trim();
            String mustericepno = txtGuncelcepno.Text.Trim();
            String musteriplaka = txtGuncelplaka.Text.Trim();
            String aciklama = txtAciklama.Text.Trim();
            dao.musteriguncelle(musteriID, musteriad, musterisoyad, musteritc, mustericepno, musteriplaka, aciklama);
            
            TabloDoldur();
              
        }

        // SİLİNDE DATAGRİDW İEVDEN SİLDİDİM
        private void btnSil_Click(object sender, EventArgs e)  
        {
            DialogResult cevap;
            cevap = MessageBox.Show("Müşteri Siliniyor! Emin misiniz ?","Uyarı!",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(cevap==DialogResult.Yes)
            {
                dao.musterisil(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                TabloDoldur();
            }
        }  
        private void btnAciklama_Click(object sender, EventArgs e)
        {
            pnlAciklama.Visible = true;
            pnlListele.Visible = true;
            pnlEkle.Visible = false;
            pnlGuncelle.Visible = false;
        }

        //TODOOOOOOOOOO

        private void btnSorgu_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = dao.aciklamalarigetir(musteriID).Tables[0];
        }  
    }
}
