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

namespace ENTITYORNEK
{
    public partial class BtnLingEntity : Form
    {
        public BtnLingEntity()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ID_Click(object sender, EventArgs e)
        {

        }
        DB_SINAVOGRENCIEntities db = new DB_SINAVOGRENCIEntities();
        private void BtnDerslistesi_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection (@"Data Source=DESKTOP-MSI1S2I;Initial Catalog=DB SINAVOGRENCI;Integrated Security=True");
            SqlCommand komut = new SqlCommand("Select * from TBLDERSLER",baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Btnogrencilistele_Click(object sender, EventArgs e)
        {
            DB_SINAVOGRENCIEntities db = new DB_SINAVOGRENCIEntities();
            dataGridView1.DataSource = db.TBLOGRENCIs.ToList();
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
                
                }

        private void BtnNotlistesi_Click(object sender, EventArgs e)
        {
            var quary = from item in db.TBLNOTLARs
                        select new { item.NOTID, item.TBLOGRENCI.AD,item.TBLOGRENCI.SOYAD,item.TBLDERSLER.DERSAD,
                            item.ORTALAMA, item.SINAV1, item.SINAV2, item.SINAV3,item.DURUM };
            dataGridView1.DataSource = quary.ToList();
        }

        private void Btnkaydet_Click(object sender, EventArgs e)
        {
            TBLOGRENCI t = new TBLOGRENCI();
            t.AD = TxtAd.Text;
            t.SOYAD = TxtSoyad.Text;
            db.TBLOGRENCIs.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ogrenci listeye eklenmisdir");
        }

        private void Btnsil_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(TxtIOgrenciId.Text);
            var b = db.TBLOGRENCIs.Find(a);
            db.TBLOGRENCIs.Remove(b);
            db.SaveChanges();
            MessageBox.Show ("Silme emeliyyati ugurla heyata kecirildi");

            


        }

        private void Btnguncelle_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(TxtIOgrenciId.Text);
            var query = db.TBLOGRENCIs.Find(a);
            query.AD = TxtAd.Text;
            query.SOYAD = TxtSoyad.Text;
            query.SEKIL = Txtsekil.Text;
            db.SaveChanges();
            MessageBox.Show("Guncelleme basariyla gerceklesdi");
        }

        private void Btnpresodure_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.NOTLISTELE();
        }

        private void Btnbul_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = db.TBLOGRENCIs.Where(x => x.AD == TxtAd.Text ||
            x.SOYAD==TxtSoyad.Text).ToList();
        }

        private void TxtAd_TextChanged(object sender, EventArgs e)
        {
            String aranan = TxtAd.Text;
            var degerler = from item in db.TBLOGRENCIs
                           where item.AD.Contains(aranan)
                           select item;
            dataGridView1.DataSource = degerler.ToList();
                             
        }

        private void weffraewfef_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                List<TBLOGRENCI> liste1 = db.TBLOGRENCIs.OrderBy(p => p.AD).ToList();
                dataGridView1.DataSource = liste1;
            }
            if (radioButton2.Checked == true)
            {
                List<TBLOGRENCI> lisrele2 = db.TBLOGRENCIs.OrderByDescending(p => p.AD).ToList();
                dataGridView1.DataSource = lisrele2;
            }

            if (radioButton3.Checked == true)
            {
                List<TBLOGRENCI> listele3 = db.TBLOGRENCIs.OrderBy(p => p.AD).Take(3).ToList();
                dataGridView1.DataSource = listele3;

            }

            if (radioButton4.Checked == true)
            {
                List<TBLOGRENCI> listele4 = db.TBLOGRENCIs.Where(p => p.ID == 5).ToList();
                dataGridView1.DataSource = listele4;

            }
            if (radioButton5.Checked == true)
            {
                List<TBLOGRENCI> listele5 = db.TBLOGRENCIs.Where(a => a.AD.StartsWith("a")).ToList();
                dataGridView1.DataSource = listele5;

            }

            if (radioButton6.Checked == true)
            {
                List<TBLOGRENCI> listele6 = db.TBLOGRENCIs.Where(a => a.AD.EndsWith("a")).ToList();
                dataGridView1.DataSource = listele6;

            }
            if (radioButton7.Checked == true)
            {
                bool deger = db.TBLKULUPLERs.Any();
                MessageBox.Show(deger.ToString(), "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (radioButton8.Checked == true)
            {
                int toplam = db.TBLOGRENCIs.Count();
                MessageBox.Show(toplam.ToString(), "Toplam ogrenci sayi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (radioButton9.Checked == true)
            {
                var toplam = db.TBLNOTLARs.Sum(a => a.SINAV1);
                MessageBox.Show("Sinav1 toplama" + toplam.ToString());
            }

            if (radioButton10.Checked == true)
            {
                var ortalama = db.TBLNOTLARs.Average(a => a.SINAV1);
                MessageBox.Show("Sinav1 ortalamasi" + ortalama, ToString()); ;
            }


            if (radioButton11.Checked == true)
            {
                var yuksek = db.TBLNOTLARs.Max(a => a.SINAV1);
                MessageBox.Show("En yuksek not" + yuksek, ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            if (radioButton12.Checked == true)
            {
                var az = db.TBLNOTLARs.Min(a => a.SINAV1);
                MessageBox.Show("En dusuk sinav notu" + az, ToString(),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (radioButton13.Checked==true)
            { var a = db.TBLNOTLARs.Where(j => j.SINAV1 < 50);
                dataGridView1.DataSource = a.ToList();
            }
              
            

        }

        private void BtnNotGuncele_Click(object sender, EventArgs e)
        {
            var sorgu = from d1 in db.TBLNOTLARs
                        join d2 in db.TBLOGRENCIs
                        on d1.OGR equals d2.ID
                        select new
                        {
                            Ogrenci=d2.AD,
                            Soyad=d2.SOYAD,
                            Sinav1=d1.SINAV1,
                            Sinav2=d1.SINAV2,
                            Sinav3=d1.SINAV3

                        };
            dataGridView1.DataSource = sorgu.ToList();



            var deger = from item in db.TBLNOTLARs
                        select new
                        { item.NOTID, item.TBLOGRENCI.AD,
                            item.TBLDERSLER.DERSAD };
            dataGridView1.DataSource = deger.ToList();

            
        }  
           
    }
}

