using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Terrandom.Content.Items.Placeable.Furniture
{
	public class BoldAndBrash : ModItem
	{
		public override void SetDefaults() {
			Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Furniture.BoldAndBrash>());

			Item.width = 32;
			Item.height = 32;
			Item.rare = ItemRarityID.Blue;
			Item.value = Item.buyPrice(0, 5);
		}
	}
}