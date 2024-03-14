using BilgeRestaurant.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BilgeRestaurant
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			List<AnaYemek> anaYemekler = new List<AnaYemek>()
			{
				new AnaYemek{Isim = "Adana Kebap", Fiyat = 190 },
				new AnaYemek{Isim = "Lahmacun", Fiyat = 90 },
				new AnaYemek{Isim = "Beyti Kebap", Fiyat = 210 },
				new AnaYemek{Isim = "Kuşbaşılı Pide", Fiyat = 170 },
				new AnaYemek{Isim = "Kıymalı Pide", Fiyat = 170 },
			};

			cmbAnaYemek.DataSource = anaYemekler;
			Sifirla(cmbAnaYemek);


			List<AraSicak> araSicaklar = new List<AraSicak>()
			{
				new AraSicak{Isim = "Mercimek Çorbası", Fiyat = 50 },
				new AraSicak{Isim = "Domates Çorbası", Fiyat = 50 },
				new AraSicak{Isim = "İçli Köfte", Fiyat = 60 },
				new AraSicak{Isim = "Çiğ Köfte", Fiyat = 40 },
				new AraSicak{Isim = "Fındık Lahmacun", Fiyat = 40 },
			};

			cmbAraSicak.DataSource = araSicaklar;
			Sifirla(cmbAraSicak);

			List<Icecek> icecekler = new List<Icecek>()
			{
				new Icecek{Isim = "Coca Cola", Fiyat = 30 },
				new Icecek{Isim = "Ayran", Fiyat = 30 },
				new Icecek{Isim = "Fanta", Fiyat = 30 },
				new Icecek{Isim = "Sprite", Fiyat = 30 },
				new Icecek{Isim = "Su", Fiyat = 15 },
			};

			cmbIcecek.DataSource = icecekler;
			Sifirla(cmbIcecek);


			List<Tatli> tatlilar = new List<Tatli>()
			{
				new Tatli{Isim = "Baklava", Fiyat = 70 },
				new Tatli{Isim = "Şöbiyet", Fiyat = 50 },
				new Tatli{Isim = "Havuç Dilim", Fiyat = 80 },
				new Tatli{Isim = "KazanDibi", Fiyat = 30 },
				new Tatli{Isim = "Sütlaç", Fiyat = 30 },
			};

			cmbTatli.DataSource = tatlilar;
			Sifirla(cmbTatli);
		}

		private void Sifirla(ComboBox cmbSifirla)
		{
			cmbSifirla.SelectedIndex = -1;	
		}

		private void btnSiparisVer_Click(object sender, EventArgs e)
		{
			if (txtMasaNo.Text == string.Empty)
			{
				MessageBox.Show("Lütfen bir masa no giriniz.");
				return;
			}
			if (cmbAnaYemek.SelectedIndex < 0 && cmbAraSicak.SelectedIndex < 0 && cmbTatli.SelectedIndex < 0 && cmbIcecek.SelectedIndex < 0)
			{
				MessageBox.Show("Sipariş oluşturabilmek için en az bir adet ürün eklemelisiniz.");
				return;
			}
			Siparis s = new Siparis(txtMasaNo.Text);

			if (cmbAnaYemek.SelectedIndex > -1) s.SecilenAnaYemek = cmbAnaYemek.SelectedItem as AnaYemek;
			if (cmbAraSicak.SelectedIndex > -1) s.SecilenAraSicak = cmbAraSicak.SelectedItem as AraSicak;
			if (cmbTatli.SelectedIndex > -1) s.SecilenTatli = cmbTatli.SelectedItem as Tatli;
			if (cmbIcecek.SelectedIndex > -1) s.SecilenIcecek = cmbIcecek.SelectedItem as Icecek;
			lstSiparisler.Items.Add(s);
			txtMasaNo.Clear();
			cmbAnaYemek.SelectedIndex = cmbAraSicak.SelectedIndex = cmbIcecek.SelectedIndex = cmbTatli.SelectedIndex = -1;

		}

		

		private void btnCiro_Click(object sender, EventArgs e)
		{
			decimal ciro = 0;
			foreach (Siparis item in lstSiparisler.Items)
			{
				ciro += item.Fiyat;
			}

			lblCiro.Text = Convert.ToString($"{ciro:C2}");
		}

		private void btnResetle_Click(object sender, EventArgs e)
		{
			lblCiro.Text = "";
		}
	}
}
