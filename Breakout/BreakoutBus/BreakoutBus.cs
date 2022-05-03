using DIKUArcade.Events;
using System.Collections.Generic;
namespace Breakout {
    public static class BreakoutBus {
        private static GameEventBus eventBus;
        public static GameEventBus GetBus() {
            if (eventBus == null) {
                BreakoutBus.eventBus = new GameEventBus();
                BreakoutBus.eventBus.InitializeEventBus(
                new List<GameEventType> {
                    GameEventType.GameStateEvent, 
                    GameEventType.InputEvent, 
                    GameEventType.PlayerEvent, 
                    GameEventType.StatusEvent, 
                    GameEventType.GraphicsEvent, 
                    GameEventType.ControlEvent, 
                    GameEventType.MovementEvent, 
                    GameEventType.SoundEvent,
                    GameEventType.TimedEvent,
                    GameEventType.WindowEvent});
            }
            return BreakoutBus.eventBus;
        }
    }
}