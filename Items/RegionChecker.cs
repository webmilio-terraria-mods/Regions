using Regions.Players;
using Regions.Worlds;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Regions.Items
{
    public class RegionChecker : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Special Wooden Axe");
            Tooltip.SetDefault("This wooden axe is special.");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 28;

            item.useTime = 15;
            item.useAnimation = item.useTime;
            item.useStyle = ItemUseStyleID.SwingThrow;

            item.pick = 1;
            item.axe = 1;
            item.hammer = 1;

            item.value = Item.sellPrice(copper: 40);
            item.rare = ItemRarityID.Blue;
        }


        public override bool UseItem(Player player)
        {
            Region region = mod.GetModWorld<RegionsWorld>().GetFirstRegion(player);

            if (region == null)
                return true;

            Main.NewTextMultiline(
                $"Region UUID: {region.UUID}\n" + 
                $"Can Contribute {region.IsContributor(player)}");

            return true;
        }
    }
}