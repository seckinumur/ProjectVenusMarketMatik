using MarketMatikDAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace MarketMatikAPI.Guvenlik
{
    public class Yetki : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var Seviye = Roles;
            var Giris = HttpContext.Current.User.Identity.Name;
            var Bul = KullanicilarRepo.KullaniciBul(Giris);
            if (Bul != null && Seviye.Contains(Bul.Yetki))
            {
                
            }
            else
            {
                actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            }
        }
    }
}