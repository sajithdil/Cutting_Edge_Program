using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using SimpleGameLib.ContentWrappers;
using SimpleGameLib.PythonScp;
using SimpleGameLib;
using System.Reflection;
using System.IO;
using SimpleGameLib.SWRenderer;
using SimpleWindow.Controller;
using SimpleGameLib.AssetKeeper;
using SimpleGameLib.XML;
using SimpleGameLib.Players;
using SimpleGameLib.Animations;
using SimpleGameLib.KeyBoardModels;
using SimpleGameLib.PlayerCollisions;
using SimpleGameLib.MouseModels;
using SimpleGameLib.MouseRenderers;

namespace SimpleGameTest
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private SWMinder swMinder;
        private GController gController;
        private Skinner skinner;
        private PlayerCollection playerCollection;
        private MouseRenderer mouseRender;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            ContentWrapper.getInstance().setContent(Content);

            //Load all the scripts
            ScriptKeeper.getInstance().init("scripts/scripts.xml");

            //Load the GUI components

            swMinder = new SWMinder();
            gController = new GController();
            playerCollection = new PlayerCollection();

            //Load the fonts
            SpriteFontFactory.getInstance().load();

            //Add the cursor rendering
            mouseRender = new MouseRenderer();
            //Connect the cursor to the mouse model
            MouseModel.getInstance().addObserver(mouseRender);

            //Connect the SWMinder listening code
            MouseModel.getInstance().addObserver(swMinder);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //Register the scripting 
            PythonObject.getInstance().register();

            //Load the world
            WorldsKeeper.getInstance().init("worlds/world_info.xml");

            //Load the skins
            AssetsKeeper skinnerAssets = new AssetsKeeper();
            skinnerAssets.init("style/assets.xml");
            skinner = new Skinner();
            Style style=new Style();
            style.init("style/style.xml");

            //Connect the style
        

            //Connect python

            PythonObject.getInstance().getScope().SetVariable("WORLDSKEEPER", WorldsKeeper.getInstance());
            PythonObject.getInstance().getScope().SetVariable("LOG", Log.getInstance());
            PythonObject.getInstance().getScope().SetVariable("WINDOWCONTROL", gController);
            PythonObject.getInstance().getScope().SetVariable("WINDOWSKINNER", skinner);
            PythonObject.getInstance().getScope().SetVariable("MINDER", swMinder);
            PythonObject.getInstance().getScope().SetVariable("WINDOWSTYLE", style);
            PythonObject.getInstance().getScope().SetVariable("PLAYERS", playerCollection);
            PythonObject.getInstance().getScope().SetVariable("KEYBOARD", KeyboardModel.getInstance());
            PythonObject.getInstance().getScope().SetVariable("MOUSECURSOR", mouseRender);

            PythonObject.getInstance().getScope().SetVariable("ANIMATIONSSPACE", AnimationAssets.getInstance());
            
            

            //Load the SimpleGameLib
            string path = Assembly.GetExecutingAssembly().Location;
            string dir = Directory.GetParent(path).FullName;
            string libPath = Path.Combine(dir, "SimpleGameLib.dll");

            Assembly assembly = Assembly.LoadFile(libPath);

            PythonObject.getInstance().getRuntime().LoadAssembly(assembly);

            //Load the SimpleWindowLib
            path = Assembly.GetExecutingAssembly().Location;
            dir = Directory.GetParent(path).FullName;
            libPath = Path.Combine(dir, "SimpleWindow.dll");

            assembly = Assembly.LoadFile(libPath);

            PythonObject.getInstance().getRuntime().LoadAssembly(assembly);

            //Connect the SWMinder left click handler
            MouseModel.getInstance().addObserver(swMinder);

            //The animations

            //Add all animations here
           // AnimationAssets.getInstance().addAsset(new AnimationWrapper("idle_animation", new List<string> {"dungeon","lava" }));
            AnimationAssets.getInstance().addAsset(new AnimationWrapper("idle", new List<String> { "P_U1" }));
            AnimationAssets.getInstance().addAsset(new AnimationWrapper("player_up",new List<String>{"P_U1","P_U2","P_U3","P_U2"}));
            AnimationAssets.getInstance().addAsset(new AnimationWrapper("player_down", new List<String> { "P_D1", "P_D2", "P_D3", "P_D2","P_D3" }));
            AnimationAssets.getInstance().addAsset(new AnimationWrapper("player_left", new List<String> { "P_L1", "P_L2", "P_L3", "P_L2" }));
            AnimationAssets.getInstance().addAsset(new AnimationWrapper("player_right", new List<String> { "P_R1", "P_R2", "P_R3", "P_R2" }));
            

            //Player a = new Player("player two", "idle_animation", 50, 200);

            //playerCollection.add(a);

            //Load the start up script
           
            PythonObject.getInstance().executeString(ScriptKeeper.getInstance().getScript("start_up"));
          
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            CollisionCheck.collision(playerCollection, WorldsKeeper.getInstance().getCurrent().MapData);
            
            AnimationSpace.getInstance().update();

            //Update the keyboard model
            KeyboardModel.getInstance().update(Keyboard.GetState());

            //Update the mouse model
            MouseModel.getInstance().update(Mouse.GetState());

            //Update all the players
            playerCollection.update();

            //Check for event collisions
            EventCollisions.collisions(playerCollection, WorldsKeeper.getInstance().getCurrent().EventMapData);
            //Remove any dead events
            //WorldsKeeper.getInstance().getCurrent().EventMapData.removeDead();

            //Update the models
            swMinder.update();

            //Update the gcontrollers
            gController.update();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);



            spriteBatch.Begin();

            //Draw the map

            //Check whether the map is empty
            if (WorldsKeeper.getInstance().isCurrentEmpty() == false)
            {
                WorldsKeeper.getInstance().getCurrent().MapData.render(spriteBatch);
            }
            else
            {
                Log.getInstance().log("@Render loop attempted to draw an empty map");
            }

            //Draw the user interface
            swMinder.draw(spriteBatch);

            //Draw the animations
            AnimationSpace.getInstance().draw(spriteBatch);

            //Draw the cursor
            mouseRender.render(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
