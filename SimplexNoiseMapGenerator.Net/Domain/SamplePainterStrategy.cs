using System;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace SimplexNoiseMapGenerator.Net.Domain
{
  public class SamplePainterStrategy : IPaintStrategy
  {
    public void Paint(Image<Rgba32> image, int zoom, int x, int y)
    {
      for (var i = 0; i <= 255; i++)
      {
        for (var j = 0; j <= 255; j++)
        {
          image[i,j] = new Rgba32(Convert.ToByte(j), Convert.ToByte(i), Convert.ToByte((i+j)/2), 255);
        }
      }
    }
  }
  
}