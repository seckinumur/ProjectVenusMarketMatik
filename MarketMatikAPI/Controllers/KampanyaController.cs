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
    public class KampanyaController : ApiController
    {
        [ResponseType(typeof(List<VMKampanya>))]
        public IHttpActionResult Get() //Kampanya Ajax ile çektik
        {
            var liste = KampanyaRepo.Liste();
            return Ok(liste);
        }

        [ResponseType(typeof(VMKampanya))]
        public IHttpActionResult Get(int id) //Sadece O barkod Numaralı Ürünü Çektik
        {
            var Liste = KampanyaRepo.Bul(id);
            if (Liste == null)
            {
                return NotFound();
            }
            return Ok(Liste);
        }


        public IHttpActionResult Post(VMKampanya data) //Kampanya Kaydettik
        {
            if (ModelState.IsValid)
            {
                bool durum = KampanyaRepo.Ekle(data);
                if (durum == true)
                {
                    return CreatedAtRoute("DefaultApi", new { id = data.KampanyaID }, durum);
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


        public IHttpActionResult Put(VMKampanya data) //Kampanya Duzenledik
        {

            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            else
            {
                bool sonuc = KampanyaRepo.Guncelle(data);
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


        public IHttpActionResult Delete(VMKampanya data) //Kampanya Sildik
        {
            bool sonuc = KampanyaRepo.Sil(data);
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
