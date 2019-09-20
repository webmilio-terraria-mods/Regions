using Regions.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Regions.Items
{
    public class WoodenAxe : ModItem, IRegionTool
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


        public override void HoldItem(Player player)
        {
            if (Main.LocalPlayer == player)
                RegionsPlayer.Get(player).HoldingRegionTool = true;
        }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddRecipeGroup("Wood");

            recipe.SetResult(mod.GetItem<WoodenAxe>());
            recipe.AddTile(TileID.WorkBenches);

            recipe.AddRecipe();
        }
    }
}