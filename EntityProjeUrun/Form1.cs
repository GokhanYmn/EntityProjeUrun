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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DbEntityUrunEntities db=new DbEntityUrunEntities();
        private void btnListele_Click(object sender, EventArgs e)
        {
            var kategoriler=db.TBL_KATEGORI.ToList();
            dataGridView1.DataSource = kategoriler;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            TBL_KATEGORI t=new TBL_KATEGORI();
            t.AD=textBox2.Text;
            db.TBL_KATEGORI.Add(t);
            db.SaveChanges();
            MessageBox.Show("Kategori Eklendi");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int x=Convert.ToInt32(textBox1.Text);
            var ktgr=db.TBL_KATEGORI.Find(x);
            db.TBL_KATEGORI.Remove(ktgr);
            db.SaveChanges();
            MessageBox.Show("Kategori Silindi");

        }
    }
}
