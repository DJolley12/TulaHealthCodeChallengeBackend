using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace TulaHealthCodeChallenge.Pages
{
    public partial class FileUpload
    {
        private IHostingEnvironment _environment;
        [Inject]
        public HttpClient HttpClient { get; set; }
        [BindProperty]
        public IFormFile UploadFile { get; set; }
        public bool UploadComplete { get; set; }
        public async Task ParseCSV()
        {
            UploadComplete = true;
        }
    }
}
