using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Reactivities.Application.Interfaces;
using Reactivities.Application.Photos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Reactivities.Infraestructure.Photos
{
    public class PhotoFileSystemAccessor : IPhotoAccessor
    {
        private readonly IHostingEnvironment _host;

        public PhotoFileSystemAccessor(IHostingEnvironment host)
        {
            _host = host;
        }
        public PhotoUploadResult AddPhoto(IFormFile file)
        {
            var uploadsFolderPath = Path.Combine(_host.WebRootPath, "Uploads");
            if (!Directory.Exists(uploadsFolderPath))
                Directory.CreateDirectory(uploadsFolderPath);

            var publicId = Guid.NewGuid().ToString();
            var fileName = publicId + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadsFolderPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyToAsync(stream).Wait();
            }

            return new PhotoUploadResult
            {
                PublicId = publicId,
                Url = "http://localhost:5000/wwwroot/Uploads/" + publicId
            };
        }

        public string DeletePhoto(string publicId)
        {
            throw new NotImplementedException();
        }
    }
}
