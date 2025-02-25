using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terrandom.Content.Projectiles.Friendly;
using Terrandom.Content.Items.Materials;

namespace Terrandom.Content.Items.Weapons.Magic
{
    public class IcicleStaff : ModItem
    {

        public override void SetStaticDefaults()
        {
            Item.staff[Type] = true;
        }

        public override void SetDefaults()
        {
            Item.damage = 23;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 9;
            Item.width = 48;
            Item.height = 48;
            Item.useTime = 28;
            Item.useAnimation = 28;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 4f;
            Item.value = 1000;
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item8;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<IcicleProjectile>();
            Item.shootSpeed = 7f;
        }

        public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient<FrozenDroplet>(4)
				.AddIngredient(ItemID.Shiverthorn, 5)
				.AddIngredient(ItemID.FallenStar, 5)
				.AddTile(TileID.Anvils)
				.Register();
		}
    }
}