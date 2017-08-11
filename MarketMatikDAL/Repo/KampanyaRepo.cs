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
   public class KampanyaRepo
    {
        public static bool Ekle(VMKampanya Data)
        {
            using (MMDB db = new MMDB())
            {
                try
                {
                    bool bul = db.Kampanya.Any(p => p.KampanyaAdi == Data.KampanyaAdi.Trim());
                    if (bul != true)
                    {
                        db.Kampanya.Add(new Kampanya()
                        {
                            KampanyaAdi = Data.KampanyaAdi.Trim(),
                            IndirimOrani= Data.IndirimOrani
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
        public static bool Guncelle(VMKampanya Data)
        {
            using (MMDB db = new MMDB())
            {
                try
                {
                    var bul = db.Kampanya.FirstOrDefault(p => p.KampanyaID == Data.KampanyaID);
                    bul.KampanyaAdi = Data.KampanyaAdi.Trim();
                    bul.IndirimOrani = Data.IndirimOrani;
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public static bool Sil(VMKampanya Data)
        {
            using (MMDB db = new MMDB())
            {
                try
                {
                    var bul = db.Kampanya.FirstOrDefault(p => p.KampanyaID == Data.KampanyaID);
                    db.Kampanya.Remove(bul);
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public static List<VMKampanya> Liste()
        {
            using (MMDB db = new MMDB())
            {
                return db.Kampanya.Select(p => new VMKampanya { KampanyaAdi = p.KampanyaAdi, KampanyaID = p.KampanyaID,IndirimOrani= p.IndirimOrani }).ToList();
            }
        }
        public static VMKampanya Bul(int id)
        {
            using (MMDB db = new MMDB())
            {
                return db.Kampanya.Where(p => p.KampanyaID == id).Select(p => new VMKampanya { KampanyaAdi = p.KampanyaAdi, KampanyaID = p.KampanyaID, IndirimOrani = p.IndirimOrani }).FirstOrDefault();
            }
        }
    }
}
