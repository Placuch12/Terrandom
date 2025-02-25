using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terrandom.Content.Projectiles.Friendly;

namespace Terrandom.Content.Items.Weapons.Ranged
{
	public class SpikyCactus : ModItem
	{
		public override void SetStaticDefaults() {
			ItemID.Sets.ItemsThatCountAsBombsForDemolitionistToSpawn[Type] = true;
			Item.ResearchUnlockCount = 49; 
		}

		public override void SetDefaults() {
			Item.useStyle = ItemUseStyleID.Swing;
			Item.shootSpeed = 8f;
			Item.shoot = ModContent.ProjectileType<SpikyCactusProjectile>();
			Item.width = 30;
			Item.height = 28;
			Item.maxStack = Item.CommonMaxStack;
			Item.consumable = true;
			Item.UseSound = SoundID.Item1;
			Item.useAnimation = 30;
			Item.useTime = 30;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.value = Item.buyPrice(0, 0, 20, 0);
			Item.rare = ItemRarityID.Blue;
		}

		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient(ItemID.Cactus)
				.AddIngredient(ItemID.Grenade)
				.AddTile(TileID.WorkBenches)
				.Register();
		}
	}
}