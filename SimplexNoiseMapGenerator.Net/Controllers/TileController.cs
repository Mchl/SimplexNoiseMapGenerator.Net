using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace SimplexNoiseMapGenerator.Net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TileController : ControllerBase
    {
        // GET: api/Tile
        [HttpGet("{z}/{x}/{y}")]
        public FileStreamResult Get()
        {
            var outputStream = new MemoryStream();
            using (var image = new Image<Rgba32>(256, 256))
            {
                for (var i = 0; i <= 255; i++)
                {
                    for (var j = 0; j <= 255; j++)
                    {
                        image[i,j] = new Rgba32(Convert.ToByte(j), Convert.ToByte(i), Convert.ToByte((i+j)/2), 255);
                    }
                }
                
                image.SaveAsPng(outputStream);
            }

            outputStream.Seek(0, SeekOrigin.Begin);

            return File(outputStream, "image/png");
        }
    }
}
