using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using WebmilioCommons.Extensions;

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
            Player player = new Vector2(i, j).GetNearestMiningPlayer();
            Main.NewText($"Block hit by found player {player.name}");

            return true;
        }
    }
}