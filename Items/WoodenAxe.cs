using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Regions.Items
{
    public class WoodenAxe : ModItem
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

            item.value = Item.sellPrice(copper: 40);
            item.rare = ItemRarityID.Blue;
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