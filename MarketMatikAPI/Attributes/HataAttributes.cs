using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace MarketMatikAPI.Attributes
{
    public class HataAttributes : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            HttpResponseMessage Hatamesaji = new HttpResponseMessage(System.Net.HttpStatusCode.NotImplemented);
            Hatamesaji.ReasonPhrase = actionExecutedContext.Exception.Message;
            actionExecutedContext.Response = Hatamesaji;
            base.OnException(actionExecutedContext);
        }
    }
}