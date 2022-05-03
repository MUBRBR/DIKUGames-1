using DIKUArcade.Graphics;
using DIKUArcade.Entities;
using DIKUArcade.State;
using DIKUArcade.Input;
using System.IO;
using System.Collections.Generic;
using DIKUArcade.Math;
using DIKUArcade.Events;
using DIKUArcade.GUI;
using Breakout;

namespace GameState {
    public class MainMenu : IGameState {
        private static MainMenu instance = null;
        private Window window;
        private Entity backGroundImage;
        private Text[] menuButtons;
        private List<Image> MainMenuBackGround;
        private int activeMenuButton;
        private int maxMenuButtons;
        private Vec2F textSize;
        public static MainMenu GetInstance() {
            if (MainMenu.instance == null) {
                MainMenu.instance = new MainMenu();
                MainMenu.instance.InitializeGameState();
            }
            return MainMenu.instance;
        }
        private void InitializeGameState()
        {
            MainMenuBackGround = ImageStride.CreateStrides(1, Path.Combine("Assets", "Images", "BreakoutTitleScreen.png"));
            backGroundImage = new Entity(
                                new StationaryShape(new Vec2F(0.0f, 0.0f), new Vec2F(1.0f, 1.0f)), 
                                new ImageStride (80, MainMenuBackGround));
            textSize = new Vec2F(0.4f, 0.3f);
            menuButtons = new Text[] 
                            {new Text("New Game", new Vec2F(0.4f, 0.4f), textSize), 
                            new Text("Quit", new Vec2F(0.4f, 0.3f), textSize)};
            activeMenuButton = 0;
            maxMenuButtons = 2;
            menuButtons[0].GetShape().ScaleXFromCenter(1.5f);
            menuButtons[0].SetColor(System.Drawing.Color.Yellow);
            menuButtons[1].SetColor(System.Drawing.Color.White);
        }
        public void ResetState() {
            MainMenu.instance = null;
        }
        public void UpdateState() {
            BreakoutBus.GetBus().ProcessEventsSequentially();
        }
        public void RenderState() {
            backGroundImage.RenderEntity();
            foreach (Text text in menuButtons) {
                text.RenderText();
            }
        }
        public void ColorMenuButtons() {
            switch (activeMenuButton) {
                case 0:
                    if (menuButtons[activeMenuButton].GetColor() == System.Drawing.Color.Yellow) {
                        menuButtons[activeMenuButton].SetColor(System.Drawing.Color.White);
                        menuButtons[1].SetColor(System.Drawing.Color.Yellow);
                    }
                    else {
                        menuButtons[activeMenuButton].SetColor(System.Drawing.Color.Yellow);
                        menuButtons[0].SetColor(System.Drawing.Color.White);
                    }
                    break;
                case 1:
                    if (menuButtons[activeMenuButton].GetColor() == System.Drawing.Color.Yellow) {
                        menuButtons[activeMenuButton].SetColor(System.Drawing.Color.White);
                        menuButtons[0].SetColor(System.Drawing.Color.Yellow);
                    }
                    else {
                        menuButtons[activeMenuButton].SetColor(System.Drawing.Color.Yellow);
                        menuButtons[1].SetColor(System.Drawing.Color.White);
                    }
                    break;
                default:
                    break;
            }
        }
        public void HandleKeyEvent(KeyboardAction action, KeyboardKey key) {
            if (action == KeyboardAction.KeyPress)
            {
                switch (key) {
                    case KeyboardKey.Up:
                        switch (activeMenuButton) {
                            case 0:
                                ColorMenuButtons();
                                activeMenuButton = 1;
                                break;
                            case 1:
                                ColorMenuButtons();
                                activeMenuButton = 0;
                                break;
                            default:
                                break;
                        }
                        break;
                    case KeyboardKey.Down:
                        switch (activeMenuButton) {
                            case 0:
                                ColorMenuButtons();
                                activeMenuButton = 1;
                                break;
                            case 1:
                                ColorMenuButtons();
                                activeMenuButton = 0;
                                break;
                            default:
                                break;
                        }
                        break;
                    case KeyboardKey.Enter:
                        switch (activeMenuButton) {
                            case 0:
                                BreakoutBus.GetBus().RegisterEvent(
                                    new GameEvent{
                                        EventType=GameEventType.GameStateEvent, 
                                        Message="CHANGE_STATE",
                                        StringArg1 = "GameRunning"
                                    }
                                );
                                break;
                            case 1:
                                window.CloseWindow();
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}