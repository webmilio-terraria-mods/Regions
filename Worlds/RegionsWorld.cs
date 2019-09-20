using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Regions.Worlds
{
    public class RegionsWorld : ModWorld
    {
        private List<Region> _regions = new List<Region>();


        public void AddRegion(Region region) => _regions.Add(region);


        public override void PostDrawTiles()
        {
            foreach (Region region in _regions)
            {
                Main.spriteBatch.Begin();
                Main.spriteBatch.Draw(Main.magicPixel, new Rectangle((int)((region.Surface.X * 16) - Main.screenPosition.X), (int)(region.Surface.Y * 16 - Main.screenPosition.Y), region.Surface.Width * 16, region.Surface.Height * 16), Color.Red);
                Main.spriteBatch.End();
            }

            base.PostDrawTiles();
        }


        public override void Load(TagCompound tag)
        {
            
        }

        public override TagCompound Save()
        {
            return new TagCompound();
        }
    }
}