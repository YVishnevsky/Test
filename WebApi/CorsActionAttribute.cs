using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebApiSample
{
    public class CorsActionAttribute : Attribute, IActionFilter
    {
        public bool AllowMultiple { get { return false; } }

        public async Task<HttpResponseMessage> ExecuteActionFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {
            HttpResponseMessage response = await continuation();
            response.Headers.Add("Access-Control-Allow-Origin", "http://google.com");
            return response;
        }
    }
}    
    
