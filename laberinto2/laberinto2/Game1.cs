using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace laberinto2
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D vegeta;
        Rectangle posicion_vegeta;
        Texture2D rectangulo;
        Rectangle posicion_rectangulo;
        int velocidad;
        Rectangle[] vertedero;

        
        void teclas()
        {

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.A))


            {

                posicion_vegeta.X += velocidad;

            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.S))
            {
                posicion_vegeta.Y -= velocidad;

            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                // todo : if movimiento causa colision entonces no me muevo. Else  // si me mueve  posicion_vegeta.X -= velocidad;
                posicion_vegeta.X -= velocidad;

            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.W))
            {
                posicion_vegeta.Y += velocidad;

            }
        }
        

        public Game1()

        {
            graphics = new GraphicsDeviceManager(game: this);
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
            posicion_vegeta = new Rectangle(x: 500, y: 10, width: 40, height: 40);
            velocidad = 3;

            vertedero = new Rectangle[]
            {
               new Rectangle (0,-200,10,height:500),new Rectangle (0,300,10,250),new Rectangle(7,335,80,10),new Rectangle(80,250,10,120),new Rectangle(80,270,110,10),
               new Rectangle(180,45,10,480),new Rectangle (85,400,100,10),new Rectangle (180,110,90,10 ),new Rectangle(0,160,80,10),new Rectangle(75,70,10,130),
               new Rectangle (350,-100,10,400),new Rectangle (280,200,170,10),new Rectangle(280,160,10,300),new Rectangle(280,380,85,10), new Rectangle(360,310,10,100),
               new Rectangle(360,320,230,10),new Rectangle (575,310,10,100),new Rectangle(470,410,10,100),new Rectangle(790,210,10,357),new Rectangle(460,260,390,10),
               new Rectangle(630,23,10,320),new Rectangle (350,50,100,10),new Rectangle(535,150,100,10),new Rectangle(76,82,50,10),new Rectangle (180,-10,10,80),
               new Rectangle(650,410,150,10),new Rectangle(-5,-2,860,10)
                

            };
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
            vegeta = Content.Load<Texture2D>("vegeta");
            rectangulo = Content.Load<Texture2D>("rectangulo");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            //limites//

            //movientos con el teclado//
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.A)) {

                posicion_vegeta.X -= velocidad;

            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.S))
            {
                posicion_vegeta.Y += velocidad;

            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.D))
            {
                posicion_vegeta.X += velocidad;

            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.W))
            {
                posicion_vegeta.Y -= velocidad;

            }
            // TODO: Add your update logic here

            // colicion con los rectangulos//
            foreach (Rectangle i in vertedero)
            {
                if (posicion_vegeta.Intersects(i))
                {

                    teclas();




                }
                else if (i.Intersects(posicion_vegeta))
                {
                    velocidad = -velocidad;
                }
            }
            
            
            
      
                
            

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
            foreach (Rectangle i in vertedero)
            {
                spriteBatch.Draw(rectangulo, i, Color.Black);
            }
            spriteBatch.Draw(vegeta, posicion_vegeta, Color.White);
            spriteBatch.Draw(rectangulo, posicion_rectangulo, Color.Black);
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
