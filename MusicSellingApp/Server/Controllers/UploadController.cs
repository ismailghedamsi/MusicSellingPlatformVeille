using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyTested.AspNetCore.Mvc.Utilities.Extensions;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWasmTests.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly IWebHostEnvironment environment;
        public UploadController(IWebHostEnvironment environment)
        {
            this.environment = environment;
        }

            [HttpGet]
            public byte[] GetData()
            {
                var path = Path.Combine(environment.ContentRootPath, "uploads", "mymusic.rar");
            
            FileStream stream = System.IO.File.OpenRead(path);
            Console.WriteLine("controller byte legtnh "+stream.ToByteArray().Length);
            return  stream.ToByteArray();
            }


        [HttpPost]
        public async Task Post()
        {
            if (HttpContext.Request.Form.Files.Any())
            {
                foreach (var file in HttpContext.Request.Form.Files)
                {
                    var path = Path.Combine(environment.ContentRootPath, "uploads", file.FileName);
                    Console.WriteLine(path);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
            }
        }
    }
}