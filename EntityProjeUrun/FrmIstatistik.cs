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
    public partial class FrmIstatistik : Form
    {
        public FrmIstatistik()
        {
            InitializeComponent();
        }
        DbEntityUrunEntities db = new DbEntityUrunEntities();
        private void FrmIstatistik_Load(object sender, EventArgs e)
        {
            label2.Text = db.TBL_KATEGORI.Count().ToString();
            lblToplamUrun.Text=db.TBL_URUN.Count().ToString();
            lblAktifMusteri.Text=db.TBL_MUSTERI.Count(x=>x.DURUM==true).ToString();
            lblPasifMusteri.Text = db.TBL_MUSTERI.Count(x=>x.DURUM==false).ToString();
            lblToplamStok.Text=db.TBL_URUN.Sum(x=>x.STOK).ToString();
            lblEnyuksekFiyatlıUrun.Text=(from x in db.TBL_URUN orderby x.FIYAT descending select x.URUNAD).FirstOrDefault();
            lblEndusukFiyatliUrun.Text = (from x in db.TBL_URUN orderby x.FIYAT ascending select x.URUNAD).FirstOrDefault();
            lblKasadakiTutar.Text = db.TBL_SATIS.Sum(x => x.FIYAT).ToString() + " TL";
            lblBeyazEsya.Text=db.TBL_URUN.Count(x=>x.KATEGORI==1).ToString();
            lblSehirSayisi.Text=(from x in db.TBL_MUSTERI select x.SEHIR).Distinct().Count().ToString();
            lblToplamBuzdolabiSayisi.Text=db.TBL_URUN.Count(x=>x.URUNAD=="BUZDOLABI").ToString();
            lblEnfazlaUrunluMarka.Text = db.MARKAGELSIN().FirstOrDefault();
        }
    }
}
