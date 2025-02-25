using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terrandom.Content.Items.Materials;

namespace Terrandom.Content.Items.Weapons.Melee
{
	public class SappyScythe : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 22;
			Item.DamageType = DamageClass.Melee;
			Item.width = 60;
			Item.height = 60;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 4.5f;
			Item.value = 2500;
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.useTurn = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient<JungleSap>(6)
				.AddIngredient(ItemID.RichMahogany, 25)
				.AddIngredient(ItemID.Stinger, 10)
				.AddTile(TileID.Anvils)
				.Register();
		}

		public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.Poisoned, 2 * 60);
            target.AddBuff(BuffID.Slow, 2 * 60);
        }
	}
}
