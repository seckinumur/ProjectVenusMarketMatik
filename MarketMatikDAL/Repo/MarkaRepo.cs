using MarketMatikDAL.VM;
using MarketMatikEntity.Content;
using MarketMatikEntity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketMatikDAL.Repo
{
   public class MarkaRepo
    {
        public static bool Ekle(VMMArka Data)
        {
            using (MMDB db = new MMDB())
            {
                try
                {
                    bool bul = db.Marka.Any(p => p.MarkaAdi == Data.MarkaAdi.Trim());
                    if (bul != true)
                    {
                        db.Marka.Add(new Marka()
                        {
                            MarkaAdi = Data.MarkaAdi.Trim()
                        });
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                }
            }
        }
        public static bool Guncelle(VMMArka Data)
        {
            using (MMDB db = new MMDB())
            {
                try
                {
                    var bul = db.Marka.FirstOrDefault(p => p.MarkaID == Data.MarkaID);
                    bul.MarkaAdi = Data.MarkaAdi.Trim();
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public static bool Sil(VMMArka Data)
        {
            using (MMDB db = new MMDB())
            {
                try
                {
                    var bul = db.Marka.FirstOrDefault(p => p.MarkaID == Data.MarkaID);
                    db.Marka.Remove(bul);
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public static List<VMMArka> Liste()
        {
            using (MMDB db = new MMDB())
            {
                return db.Marka.Select(p => new VMMArka { MarkaAdi = p.MarkaAdi, MarkaID = p.MarkaID }).ToList();
            }
        }
        public static VMMArka Bul(int id)
        {
            using (MMDB db = new MMDB())
            {
                return db.Marka.Where(p => p.MarkaID == id).Select(p => new VMMArka { MarkaAdi = p.MarkaAdi, MarkaID = p.MarkaID }).FirstOrDefault();
            }
        }
    }
}
