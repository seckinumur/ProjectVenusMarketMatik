using MarketMatikAPI.Guvenlik;
using MarketMatikDAL.Repo;
using MarketMatikDAL.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace MarketMatikAPI.Controllers
{
    [EnableCors("*", "*", "*")] //Başka Yerdende Bağlan
    
    public class KategoriController : ApiController
    {

        [ResponseType(typeof(List<VMKategori>))]
        public IHttpActionResult Get() //Kategoriler Ajax ile çektik
        {
            var liste = KategoriRepo.Liste();
            return Ok(liste);
        }
        
        [ResponseType(typeof(VMKategori))]
        public IHttpActionResult Get(int id) //Sadece O barkod Numaralı Ürünü Çektik
        {
            var Liste = KategoriRepo.Bul(id);
            if (Liste == null)
            {
                return NotFound();
            }
            return Ok(Liste);
        }
      
      
        public IHttpActionResult Post(VMKategori data) //Kategori Kaydettik
        {
            if (ModelState.IsValid)
            {
                bool durum = KategoriRepo.Ekle(data);
                if (durum == true)
                {
                    return CreatedAtRoute("DefaultApi", new { id = data.KategorilerID }, durum);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        
      
        public IHttpActionResult Put(VMKategori data) //Kategori Duzenledik
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            else
            {
                bool sonuc = KategoriRepo.Guncelle(data);
                if (sonuc != true)
                {
                    return NotFound();
                }
                else
                {
                    return Ok();
                }
            }
        }
        
        
        public IHttpActionResult Delete(VMKategori data) //Kategori Sildik
        {
            bool sonuc = KategoriRepo.Sil(data);
            if (sonuc != true)
            {
                return NotFound();
            }
            else
            {
                return Ok();
            }
        }
    }
}
