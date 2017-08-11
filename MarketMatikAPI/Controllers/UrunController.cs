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
    [EnableCors("*","*","*")] //Başka Yerdende Bağlan
    public class UrunController : ApiController
    {
        [ResponseType(typeof(List<VMUrun>))]
        public IHttpActionResult Get() //Ürün Ajax ile çektik
        {
            var liste = UrunRepo.Liste();
            return Ok(liste);
        }

        [ResponseType(typeof(VMUrun))]
        public IHttpActionResult Get(string Barkod) //Sadece O barkod Numaralı Ürünü Çektik
        {
            var Liste = UrunRepo.Bul(Barkod);
            if (Liste == null)
            {
                return NotFound();
            }
            return Ok(Liste);
        }


        public IHttpActionResult Post(VMUrun data) //Ürün Kaydettik
        {
            if (ModelState.IsValid)
            {
                bool durum = UrunRepo.Ekle(data);
                if (durum == true)
                {
                    return CreatedAtRoute("DefaultApi", new { id = data.Barkod }, durum);
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


        public IHttpActionResult Put(VMUrun data) //Ürün Duzenledik
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            else
            {
                bool sonuc = UrunRepo.Guncelle(data);
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


        public IHttpActionResult Delete(VMUrun data) //Ürün Sildik
        {
            bool sonuc = UrunRepo.Sil(data);
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
