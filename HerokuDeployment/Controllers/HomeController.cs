using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Net;
using System.Text.Json;
using HerokuDeployment.Models;

namespace HerokuDeployment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [Obsolete]
        private readonly IHostingEnvironment _hostingEnvironment;

        [Obsolete]
        public HomeController(IHostingEnvironment hostingEnvironment) {
            _hostingEnvironment = hostingEnvironment;
        }

        [Route("[action]")]
        [Obsolete]
        public async Task<string> GetAllData() {
           
            string filePath = Path.Combine(_hostingEnvironment.ContentRootPath, "Data", "AppData.json");
            var fi = new FileInfo(filePath);
            var sb = new StringBuilder(); 
            if (fi.Exists) {
                using (var sr = fi.OpenText()) {
                    string s = "";
                    while ((s = await sr.ReadLineAsync()) != null) {
                        sb.AppendLine(s);
                    }
                }
            }

            return sb.ToString();
        }

        [Route("[action]")]
        public async Task AddResponse([FromBody] LineResponse json)
        {
            await WriteFileAsync(JsonConvert.SerializeObject(json));
        }

        [Obsolete]
        private async Task WriteFileAsync(string Data) {
            string filePath = Path.Combine(_hostingEnvironment.ContentRootPath, "Data", "AppData.json");
            var fi = new FileInfo(filePath);
            if (!fi.Exists)
            {
                System.IO.File.Create(filePath);
                fi = new FileInfo(filePath);
            }

            using (var sw = fi.AppendText())
            {
                await sw.WriteLineAsync(Data);
                await sw.WriteLineAsync("");
            }
        }
    }
}