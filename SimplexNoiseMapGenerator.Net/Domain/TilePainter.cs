using System.IO;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace SimplexNoiseMapGenerator.Net.Domain
{
  internal class TilePainter
  {
    private readonly IPaintStrategy paintStrategy;

    public TilePainter(IPaintStrategy paintStrategy)
    { 
      this.paintStrategy = paintStrategy;
    }

    public MemoryStream Paint(int zoom, int x, int y)
    {
      var outputStream = new MemoryStream();
      using (var image = new Image<Rgba32>(256, 256))
      {
        paintStrategy.Paint(image, zoom, x, y);
        image.SaveAsPng(outputStream);
      }

      outputStream.Seek(0, SeekOrigin.Begin);
      return outputStream;
    }
  }
}