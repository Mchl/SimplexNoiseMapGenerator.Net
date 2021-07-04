using System.IO;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace SimplexNoiseMapGenerator.Net.Domain
{
  class TilePainter
  {
    public TilePainter(IPaintStrategy paintStrategy)
    { 
      PaintStrategy = paintStrategy;
    }

    private IPaintStrategy PaintStrategy;

    public MemoryStream Paint(int zoom, int x, int y)
    {
      var outputStream = new MemoryStream();
      using (var image = new Image<Rgba32>(256, 256))
      {
        PaintStrategy.Paint(image, zoom, x, y);
        image.SaveAsPng(outputStream);
      }

      outputStream.Seek(0, SeekOrigin.Begin);
      return outputStream;
    }
  }
}