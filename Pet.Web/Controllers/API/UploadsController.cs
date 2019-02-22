using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Pet.Web.Controllers.Api
{
    [Authorize]
    public class UploadsController : ApiController
    {
        private readonly string workingFolder = HttpRuntime.AppDomainAppPath + @"Uploads";

        public IHttpActionResult Get()
        {
            DirectoryInfo photoFolder = new DirectoryInfo(workingFolder);

            List<PhotoViewModel> photos = new List<PhotoViewModel>();

            if (Directory.Exists(workingFolder))
            {
                photos = photoFolder.EnumerateFiles()
                        .Where(fi => new[] { ".jpeg", ".jpg", ".bmp", ".png", ".gif", ".tiff" }
                            .Contains(fi.Extension.ToLower()))
                        .Select(fi => new PhotoViewModel
                        {
                            Name = fi.Name,
                            Created = fi.CreationTime,
                            Modified = fi.LastWriteTime,
                            Size = fi.Length / 1024
                        })
                        .ToList();
            }

            return Ok(new { Photos = photos });
        }


        public async Task<IHttpActionResult> Add()
        {
            if (!Request.Content.IsMimeMultipartContent("form-data"))
            {
                return BadRequest("Unsupported media type");
            }
            try
            {
                var provider = new CustomMultipartFormDataStreamProvider(workingFolder);

                await Request.Content.ReadAsMultipartAsync(provider);

                var photos = new List<PhotoViewModel>();

                foreach (var file in provider.FileData)
                {
                    var fileInfo = new FileInfo(file.LocalFileName);

                    photos.Add(new PhotoViewModel
                    {
                        Name = fileInfo.Name,
                        Created = fileInfo.CreationTime,
                        Modified = fileInfo.LastWriteTime,
                        Size = fileInfo.Length / 1024
                    });
                }
                return Ok(new { Message = "Photos uploaded ok", Photos = photos });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }
        }

        public class CustomMultipartFormDataStreamProvider : MultipartFormDataStreamProvider
        {
            public CustomMultipartFormDataStreamProvider(string rootPath) : base(rootPath)
            {
            }

            public CustomMultipartFormDataStreamProvider(string rootPath, int bufferSize) : base(rootPath, bufferSize)
            {
            }

            public override string GetLocalFileName(HttpContentHeaders headers)
            {
                if (string.IsNullOrWhiteSpace(headers.ContentDisposition.FileName))
                    throw new NotSupportedException();

                string fileName = headers.ContentDisposition.FileName;

                string fileNameExtension = ".jpg";

                return Guid.NewGuid().ToString() + fileNameExtension;
            }
        }

        public class PhotoViewModel
        {
            public string Name { get; set; }
            public DateTime Created { get; set; }
            public DateTime Modified { get; set; }
            public long Size { get; set; }
        }
    }
}