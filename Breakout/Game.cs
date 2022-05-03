using DIKUArcade;
using DIKUArcade.GUI;
using DIKUArcade.Entities;
using LevelLoading;
using Blocks;
using DIKUArcade.Graphics;
using GameState;
using DIKUArcade.Events;
using DIKUArcade.Input;

namespace Breakout {
    public class Game : DIKUGame, IGameEventProcessor {
        private StateMachine stateMachine;
        
        public Game(WindowArgs windowArgs) : base (windowArgs) {
            // eventbus
            BreakoutBus.GetBus().Subscribe(GameEventType.InputEvent, this);
            window.SetKeyEventHandler(KeyHandler);
            // stateMachine
            stateMachine = new StateMachine();
        }

        public void KeyHandler(KeyboardAction action, KeyboardKey key) {
            stateMachine.ActiveState.HandleKeyEvent(action, key);
        }
        
        public void ProcessEvent(GameEvent gameEvent) {
            if (gameEvent.EventType == GameEventType.WindowEvent) {
                switch (gameEvent.Message) {
                    default:
                        break;
                }
            }
        }
        public override void Render() {
            stateMachine.ActiveState.RenderState();
        }
        public override void Update() {
            stateMachine.ActiveState.UpdateState();
        }
    }
}