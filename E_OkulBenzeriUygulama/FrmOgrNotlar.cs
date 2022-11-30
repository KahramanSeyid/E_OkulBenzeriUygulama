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
namespace E_OkulBenzeriUygulama
{
    public partial class FrmOgrNotlar : Form
    {
        public FrmOgrNotlar()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-JATRE4M\SQLEXPRESS;Initial Catalog=BonusOkul;Integrated Security=True");
        public string numara;
        private void FrmOgrNotlar_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("SELECT DERSAD,SINAV1,SINAV2,SINAV3,PROJE,ORTALAMA,DURUM FROM TBLNOTLAR\r\nINNER JOIN TBLDERSLER ON TBLNOTLAR.DERSID = TBLDERSLER.DERSID WHERE OGRID = 1", baglanti);
            komut.Parameters.AddWithValue("@P1",numara);
            //this.Text = numara.ToString();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource= dt;

            baglanti.Open();

            SqlCommand komut1 = new SqlCommand("select OGRAD,OGRSOYAD from TBLOGRENCİLER where OGRID=@p1", baglanti);

            komut1.Parameters.AddWithValue("@p1", numara);

            SqlDataReader dr1 = komut1.ExecuteReader();

            while (dr1.Read())

            {

                this.Text = dr1[0] + " " + dr1[1].ToString();

            }

            baglanti.Close();
        }
    }
}
