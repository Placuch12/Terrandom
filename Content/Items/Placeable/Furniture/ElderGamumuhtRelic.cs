using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Terrandom.Content.Items.Placeable.Furniture
{
	public class ElderGamumuhtRelic : ModItem
	{
		public override void SetDefaults() {
			Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Furniture.ElderGamumuhtRelic>(), 0);

			Item.width = 30;
			Item.height = 40;
			Item.rare = ItemRarityID.Master;
			Item.master = true;
			Item.value = Item.buyPrice(0, 5);
		}
	}
}