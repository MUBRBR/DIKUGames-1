using DIKUArcade.Graphics;
using DIKUArcade.Entities;
using DIKUArcade.State;
using DIKUArcade.Input;
using System.IO;
using System;
using System.Collections.Generic;
using DIKUArcade.Math;
using DIKUArcade.Events;
using DIKUArcade.Physics;
using Breakout;
using Blocks;
using LevelLoading;

namespace GameState {
    public class GameRunning : IGameState {
        private static GameRunning instance = null;
        private EntityContainer<Block> blocks;
        private int counter = 0;
        private List<Image> blockColor;
        private List<Image> blockColorDamaged;
        private Player player;
        private LevelManager levelManager;
        List<String> ListOfFiles = Directory.EnumerateFiles(@Path.Combine("Assets", "Levels"), "*.txt").ToList();
        public static GameRunning GetInstance() {
            if (GameRunning.instance == null) {
                GameRunning.instance = new GameRunning();
                GameRunning.instance.InitializeGameState();
            }
            return GameRunning.instance;
        }
        private void InitializeGameState() {
            
            // player
            player = new Player(
                new DynamicShape(new Vec2F(0.45f, 0.1f), new Vec2F(0.1f, 0.02f)),
                new Image(Path.Combine("Assets", "Images", "player.png")));
            // eventbus
            BreakoutBus.GetBus().Subscribe(GameEventType.PlayerEvent, player);
            levelManager = new LevelManager();
            blocks = new EntityContainer<Block>();
        }
        public void ResetState() {
        }
        public void UpdateState() {
            BreakoutBus.GetBus().ProcessEventsSequentially();
            player.Move();
            NoBlocks();
        }
        public void RenderState() {
            player.Render();
            blocks.RenderEntities();
        }
        public void HandleKeyEvent(KeyboardAction action, KeyboardKey key) {
            if (action == KeyboardAction.KeyPress) {
                switch (key){
                    case KeyboardKey.Right or KeyboardKey.D:
                        BreakoutBus.GetBus().RegisterEvent(new GameEvent{EventType=GameEventType.PlayerEvent, Message="Right_Move", StringArg1="Go"});
                        break;
                    case KeyboardKey.Left or KeyboardKey.A:
                        BreakoutBus.GetBus().RegisterEvent(new GameEvent{EventType=GameEventType.PlayerEvent, Message="Left_Move", StringArg1="Go"});
                        break;
                    case KeyboardKey.Escape:
                        BreakoutBus.GetBus().RegisterEvent(new GameEvent{EventType=GameEventType.GameStateEvent, Message="CHANGE_STATE", StringArg1="GamePaused"});
                        break;
                    case KeyboardKey.Space:
                        System.Console.WriteLine(blocks.CountEntities());
                        killer();
                        break;
                }
            }
            else {
                switch (key) {
                    case KeyboardKey.Right or KeyboardKey.D:
                        BreakoutBus.GetBus().RegisterEvent(new GameEvent{EventType=GameEventType.PlayerEvent, Message="Right_Move", StringArg1="Stop"});
                        break;
                    case KeyboardKey.Left or KeyboardKey.A:
                        BreakoutBus.GetBus().RegisterEvent(new GameEvent{EventType=GameEventType.PlayerEvent, Message="Left_Move", StringArg1="Stop"});
                        break;
                }
            }
        }
        private void killer() {
            blocks.Iterate(block => {
                block.DeleteEntity();
            });
        }
        public void NoBlocks() {
            System.Console.WriteLine(blocks.CountEntities());
            if (blocks.CountEntities() == 0) {
                
                blocks = levelManager.levelLoader(ListOfFiles[counter]);
                counter++;
            }
        }
    }
}