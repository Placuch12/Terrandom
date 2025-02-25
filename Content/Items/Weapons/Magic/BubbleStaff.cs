using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terrandom.Content.Projectiles.Friendly;

namespace Terrandom.Content.Items.Weapons.Magic
{
    public class BubbleStaff : ModItem
    {

        public override void SetStaticDefaults()
        {
            Item.staff[Type] = true;
        }

        public override void SetDefaults()
        {
            Item.damage = 15;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 2;
            Item.width = 28;
            Item.height = 30;
            Item.useTime = 18;
            Item.useAnimation = 18;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.knockBack = 0.5f;
            Item.value = 1000;
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item21;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<BubbleProjectile>();
            Item.shootSpeed = 6f;
        }

        public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.Wood, 10)
				.AddIngredient(ItemID.BottledWater, 3)
				.AddIngredient(ItemID.FallenStar, 1)
				.AddTile(TileID.WorkBenches)
				.Register();
		}
    }
}