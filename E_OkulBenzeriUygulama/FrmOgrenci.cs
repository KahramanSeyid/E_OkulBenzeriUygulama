using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_OkulBenzeriUygulama
{
    public partial class FrmOgrenci : Form
    {
        public FrmOgrenci()
        {
            InitializeComponent();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        DataSet1TableAdapters.DataTable1TableAdapter ds = new DataSet1TableAdapters.DataTable1TableAdapter();
        private void FrmOgrenci_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource= ds.OgrenciListesi();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            String c="";
            if(RbKız.Checked==true) 
            {
                c = "KIZ";
            }if(RbErkek.Checked==true)
            {
                c = "ERKEK";
            }
            ds.OgrenciEkle(TxtAd.Text,TxtSoyad.Text,byte.Parse(CmbKulub.Text),c);
            MessageBox.Show("Öğrenci Eklendi.");
        }
    }
}
