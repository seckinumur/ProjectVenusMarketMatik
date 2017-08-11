using MarketMatikDAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Security;

namespace MarketMatikAPI.Guvenlik
{
    public class GuvenlikKey : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //var Benzersiz = request.RequestUri.ParseQueryString();  Bu Kodlar Url İle Key Gönderir
            //var key = Benzersiz["Key"];
            var key = request.Headers.GetValues("Benzersiz").FirstOrDefault();
            var user = KullanicilarRepo.OturumAc(key);
            if(user != null && user.Yetki=="Admin")
            {
                var Giris = new ClaimsPrincipal(new GenericIdentity(user.Benzersiz.ToString(), "Benzersiz"));
                HttpContext.Current.User = Giris;
            }
            
            return base.SendAsync(request, cancellationToken);
        }
    }
}