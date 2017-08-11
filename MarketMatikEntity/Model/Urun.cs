using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketMatikEntity.Model
{
    public class Urun
    {
        public int UrunID { get; set; }
        public string Barkod { get; set; }
        //public int Adet { get; set; }
        //public double AlisFiyati { get; set; }
        //public double SatisFiyati { get; set; }
        public string UrunAdi { get; set; }
        //public double Gramaji { get; set; }
        public int MarkaID { get; set; }
        public int KategorilerID { get; set; }
        public int KampanyaID { get; set; }

        public virtual Marka Marka { get; set; }
        public virtual Kategoriler Kategoriler { get; set; }
        public virtual Kampanya Kampanya { get; set; }
    }
}
