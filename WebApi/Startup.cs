using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using WebApiSample.Repositories;

namespace WebApiSample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            appBuilder.UseNinjectMiddleware(CreateKernel).UseNinjectWebApi(config);

        }
        private static StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            kernel.Bind<IProductRepository>().To<FakeRepository>();

            return kernel;
        }
    }
}
