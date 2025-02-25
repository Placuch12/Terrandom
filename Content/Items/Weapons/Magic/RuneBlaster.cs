using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Enums;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terrandom.Content.Projectiles.Friendly.Runes;

namespace Terrandom.Content.Items.Weapons.Magic
{
    public class RuneBlaster : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.staff[Type] = true;
        }

        public override void SetDefaults()
        {
            Item.damage = 25;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 10;
            Item.width = 28;
            Item.height = 30;
            Item.useTime = 40;
            Item.useAnimation = 40;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 0.5f;
            Item.value = 2500;
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item43;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<RuneR>();
            Item.shootSpeed = 6f;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectile(source, position, velocity.RotatedByRandom(MathHelper.ToRadians(15f)) * (1.1f - Main.rand.NextFloat(0.2f)), ModContent.ProjectileType<RuneU>(), (int)(damage * 1.25f), knockback, player.whoAmI);
            Projectile.NewProjectile(source, position, velocity.RotatedByRandom(MathHelper.ToRadians(15f)) * (1.2f - Main.rand.NextFloat(0.2f)), ModContent.ProjectileType<RuneN>(), damage, knockback * 1.25f, player.whoAmI);
            Projectile.NewProjectile(source, position, velocity.RotatedByRandom(MathHelper.ToRadians(15f)) * (1.1f - Main.rand.NextFloat(0.2f)), ModContent.ProjectileType<RuneE>(), damage, knockback, player.whoAmI);
            return true;
        }
    }
}