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
    public class UrunRepo
    {
        public static bool Ekle(VMUrun Data)
        {
            using (MMDB db = new MMDB())
            {
                try
                {
                    bool bul = db.Urun.Any(p => p.Barkod == Data.Barkod.Trim());
                    if (bul != true)
                    {
                        var kampanya = db.Kampanya.FirstOrDefault(p => p.KampanyaAdi == Data.Kampanya);
                        var kategori = db.Kategoriler.FirstOrDefault(p => p.KategoriAdi == Data.Kategoriler);
                        var marka = db.Marka.FirstOrDefault(p => p.MarkaAdi == Data.Marka);
                        db.Urun.Add(new Urun()
                        {
                            //Adet = Data.Adet,
                            //AlisFiyati = Data.AlisFiyati,
                            Barkod = Data.Barkod.Trim(),
                            //Gramaji = Data.Gramaji,
                            KampanyaID = kampanya.KampanyaID,
                            KategorilerID = kategori.KategorilerID,
                            MarkaID = marka.MarkaID,
                            //SatisFiyati = Data.SatisFiyati,
                            UrunAdi = Data.UrunAdi.Trim()
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
        public static bool Guncelle(VMUrun Data)
        {
            using (MMDB db = new MMDB())
            {
                try
                {
                    var kampanya = db.Kampanya.FirstOrDefault(p => p.KampanyaAdi == Data.Kampanya);
                    var kategori = db.Kategoriler.FirstOrDefault(p => p.KategoriAdi == Data.Kategoriler);
                    var marka = db.Marka.FirstOrDefault(p => p.MarkaAdi == Data.Marka);
                    var bul = db.Urun.FirstOrDefault(p => p.Barkod == Data.Barkod.Trim());
                    //bul.Adet = Data.Adet;
                    //bul.AlisFiyati = Data.AlisFiyati;
                    bul.Barkod = Data.Barkod.Trim();
                    //bul.Gramaji = Data.Gramaji;
                    bul.KampanyaID = kampanya.KampanyaID;
                    bul.KategorilerID = kategori.KategorilerID;
                    bul.MarkaID = marka.MarkaID;
                    //bul.SatisFiyati = Data.SatisFiyati;
                    bul.UrunAdi = Data.UrunAdi.Trim();
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public static bool Sil(VMUrun data)
        {
            using (MMDB db = new MMDB())
            {
                try
                {
                    var bul = db.Urun.FirstOrDefault(p => p.Barkod == data.Barkod.Trim());
                    db.Urun.Remove(bul);
                    db.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        public static List<VMUrun> Liste()
        {
            using (MMDB db = new MMDB())
            {
                return db.Urun.Select(p => new VMUrun
                {
                    //Adet = p.Adet,
                    //AlisFiyati = p.AlisFiyati,
                    Barkod = p.Barkod,
                    //Gramaji = p.Gramaji,
                    Kampanya = p.Kampanya.KampanyaAdi,
                    //KampanyaID = p.KampanyaID,
                    Kategoriler = p.Kategoriler.KategoriAdi,
                    //KategorilerID = p.KategorilerID,
                    Marka = p.Marka.MarkaAdi,
                    //MarkaID = p.MarkaID,
                    //SatisFiyati = p.SatisFiyati,
                    UrunAdi = p.UrunAdi,
                    UrunID = p.UrunID,
                    //SonFiyat = p.SatisFiyati / p.Kampanya.IndirimOrani
                }).ToList();
            }
        }
        public static VMUrun Bul(string barkod)
        {
            using (MMDB db = new MMDB())
            {
                return db.Urun.Where(m=> m.Barkod==barkod).Select(p => new VMUrun
                {
                    //Adet = p.Adet,
                    //AlisFiyati = p.AlisFiyati,
                    Barkod = p.Barkod,
                    //Gramaji = p.Gramaji,
                    Kampanya = p.Kampanya.KampanyaAdi,
                    //KampanyaID = p.KampanyaID,
                    Kategoriler = p.Kategoriler.KategoriAdi,
                    //KategorilerID = p.KategorilerID,
                    Marka = p.Marka.MarkaAdi,
                    //MarkaID = p.MarkaID,
                    //SatisFiyati = p.SatisFiyati,
                    UrunAdi = p.UrunAdi,
                    UrunID = p.UrunID,
                    //SonFiyat = p.SatisFiyati / p.Kampanya.IndirimOrani
                }).FirstOrDefault();
            }
        }
    }
}
