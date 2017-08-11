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
   public class KategoriRepo
    {
        public static bool Ekle(VMKategori Data)
        {
            using(MMDB db = new MMDB())
            {
                try
                {
                    bool bul = db.Kategoriler.Any(p => p.KategoriAdi == Data.KategoriAdi.Trim());
                    if (bul != true)
                    {
                        db.Kategoriler.Add(new Kategoriler()
                        {
                            KategoriAdi = Data.KategoriAdi.Trim()
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
        public static bool Guncelle(VMKategori Data)
        {
            using (MMDB db = new MMDB())
            {
                try
                {
                    var bul = db.Kategoriler.FirstOrDefault(p => p.KategorilerID == Data.KategorilerID);
                    bul.KategoriAdi = Data.KategoriAdi.Trim();
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public static bool Sil(VMKategori Data)
        {
            using (MMDB db = new MMDB())
            {
                try
                {
                    var bul = db.Kategoriler.FirstOrDefault(p => p.KategorilerID == Data.KategorilerID);
                    db.Kategoriler.Remove(bul);
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public static List<VMKategori> Liste()
        {
            using (MMDB db = new MMDB())
            {
                return db.Kategoriler.Select(p => new VMKategori { KategoriAdi = p.KategoriAdi, KategorilerID = p.KategorilerID }).ToList();
            }
        }
        public static VMKategori Bul(int id)
        {
            using (MMDB db = new MMDB())
            {
                return db.Kategoriler.Where(p => p.KategorilerID==id).Select(p=> new VMKategori { KategoriAdi = p.KategoriAdi, KategorilerID = p.KategorilerID }).FirstOrDefault();
            }
        }
    }
}
