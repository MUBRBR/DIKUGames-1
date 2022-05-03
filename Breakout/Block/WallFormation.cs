using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
using System.Collections.Generic;
using System;
using LevelLoading;

namespace Blocks {
    public class WallFormation : IBlockFormation {
        public EntityContainer<Block> blockContainer {get;}
        private Map map;
        private List<String> mapData;
        private int cols;
        private int rows;
        public WallFormation() {
            Map map = new Map();
            List<String> mapData = map.Reader(Path.Combine(@"C:\Users\Mads-\DIKUGames\Breakout\Assets\Levels\wall.txt"));
            cols = mapData[0].Length;
            rows = mapData.Count;
            int maxBlocks = cols*rows;
            blockContainer = new EntityContainer<Block>(maxBlocks);
           }

        public void CreateBlocks(List<Image> blockColor1, List<Image> blockColor2) {
            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < cols; j++) {
                    blockContainer.AddEntity(
                        new Block(
                        new StationaryShape(
                        new Vec2F(0.0f + (float)j * 1.0f/cols, (1.0f-1.0f/rows)-(float)i * 1.0f/rows), 
                        new Vec2F(1.0f/cols, 1.0f/rows)),
                        new ImageStride(80, blockColor1)));
                }
            }
        }
    }
}