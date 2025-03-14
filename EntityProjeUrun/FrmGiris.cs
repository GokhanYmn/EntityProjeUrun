﻿using System;
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
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbEntityUrunEntities db = new DbEntityUrunEntities();
            var sorgu=from x in db.TBL_ADMIN where x.KULLANICI == textBox1.Text && x.SIFRE==textBox2.Text select x;
            if (sorgu.Any())
            {
                FrmAnaForm ana = new FrmAnaForm();
                ana.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı veya şifre");
            }
        }
    }
}
