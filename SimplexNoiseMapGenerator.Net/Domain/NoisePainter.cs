using System;
using System.IO;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace SimplexNoiseMapGenerator.Net.Domain
{
  public class NoisePainter : ITilePainter
  {
    public MemoryStream Paint(int zoom, int x, int y)
    {
      var outputStream = new MemoryStream();
      FastNoiseLite noiseGenerator = new FastNoiseLite();
      noiseGenerator.SetNoiseType(FastNoiseLite.NoiseType.OpenSimplex2);
      var zoomFactor = Convert.ToSingle(Math.Pow(2, -zoom));
      using (var image = new Image<Rgba32>(256, 256))
      {
        for (var i = 0; i <= 255; i++)
        {
          for (var j = 0; j <= 255; j++)
          {
            float noise = noiseGenerator.GetNoise((x * 256 + i) * zoomFactor, (y * 256 + j) * zoomFactor) * 127 + 128;
            image[i, j] = new Rgba32(Convert.ToByte(noise), Convert.ToByte(noise), Convert.ToByte(noise), 255);
          }
        }
                
        image.SaveAsPng(outputStream);
      }

      outputStream.Seek(0, SeekOrigin.Begin);

      return outputStream;
    }
  }
}