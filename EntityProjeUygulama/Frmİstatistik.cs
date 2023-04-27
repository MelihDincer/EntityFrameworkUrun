using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityProjeUygulama
{
    public partial class Frmİstatistik : Form
    {
        public Frmİstatistik()
        {
            InitializeComponent();
        }

        DbEntityUrunEntities db = new DbEntityUrunEntities();
        private void Frmİstatistik_Load(object sender, EventArgs e)
        {
            label2.Text = db.TBLKATEGORI.Count().ToString(); //toplam kategori
            label3.Text = db.TBLURUN.Count().ToString(); //toplam ürün
            label7.Text = db.TBLMUSTERI.Count(x => x.DURUM == true).ToString(); //aktif müşteri
            label5.Text = db.TBLMUSTERI.Count(x => x.DURUM == false).ToString(); //pasif müşteri
            label13.Text = db.TBLURUN.Sum(y => y.STOK).ToString();//toplam stok
            label21.Text = db.TBLSATIS.Sum(z => z.FIYAT).ToString() + "₺"; //kasadaki para
            label11.Text = (from x in db.TBLURUN orderby x.FIYAT descending select x.URUNAD+" : "+ x.FIYAT +"₺" ).FirstOrDefault(); //en yüksek fiyatlı ürün
            label9.Text= (from x in db.TBLURUN orderby x.FIYAT ascending select x.URUNAD + " : " + x.FIYAT+"₺").FirstOrDefault(); //en düşük fiyatlı ürün
            label15.Text = db.TBLURUN.Count(x => x.KATEGORI == 1).ToString(); //beyaz eşya sayısı
            label17.Text = db.TBLURUN.Count(x => x.URUNAD == "BUZDOLABI").ToString(); //buzdolabı sayısı
            label23.Text = (from x in db.TBLMUSTERI select x.SEHIR).Distinct().Count().ToString(); //farklı şehir sayısı
            label19.Text = db.MARKAGETIR().FirstOrDefault();// SQL tarafında oluşturduğumuz prosedürü modelimize dahil ettik. MARKAGETIR adlı prosedürü bu şekilde çağırdık.
        }
    }
}
