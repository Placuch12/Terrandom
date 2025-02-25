using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Terrandom.Content.Items.Armor.Vanity
{
	[AutoloadEquip(EquipType.Head)]
	public class Voxelmask : ModItem
	{
		public override void SetDefaults() {
			Item.width = 22;
			Item.height = 28;

			Item.rare = ItemRarityID.Blue;
			Item.value = Item.sellPrice(silver: 75);
			Item.vanity = true;
			Item.maxStack = 1;
		}

		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient(ItemID.BlackThread, 1)
				.AddIngredient(ItemID.BlackLens, 2)
				.AddIngredient(ItemID.MarbleBlock, 20)
				.AddTile(TileID.Loom)
				.Register();
		}
	}
}