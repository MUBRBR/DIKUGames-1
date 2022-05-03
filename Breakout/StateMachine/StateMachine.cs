using DIKUArcade.Events;
using DIKUArcade.State;
using System;
using Breakout;


namespace GameState {
    public class StateMachine : IGameEventProcessor {
        public IGameState ActiveState { get; private set; }
        public StateMachine() {
            BreakoutBus.GetBus().Subscribe(GameEventType.GameStateEvent, this);
            BreakoutBus.GetBus().Subscribe(GameEventType.InputEvent, this);
            ActiveState = MainMenu.GetInstance();
            GamePaused.GetInstance();
            GameRunning.GetInstance();
        }
        private void SwitchState(GameStateType stateType) {
            switch (stateType) {
                case GameStateType.GamePaused:
                    ActiveState = GamePaused.GetInstance();
                    break;
                case GameStateType.GameRunning:
                    ActiveState = GameRunning.GetInstance();
                    break;
                case GameStateType.MainMenu:
                    ActiveState = MainMenu.GetInstance();
                    break;
                default:
                    throw new ArgumentException("This state does not exist and can't be switched");
            }
        }
        public void ProcessEvent(GameEvent gameEvent) {
            if (gameEvent.EventType == GameEventType.GameStateEvent) {
                switch (gameEvent.Message) {
                    case "CHANGE_STATE":
                        switch (gameEvent.StringArg1) {
                            case "GamePaused":
                                SwitchState(GameStateType.GamePaused);
                                break;
                            case "GameRunning":
                                SwitchState(GameStateType.GameRunning);
                                break;
                            case "MainMenu":
                                SwitchState(GameStateType.MainMenu);
                                break;
                            default:
                                throw new ArgumentException("Wrong input");
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}