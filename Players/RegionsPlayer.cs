using Microsoft.Xna.Framework;
using Regions.Worlds;
using Terraria;
using Terraria.ModLoader;

namespace Regions.Players
{
    public class RegionsPlayer : ModPlayer
    {
        public static RegionsPlayer Get() => Get(Main.LocalPlayer);
        public static RegionsPlayer Get(Player player) => player.GetModPlayer<RegionsPlayer>();


        public void StartDefiningRegion()
        {
            DefiningRegion = true;
            Main.NewText("Started defining region.");
        }

        public void StopDefiningRegion()
        {
            DefiningRegion = false;

            FirstPoint = null;
            SecondPoint = null;
        }

        public void AddPoint(Point point)
        {
            if (!DefiningRegion)
                StartDefiningRegion();

            if (!FirstPoint.HasValue)
                FirstPoint = point;
            else if (!SecondPoint.HasValue)
                SecondPoint = point;

            if (FirstPoint.HasValue && SecondPoint.HasValue)
                mod.GetModWorld<RegionsWorld>().AddRegion(new Region(FirstPoint.Value, SecondPoint.Value));
        }


        public override void ResetEffects()
        {
            HoldingRegionTool = false;
        }

        public override void PreUpdate()
        {
            if (DefiningRegion && !HoldingRegionTool)
                StopDefiningRegion();
        }


        public bool HoldingRegionTool { get; set; }
        public bool DefiningRegion { get; set; }

        public Point? FirstPoint { get; set; }
        public Point? SecondPoint { get; set; }
    }
}