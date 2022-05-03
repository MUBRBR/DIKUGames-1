using DIKUArcade.Entities;
using DIKUArcade.Graphics;


namespace Blocks {
    public interface IBlockFormation {
        EntityContainer<Block> blockContainer {get;}

        void CreateBlocks (List<Image> blockColor,
            List<Image> blockColorDamaged);
    }
}