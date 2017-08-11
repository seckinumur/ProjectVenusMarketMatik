using MarketMatikEntity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketMatikDAL.VM
{
    public class VMKampanya
    {
        public int KampanyaID { get; set; }
        public string KampanyaAdi { get; set; }
        public double IndirimOrani { get; set; }
        public string Benzersiz { get; set; }
    }
}
