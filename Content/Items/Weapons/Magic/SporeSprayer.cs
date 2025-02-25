using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terrandom.Content.Projectiles.Friendly;
using Microsoft.Xna.Framework;
using System;
using Terraria.Enums;
using Terraria.DataStructures;

namespace Terrandom.Content.Items.Weapons.Magic
{
    public class SporeSprayer : ModItem
    {

        public override void SetStaticDefaults()
        {
            Item.staff[Type] = true;
        }

        public override void SetDefaults()
        {
            Item.damage = 11;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 2;
            Item.width = 28;
            Item.height = 30;
            Item.useTime = 7;
            Item.useAnimation = 7;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 0.5f;
            Item.value = 2000;
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item21;
            Item.shoot = ModContent.ProjectileType<Spore>();
            Item.autoReuse = true;
            Item.shootSpeed = 7f;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectile(source, position, velocity.RotatedByRandom(MathHelper.ToRadians(15f)), ModContent.ProjectileType<Spore>(), damage, knockback, player.whoAmI);
            return false;
        }

        public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.JungleSpores, 20)
				.AddIngredient(ItemID.Vine, 2)
				.AddIngredient(ItemID.BeeWax, 5)
				.AddTile(TileID.WorkBenches)
				.Register();
		}
    }
}