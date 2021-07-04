using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using SimplexNoiseMapGenerator.Net.Domain;


namespace SimplexNoiseMapGenerator.Net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TileController : ControllerBase
    {
        // GET: api/Tile
        [HttpGet("{zoom}/{x}/{y}")]
        public FileStreamResult Get(int zoom, int x, int y)
        {
            var painter = new NoisePainter();
            return File(painter.Paint(zoom, x, y), "image/png");
        }
    }
}
