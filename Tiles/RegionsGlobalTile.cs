using Microsoft.Xna.Framework;
using Regions.Players;
using Terraria;
using Terraria.ModLoader;
using WebmilioCommons.Extensions;
using WebmilioCommons.Tiles;

namespace Regions.Tiles
{
    public class RegionsGlobalTile : BetterGlobalTile
    {
        public override bool CanExplode(int i, int j, int type)
        {
            return base.CanExplode(i, j, type);
        }

        public override bool CanPlayerKillTile(Player player, int i, int j, int type, ref bool blockDamaged)
        {
            if (player == null)
                return true;

            RegionsPlayer regionsPlayer = RegionsPlayer.Get(player);

            if (regionsPlayer.HoldingRegionTool)
                regionsPlayer.AddPoint(new Point(i, j));

            Main.NewText($"Block hit ({i}, {j})/({i * 16}, {j * 16}) by found player {regionsPlayer.player.name}");
            return true;
        }
    }
}