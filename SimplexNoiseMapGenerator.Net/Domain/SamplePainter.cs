using System;
using System.IO;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace SimplexNoiseMapGenerator.Net.Domain
{
  public class SamplePainter : ITilePainter
  {
    public MemoryStream Paint(int zoom, int x, int y)
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

      return outputStream;
    }
  }
}