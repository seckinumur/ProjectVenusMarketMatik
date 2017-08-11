using MarketMatikEntity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketMatikDAL.VM
{
    public class VMKullanicilar
    {
        public string Email { get; set; }
        public string Sifre { get; set; }
        public string Yetki { get; set; }
        public string Gorev { get; set; }
        public Guid Benzersiz { get; set; }
    }
}
