using sigortaacentasi;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sigortaacentasi
{
    class DAO
    {
        protected SqlConnection baglanti;
        protected SqlCommand komut;
        protected String musteriid;

        public DAO()
        {
            baglanti = new SqlConnection("Data Source=EMRE;Initial Catalog=sigortaacentasi;User ID=sa;Password=19951903");
            komut = new SqlCommand();
        }
        public DataSet musterilerigetir()
        {
            DataSet ds = null;
            try {
                baglanti.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT m.musteriid, musteriad ,musterisoyad ,musteritc, mustericepno, musteriplaka, aciklama " + 
                    "FROM dbo.musteri as m inner join dbo.aciklama as a on a.musteriid = m.musteriid " + 
                    " where a.aciklamaid = " + 
                        "(select top 1 aciklamaid " + 
                           "from dbo.aciklama where musteriid = a.musteriid order by aciklamaid desc) " + 
                    "order by m.musteriid desc", baglanti);
                ds = new DataSet();
                da.Fill(ds);
                
            }
            catch {

            } finally {
                baglanti.Close();
            }
            return ds;
        }

        public void musteriekle(String musteriad, String musterisoyad, String musteritc, String mustericepno, String musteriplaka, String aciklama)
        {
            try {
                
                komut.Connection = baglanti;
                baglanti.Open();
                komut.CommandText = "INSERT INTO musteri(musteriad,musterisoyad,musteritc,mustericepno,musteriplaka) VALUES " + 
                    "('" + musteriad + "','" + musterisoyad + "','" + musteritc + "','" + mustericepno + "','" + musteriplaka + "'); select scope_identity()";
                

                //aciklama tablosuna gitti burası
                musteriid = komut.ExecuteScalar().ToString();
                komut.CommandText = "INSERT INTO aciklama(musteriid, aciklama) VALUES('" + musteriid + "','" + aciklama + "')";
                komut.ExecuteNonQuery();
                MessageBox.Show("KAYIT BAŞARILI!");
            } catch (Exception e) {
                Console.WriteLine("{0} Exception caught.", e);
                MessageBox.Show("HATA!");
            } finally {
                baglanti.Close();
            }
        }

        public void musteriguncelle(String id, String musteriad, String musterisoyad, String musteritc, String mustericepno, String musteriplaka, String aciklama)
        {
            try
            {
                komut.Connection = baglanti;
                baglanti.Open();  
                komut.CommandText = "update musteri set musteriad = @musteriad, musterisoyad = @musterisoyad, " +
                    "musteritc = @musteritc , mustericepno = @mustericepno, musteriplaka = @musteriplaka " +
                    "where musteriid= @musteriid";
                komut.Parameters.AddWithValue("@musteriad", musteriad);
                komut.Parameters.AddWithValue("@musterisoyad", musterisoyad);
                komut.Parameters.AddWithValue("@musteritc", musteritc);
                komut.Parameters.AddWithValue("@mustericepno", mustericepno);
                komut.Parameters.AddWithValue("@musteriplaka", musteriplaka);
                komut.Parameters.AddWithValue("@musteriid", id);

                komut.ExecuteNonQuery();
                                                                            //bura id isi
                komut.CommandText = "INSERT INTO aciklama(musteriid, aciklama) VALUES('" + id + "','" + aciklama + "')";
                komut.ExecuteNonQuery();
                
                MessageBox.Show("GUNCELLENDİ ! ");
            } catch(Exception e) {
                Console.WriteLine("{0} Exception caught.", e);
                MessageBox.Show("HATA!");
            } finally {
                baglanti.Close();
            }
        }

        public void musterisil(String id)
        {
            try {
                baglanti.Open();
                komut.Connection = baglanti;
                komut.CommandText = "DELETE FROM musteri WHERE musteriid='" + id + "'";
                komut.ExecuteNonQuery();
            } catch {

            } finally {
                baglanti.Close();
            }
        }

        public DataSet aciklamalarigetir(String id)
        {
            DataSet ds = null;
            try {
                baglanti.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT aciklama FROM dbo.aciklama where musteriid = " + id, baglanti);
                ds = new DataSet();
                da.Fill(ds);
            }
            catch
            {

            } finally
            {
                baglanti.Close();
            }

            return ds;
        }
    }
}
