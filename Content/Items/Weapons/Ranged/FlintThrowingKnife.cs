using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terrandom.Content.Projectiles.Friendly;
using Terrandom.Content.Items.Materials;

namespace Terrandom.Content.Items.Weapons.Ranged
{
	public class FlintThrowingKnife : ModItem
	{
		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 99;
		}

		public override void SetDefaults()
		{
			Item.DefaultToThrownWeapon(ModContent.ProjectileType<FlintThrowingKnifeProjectile>(), 14, 10);
			Item.SetWeaponValues(12, 2.5f, 4);
			Item.SetShopValues(ItemRarityColor.Blue1, Item.sellPrice(0, 0, 0, 50));

			Item.width = 32;
			Item.height = 32;
			Item.UseSound = SoundID.Item1;
			Item.noUseGraphic = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe(150)
				.AddIngredient<Flint>()
				.AddIngredient(ItemID.TungstenBar, 3)
				.AddTile(TileID.Anvils)
				.Register();

			CreateRecipe(150)
				.AddIngredient<Flint>()
				.AddIngredient(ItemID.SilverBar, 3)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}