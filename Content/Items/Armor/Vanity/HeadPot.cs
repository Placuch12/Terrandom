using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Terrandom.Content.Items.Armor.Vanity
{
	[AutoloadEquip(EquipType.Head)]
	public class HeadPot : ModItem
	{
		public override void SetDefaults() {
			Item.width = 22;
			Item.height = 28;

			Item.rare = ItemRarityID.Blue;
			Item.value = Item.sellPrice(silver: 25);
			Item.vanity = true;
			Item.maxStack = 1;
			ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true;
		}

		public override void AddRecipes() {
			CreateRecipe()
				.AddRecipeGroup(RecipeGroupID.IronBar, 5)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}