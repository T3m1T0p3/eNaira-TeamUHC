using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace enairaUHC.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController:ControllerBase
    {
        //IApplicationBuilder _builder;
        public HomeController()//IApplicationBuilder app)
        {
            //_builder = app;
        }

        [HttpGet]
        public IActionResult Get()
        {
            /*_builder.UseSwagger();
            _builder.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "enairaUHC v1"));
            _builder.UseRouting();

            _builder.UseAuthorization();

            _builder.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });*/
            return Ok();
        }
    }
}
