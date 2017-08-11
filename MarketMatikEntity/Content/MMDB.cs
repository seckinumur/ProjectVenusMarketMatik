namespace MarketMatikEntity.Content
{
    using MarketMatikEntity.Model;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MMDB : DbContext
    {
        public MMDB()
            : base("name=MMDB")
        {
            Database.SetInitializer(new MMDBInitializer());
        }
        public virtual DbSet<Urun> Urun { get; set; }
        public virtual DbSet<Kullanicilar> Kullanicilar { get; set; }
        public virtual DbSet<Kategoriler> Kategoriler { get; set; }
        public virtual DbSet<Kampanya> Kampanya { get; set; }
        public virtual DbSet<Marka> Marka { get; set; }

        public class MMDBInitializer : CreateDatabaseIfNotExists<MMDB> //Otomatik database Olu�turma
        {
            protected override void Seed(MMDB db)
            {
                db.Kullanicilar.Add(new Kullanicilar { Email = "Admin", Sifre = "9916", Yetki = "Admin" });
                db.SaveChanges();
                db.Kullanicilar.Add(new Kullanicilar { Email = "demo@demo.com", Sifre = "1234", Yetki = "Kasiyer" });
                db.SaveChanges();

                db.Kategoriler.Add(new Kategoriler { KategoriAdi = "S�t �r�nleri" });
                db.SaveChanges();

                db.Marka.Add(new Marka { MarkaAdi = "S�ta�" });
                db.SaveChanges();

                db.Kampanya.Add(new Kampanya { IndirimOrani = 10, KampanyaAdi = "Ho�geldin Kampanyas�" });
                db.SaveChanges();

                db.Urun.Add(new Urun
                {
                    //Adet = 10,
                    //AlisFiyati = 1.90,
                    Barkod = "1234",
                    //Gramaji = 500,
                    KampanyaID = 1,
                    KategorilerID = 1,
                    MarkaID = 1,
                    //SatisFiyati = 2.250,
                    UrunAdi = "S�ta� 500gr Do�al Yo�urt"
                });
                db.SaveChanges();
            }
        }
    }
}