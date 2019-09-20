using Microsoft.Xna.Framework;

namespace Regions.World
{
    public class Region
    {
        public Region(Point first, Point second)
        {
            int
                lowestX = first.X < second.X ? first.X : second.X,
                lowestY = first.Y > second.Y ? first.Y : second.Y, // The further down you go, the higher the Y.
                
                highestX = second.X > first.X ? second.X : first.X,
                highestY = second.Y < first.Y ? second.Y : first.Y;

            Surface = new Rectangle(lowestX, highestY, highestX - lowestX, lowestY - highestY);
        }


        public Rectangle Surface { get; }
    }
}