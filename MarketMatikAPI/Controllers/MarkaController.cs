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
    public class MarkaController : ApiController
    {
        [ResponseType(typeof(List<VMMArka>))]
        public IHttpActionResult Get() //Marka Ajax ile çektik
        {
            var liste = MarkaRepo.Liste();
            return Ok(liste);
        }

        [ResponseType(typeof(VMMArka))]
        public IHttpActionResult Get(int id) //Sadece O barkod Numaralı Ürünü Çektik
        {
            var Liste = MarkaRepo.Bul(id);
            if (Liste == null)
            {
                return NotFound();
            }
            return Ok(Liste);
        }


        public IHttpActionResult Post(VMMArka data) //Marka Kaydettik
        {
            if (ModelState.IsValid)
            {
                bool durum = MarkaRepo.Ekle(data);
                if (durum == true)
                {
                    return CreatedAtRoute("DefaultApi", new { id = data.MarkaID }, durum);
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


        public IHttpActionResult Put(VMMArka data) //Marka Duzenledik
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            else
            {
                bool sonuc = MarkaRepo.Guncelle(data);
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


        public IHttpActionResult Delete(VMMArka data) //Marka Sildik
        {
            bool sonuc = MarkaRepo.Sil(data);
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
