using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace Terrandom.Content.Items.Weapons.Melee
{
	public class BorealWoodClub : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 11;
			Item.DamageType = DamageClass.Melee;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 34;
			Item.useAnimation = 34;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 9f;
			Item.value = 30;
			Item.rare = ItemRarityID.White;
			Item.UseSound = SoundID.Item1;
			Item.useTurn = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.BorealWood, 12)
				.AddTile(TileID.WorkBenches)
				.Register();
		}
	}
}
