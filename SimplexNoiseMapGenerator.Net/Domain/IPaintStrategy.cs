using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace SimplexNoiseMapGenerator.Net.Domain
{
  internal interface IPaintStrategy
  {
    IImage Paint(Image<Rgba32> image, int zoom, int x, int y);
  }
}