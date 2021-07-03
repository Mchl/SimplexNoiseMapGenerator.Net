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
        [HttpGet]
        public FileStreamResult Get()
        {
            var outputStream = new MemoryStream();
            using (var image = new Image<Rgba32>(128, 128))
            {
                image[0, 0] = Color.Red;
                image[127, 127] = Color.Green;
                image.SaveAsPng(outputStream);
            }

            outputStream.Seek(0, SeekOrigin.Begin);

            return File(outputStream, "image/png");
        }

        // GET: api/Tile/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Tile
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Tile/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Tile/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
