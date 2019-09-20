using Terraria.ModLoader;

namespace Regions.Tiles
{
    public class RegionsGlobalTile : GlobalTile
    {
        public override bool CanExplode(int i, int j, int type)
        {
            return base.CanExplode(i, j, type);
        }

        public override bool CanKillTile(int i, int j, int type, ref bool blockDamaged)
        {
            return base.CanKillTile(i, j, type, ref blockDamaged);
        }
    }
}