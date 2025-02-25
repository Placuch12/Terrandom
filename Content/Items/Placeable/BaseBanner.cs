using Terrandom.Content.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Terrandom.Content.Items.Placeable
{
    public abstract class BaseBanner : ModItem, ILocalizedModType
    {
        public virtual int BannerTileID => ModContent.TileType<Banner>();
        public virtual int BannerTileStyle => 0;
        public virtual int BannerKillRequirement => ItemID.Sets.DefaultKillsForBannerNeeded;

        public virtual int BonusNPCID => Banner.GetBannerNPC(BannerTileStyle);

        public new string LocalizationCategory => "Items.Placeable";

        public override void SetStaticDefaults() => ItemID.Sets.KillsToBanner[Type] = BannerKillRequirement;
        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(BannerTileID, BannerTileStyle);

            Item.width = 10;
            Item.height = 24;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(silver: 2);
        }
    }
}