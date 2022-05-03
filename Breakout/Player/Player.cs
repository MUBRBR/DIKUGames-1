using DIKUArcade.Entities;
using DIKUArcade.Graphics;
using DIKUArcade.Events;

namespace Breakout {
    public class Player : IGameEventProcessor {
        private Entity entity;
        private float moveLeft = 0.0f;
        private float moveRight = 0.0f;
        private const float MOVEMENT_SPEED = 0.01f;
        private DynamicShape shape;
        public Player(DynamicShape shape, IBaseImage image) {
            entity = new Entity(shape, image);
            this.shape = shape;
        }
        public void Move() {
            if (shape.Position.X < 0.0f)
            {
                shape.Position.X = 0.00f;
            }
            else if (shape.Position.Y >= 1.0-shape.Extent.Y)
            {
                shape.Position.Y = 1.0f-shape.Extent.Y;
            }
            else if (shape.Position.Y <= 0.0) 
            {
                shape.Position.Y = 0.0000001f;
            }
            else
            {
                shape.AsDynamicShape().Move();
            }
        }
        private void SetMoveLeft(bool val) {
            if (val) 
            {
                moveLeft = MOVEMENT_SPEED*(-1);
            }
            else
            {
                moveLeft = 0.0f;
            }
            UpdateDirection();
        }
        private void SetMoveRight(bool val) {
            if (val)
            {
                moveRight = MOVEMENT_SPEED;
            }
            else
            {
                moveRight = 0.0f;
            }
            UpdateDirection();
        }
        public void ProcessEvent(GameEvent gameEvent) {
            if (gameEvent.EventType == GameEventType.PlayerEvent) {
                switch (gameEvent.Message) {
                    case "Left_Move":
                        switch (gameEvent.StringArg1) {
                            case "Go":
                                SetMoveLeft(true); 
                                break;
                            case "Stop":
                                SetMoveLeft(false); 
                                break;
                            default:
                                break;}
                        break;
                    case "Right_Move":
                        switch (gameEvent.StringArg1) {
                            case "Go":
                                SetMoveRight(true); 
                                break;
                            case "Stop":
                                SetMoveRight(false); 
                                break;
                            default:
                                break;}
                        break;       
                    default:
                        break;
                }
            }
        }
        private void UpdateDirection() {
            shape.AsDynamicShape().Direction.X = moveLeft + moveRight;
        }
        public void Render() {
            entity.RenderEntity();
        }
        public DynamicShape getShape() {
            return this.shape;
        }
    }
}