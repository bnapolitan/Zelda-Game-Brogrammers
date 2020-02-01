using Microsoft.Xna.Framework.Graphics;

namespace Project3902
{
    // Localized place to load a sprite atlas for any sprites which use it.
    // Not implemented in this project, but it could be used to divide up one massive sprite atlas file
    // into individual SpriteAtlases for separate groups, such as a Link atlas, an enemy Atlas, etc.
    // All SpriteAtlas instances would share one static Texture2D, and would each have their own regions
    // of the large atlas file defined.
    //
    // Right now, it's really just a Texture2D.
    class SpriteAtlas
    {
        public Texture2D Texture { get; set; }

        public SpriteAtlas(Texture2D texture)
        {
            Texture = texture;
        }

    }
}
