﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitals.Utilities
{
    public class ImageOperations
    {
        IWebHostEnvironment _env;

        public ImageOperations(IWebHostEnvironment env)
        {
            _env = env;
        }

        public string ImageUpload (IFormFile file)
        {
            string filename = null;
            if(file!=null)
            {
                string fileDirectory = Path.Combine(_env.WebRootPath, "Images"); ;
                filename = Guid.NewGuid() + "-" + file.FileName;
                string filePath = Path.Combine(fileDirectory,filename);
                using(FileStream fs = new FileStream(filePath,FileMode.Create))
                {
                    file.CopyToAsync(fs);
                }
            }
            return filename;
        }
    }
}