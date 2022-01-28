using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileInterface : ControllerBase
    {

        private readonly IWebHostEnvironment env;

        public FileInterface(IWebHostEnvironment env)
        {
            this.env = env;
        }

        // POST api/FileInterface
        // takes in a post request and looks for files. If there are files, stores them in database.
        [HttpPost]
        public async void Post()
        {
            List<IFormFile> files = new List<IFormFile>();
            files = HttpContext.Request.Form.Files.ToList();
            if (files.Count > 0)
            {
                foreach(IFormFile file in files)
                {
                    string path = Path.Combine(env.ContentRootPath, "uploads", file.FileName);
                    using (FileStream stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream); // this just puts the file into memory
                        //TODO: upload file to database. 
                    }
                }
            }
        }


    }
}
