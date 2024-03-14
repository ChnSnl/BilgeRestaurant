using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeRestaurant.Models
{
	public abstract class BaseEntity
	{
		public string Isim { get; set; } 
		public decimal Fiyat { get; set; }

		//Base Entity'den miras alan her class'ın bir ismi ve Fiyatı olacak.

		public override string ToString()
		{
			return $"{Isim} {Fiyat:C2}";
		}
	}
}
