using LevelLoading;
using DIKUArcade;
using DIKUArcade.Entities;

using DIKUArcade.Graphics;

namespace Blocks {
    public class Block : Entity {
        private int hitpoints;
        private StationaryShape shape;
        private Entity entity;
        private List<Image> BlockColor;
        private List<Image> damagedBlock;
        public Block (StationaryShape shape, IBaseImage image)
            : base(shape, image) {
                hitpoints = 2;
                Image = image;
                this.shape = shape;
                entity = new Entity(shape, image);
        }
        public void TakeDamage() {
            hitpoints --;
        }
        public bool IsDead() {
            if (hitpoints <= 0) {
                return true;
            }
            else {
                return false;
            }
        }
        public bool Enraged() {
            switch (hitpoints) {
                case (<= 1):
                    return true;
                default:
                    return false;
            }
        }
    }
}