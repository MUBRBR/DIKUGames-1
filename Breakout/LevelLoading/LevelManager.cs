using Blocks;
using DIKUArcade.Entities;
using DIKUArcade.Math;
using DIKUArcade.Graphics;
using System;
namespace LevelLoading {
    public class LevelManager {
        private Meta meta;
        private Legend legend = new Legend();
        private Map map = new Map();
        private List<Tuple<String, String>> legendData = new List<Tuple<String, String>>();
        public LevelManager() {
            // List<Tuple<String, String>> legendData = new List<Tuple<String, String>>();
            // int cols = 0;
            // int rows = 0;
            // int maxBlocks = cols*rows;
            // blockColor = new List<Image>();
            // blockContainer = new EntityContainer<Block>(maxBlocks);
        }
        
        public EntityContainer<Block> levelLoader(String fileName) {
            List<Image> blockColor = new List<Image>();
            

            EntityContainer<Block> returnvalue = new EntityContainer<Block>();
            List<String> mapData = map.Reader(fileName);
            legendData = legend.Reader(fileName);
            int cols = mapData[0].Length;
            int rows = mapData.Count;
            List<Char> ascii = new List<Char>();
            for (int i = 0; i < legendData.Count; i++) {
                Char charAscii = legendData[i].Item1[0];
                ascii.Add(charAscii);
            }
            
            int k = 0;
            foreach (String line in mapData) {
                int j = 0;
                foreach (Char c in line) {
                    for (int i = 0; i < legendData.Count; i++) {
                        if (c == ascii[i]) {
                            blockColor = ImageStride.CreateStrides(1, Path.Combine("Assets", "Images", legendData[i].Item2));
                        i++;
                        }
                    }
                    if (c != '-') {
                    returnvalue.AddEntity(
                        new Block(
                        new StationaryShape(
                        new Vec2F(0.0f + (float)j * 1.0f/cols, 
                                (1.0f-1.0f/rows)-(float)k * 1.0f/rows), 
                        new Vec2F(1.0f/cols, 1.0f/rows)),
                        new ImageStride(80, blockColor)));
                    }
                    j++;
                }
                k++;
            }
            System.Console.WriteLine($"levelhandler antal{returnvalue.CountEntities()}");
            return returnvalue;
        }
    }
}