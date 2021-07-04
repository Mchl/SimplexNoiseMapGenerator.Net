using System.IO;

namespace SimplexNoiseMapGenerator.Net.Domain
{
  interface ITilePainter
  {
    public MemoryStream Paint(int zoom, int x, int y);
  }
}