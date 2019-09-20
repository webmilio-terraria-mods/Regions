using Microsoft.Xna.Framework;
using Regions.Players;
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

            if (player == null || Vector2.Distance(player.Center, new Vector2(i, j)) < 20)
                return true;

            RegionsPlayer regionsPlayer = RegionsPlayer.Get();

            if (regionsPlayer.HoldingRegionTool)
            {
                regionsPlayer.AddPoint(new Point(i, j));
            }

            Main.NewText($"Block hit by found player {regionsPlayer.player.name}");

            return true;
        }
    }
}