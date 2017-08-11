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
   public class KullanicilarRepo
    {
        public static string Ekle(VMKullanicilar Data)
        {
            using (MMDB db = new MMDB())
            {
                try
                {
                    bool bul = db.Kullanicilar.Any(p => p.Email == Data.Email.Trim());
                    if (bul != true)
                    {
                        db.Kullanicilar.Add(new Kullanicilar()
                        {
                            Email = Data.Email.Trim(),
                            Sifre = Data.Sifre.Trim(),
                            Yetki = Data.Yetki.Trim()
                        });
                        db.SaveChanges();
                        return "Kullanicilar Başarıyla Eklendi";
                    }
                    else
                    {
                        return "Kullanicilar Daha Önceden Kaydedilmiş";
                    }
                }
                catch
                {
                    return "Kullanicilar Kaydetme İşlemi Başarılı Olamadı.";
                }
            }
        }
        public static string Guncelle(VMKullanicilar Data)
        {
            using (MMDB db = new MMDB())
            {
                try
                {
                    var bul = db.Kullanicilar.FirstOrDefault(p => p.Email == Data.Email.Trim());
                    bul.Email = Data.Email.Trim();
                    bul.Sifre = Data.Sifre.Trim();
                    bul.Yetki = Data.Yetki.Trim();
                    db.SaveChanges();
                    return "Kullanicilar Başarrıyla Guncellendi";
                }
                catch
                {
                    return "Kullanicilar Guncelleme İşlemi Başarılı Olamadı.";
                }
            }
        }
        public static string Sil(VMKullanicilar Data)
        {
            using (MMDB db = new MMDB())
            {
                try
                {
                    var bul = db.Kullanicilar.FirstOrDefault(p => p.Email == Data.Email.Trim());
                    db.Kullanicilar.Remove(bul);
                    db.SaveChanges();
                    return "Kullanicilar Başarrıyla Silindi";
                }
                catch
                {
                    return "Kullanicilar Silme İşlemi Başarılı Olamadı.";
                }
            }
        }
        public static VMKullanicilar OturumAc(string key)
        {
            using (MMDB db = new MMDB())
            {
              return db.Kullanicilar.Where(p => p.Benzersiz.ToString() == key).Select(n=> new VMKullanicilar {Benzersiz= n.Benzersiz,Email=n.Email,Sifre=n.Sifre,Yetki=n.Yetki }).FirstOrDefault();  
            }
        }
        public static Kullanicilar OturumAcHizli(VMKullanicilar Data)
        {
            using (MMDB db = new MMDB())
            {
                return db.Kullanicilar.FirstOrDefault(p => p.Email == Data.Email && p.Sifre == Data.Sifre);
            }
        }
        public static VMKullanicilar KullaniciBul(string Benzersiz)
        {
            using (MMDB db = new MMDB())
            {
                return db.Kullanicilar.Where(p => p.Benzersiz.ToString() == Benzersiz).Select(n => new VMKullanicilar { Benzersiz = n.Benzersiz, Email = n.Email, Sifre = n.Sifre, Yetki = n.Yetki }).FirstOrDefault();
            }
        }
    }
}
