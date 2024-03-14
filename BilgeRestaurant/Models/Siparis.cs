using BilgeRestaurant.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeRestaurant.Models
{
	public class Siparis : BaseEntity
	{
		public Siparis(string masaNo)
		{
			Isim = masaNo;
		}

		public AnaYemek SecilenAnaYemek { get; set; }

		public AraSicak SecilenAraSicak { get; set; }

		public Tatli SecilenTatli{ get; set; }

		public Icecek SecilenIcecek { get; set; }




		public void Fiyatlandir(YemekTipi y)
		{
			switch (y)
			{
				case YemekTipi.AnaYemek:
					Fiyat += SecilenAnaYemek.Fiyat;
					break;
				case YemekTipi.AraSicak:
					Fiyat += SecilenAraSicak.Fiyat;
					break;
				case YemekTipi.Tatli:
					Fiyat += SecilenTatli.Fiyat;
					break;
				case YemekTipi.Icecek:
					Fiyat += SecilenIcecek.Fiyat;
					break;

			}
		}

		public decimal TutarHesapla()
		{
			if (SecilenAnaYemek != null) Fiyatlandir(YemekTipi.AnaYemek);
			if (SecilenAraSicak != null) Fiyatlandir(YemekTipi.AraSicak);
			if (SecilenTatli != null) Fiyatlandir(YemekTipi.Tatli);
			if (SecilenIcecek != null) Fiyatlandir(YemekTipi.Icecek);

			return Fiyat;
		}
		public override string ToString()
		{
			string siparisYazdir = null;

			if (SecilenAnaYemek != null) siparisYazdir += $"Ana Yemek : {SecilenAnaYemek.Isim} => Fiyatı : {SecilenAnaYemek.Fiyat},";
			if (SecilenAraSicak != null) siparisYazdir += $"Ara Sıcak : {SecilenAraSicak.Isim} => Fiyatı : {SecilenAraSicak.Fiyat},";
			if (SecilenTatli != null) siparisYazdir += $"Tatlı : {SecilenTatli.Isim} => Fiyatı : {SecilenTatli.Fiyat},";
			if (SecilenIcecek != null) siparisYazdir += $"İçecek : {SecilenIcecek.Fiyat} => Fiyatı : {SecilenIcecek.Fiyat},";

			return  $"{Isim} => {siparisYazdir} Siparisin Toplam Tutarı : {TutarHesapla():C2}";
		}

	}
}
