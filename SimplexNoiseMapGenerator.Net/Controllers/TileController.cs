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
        private readonly TilePainter tilePainter;

        public TileController()
        {
            IPaintStrategy painterStrategy = new NoisePainterStrategy();
            tilePainter = new TilePainter(painterStrategy);
        }
        
        // GET: api/Tile
        [HttpGet("{zoom}/{x}/{y}")]
        public FileStreamResult Get(int zoom, int x, int y)
        {
            return File(tilePainter.Paint(zoom, x, y), "image/png");
        }
    }
}
