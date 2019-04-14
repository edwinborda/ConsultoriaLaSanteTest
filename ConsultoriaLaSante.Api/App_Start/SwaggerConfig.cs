using System.Web.Http;
using WebActivatorEx;
using ConsultoriaLaSante.Api;
using Swashbuckle.Application;
using Swashbuckle.OData;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace ConsultoriaLaSante.Api
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "ConsultoriaLaSante.Api")
                            .Description("This a techinal test for Consultoria La Santé")
                            .Contact(cc => cc
                                 .Name("Edwin Borda")      
                                 .Email("edwin.borda@outlook.com"))
                            .TermsOfService("Edwin Borda edwin.borda@outlook.com Copyright ©  2019");
                        c.IncludeXmlComments(string.Format(@"{0}\bin\ConsultoriaLaSante.Api.xml",
                          System.AppDomain.CurrentDomain.BaseDirectory));
                        c.CustomProvider(defaultProvider => new ODataSwaggerProvider(defaultProvider, c, GlobalConfiguration.Configuration).Configure(odataConfig =>
                        {
                            odataConfig.IncludeNavigationProperties();
                        }));
                    })
                .EnableSwaggerUi();
        }
    }
}
