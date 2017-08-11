using MarketMatikEntity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketMatikDAL.VM
{
    public class VMUrun
    {
        public int UrunID { get; set; }
        public string Barkod { get; set; }
        //public int Adet { get; set; }
        //public double AlisFiyati { get; set; }
        //public double SatisFiyati { get; set; }
        //public double SonFiyat { get; set; }
        public string UrunAdi { get; set; }
        //public double Gramaji { get; set; }
        public string Marka { get; set; }
        public string Kategoriler { get; set; }
        public string Kampanya { get; set; }
        public string Benzersiz { get; set; }
    }
}
