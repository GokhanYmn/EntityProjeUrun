using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityProjeUrun
{
    public partial class FrmUrun : Form
    {
        public FrmUrun()
        {
            InitializeComponent();
        }
        DbEntityUrunEntities db = new DbEntityUrunEntities();
        private void btnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from x in db.TBL_URUN
                                        select new
                                        {
                                            x.URUNID,
                                            x.URUNAD,
                                            x.MARKA,
                                            x.STOK,
                                            x.FIYAT,
                                            x.DURUM,
                                            x.TBL_KATEGORI.AD,
                                        }).ToList();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            TBL_URUN urun = new TBL_URUN();
            urun.URUNAD = txtUrunAd.Text;
            urun.DURUM = true;
            urun.STOK = short.Parse(txtStok.Text);
            urun.MARKA = txtMarka.Text;
            urun.FIYAT = decimal.Parse(txtFiyat.Text);
            urun.KATEGORI = int.Parse(cmbKategori.Text);
            db.TBL_URUN.Add(urun);
            db.SaveChanges();
            MessageBox.Show("Ürün eklendi");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox1.Text);
            var urn = db.TBL_URUN.Find(x);
            db.TBL_URUN.Remove(urn);
            db.SaveChanges();
            MessageBox.Show("Ürün Silindi");

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox1.Text);
            var urn = db.TBL_URUN.Find(x);
            urn.URUNAD = txtUrunAd.Text;
            urn.STOK = short.Parse(txtStok.Text);
            urn.KATEGORI = int.Parse(cmbKategori.SelectedValue.ToString());
            urn.MARKA = txtMarka.Text;
            urn.FIYAT = decimal.Parse(txtFiyat.Text);
            db.SaveChanges();
            MessageBox.Show("Ürün Güncellendi");
        }

        private void FrmUrun_Load(object sender, EventArgs e)
        {
            var kategoriler = (from x in db.TBL_KATEGORI select new { x.ID, x.AD }).ToList();
            cmbKategori.ValueMember = "ID";
            cmbKategori.DisplayMember = "AD";
            cmbKategori.DataSource = kategoriler;
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtUrunAd.Text = cmbKategori.SelectedValue.ToString();
        }
    }
}
