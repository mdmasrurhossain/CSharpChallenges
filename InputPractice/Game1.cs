using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using FMOD;

namespace InputPractice
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _shuttle;
        private Vector2 _shuttlePosition;
        private float _shuttleSpeed;
        private SoundEffect _shuttleThursterSoundEffect;
        private SoundEffectInstance _shuttleThursterSoundEffectInstance;
        private Song _backgroundAudio;
        private protected SpriteFont _audioFont;

        private System fmodSystem;
        private FMOD.Sound sound;
        private FMOD.Channel channel;
        private FMOD.ChannelGroup group;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            FMOD.Factory.System_Create(out fmodSystem);
            fmodSystem.init(512, FMOD.INITFLAGS.NORMAL, IntPtr.Zero);

            _shuttlePosition = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);
            _shuttleSpeed = 100f;
            

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            _shuttle = Content.Load<Texture2D>("./assets/sprites/shuttle");
            //_shuttleThursterSoundEffect = Content.Load<SoundEffect>("./assets/audio/rocketThruster");
            //_backgroundAudio = Content.Load<Song>("./assets/audio/background");
            //_audioFont = Content.Load<SpriteFont>("./assets/fonts/BackgroundAudioFont");
            fmodSystem.createSound("./assets/audio/background.mp3", FMOD.MODE.DEFAULT, out sound);

            fmodSystem.playSound(sound, group, false, out channel);
            //_shuttleThursterSoundEffectInstance = _shuttleThursterSoundEffect.CreateInstance();
            //MediaPlayer.Play(_backgroundAudio);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            float updateShuttleSpeed = _shuttleSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            KeyboardState kstate = Keyboard.GetState();


            if (kstate.IsKeyDown(Keys.Up) || kstate.IsKeyDown(Keys.Down) || kstate.IsKeyDown(Keys.Left) || kstate.IsKeyDown(Keys.Right))
                _shuttleThursterSoundEffectInstance.Play();
            else
                _shuttleThursterSoundEffectInstance.Pause();
            if (kstate.IsKeyDown(Keys.Up))
                _shuttlePosition.Y -= updateShuttleSpeed;
            if (kstate.IsKeyDown(Keys.Down))
                _shuttlePosition.Y += updateShuttleSpeed;
            if (kstate.IsKeyDown(Keys.Left))
                _shuttlePosition.X -= updateShuttleSpeed;
            if (kstate.IsKeyDown(Keys.Right))
                _shuttlePosition.X += updateShuttleSpeed;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            TimeSpan time = MediaPlayer.PlayPosition;
            TimeSpan songTime = _backgroundAudio.Duration;
            _spriteBatch.Begin();
            _spriteBatch.DrawString(_audioFont, _backgroundAudio.Name, new Vector2(10, 430), Color.Black);
            _spriteBatch.DrawString(_audioFont, GetHumanReadableTime(time) + " / " + GetHumanReadableTime(songTime), new Vector2(10, 450), Color.Black);
            _spriteBatch.Draw(_shuttle, _shuttlePosition,null, Color.White, 0f, new Vector2(_shuttle.Width / 2, _shuttle.Height / 2), Vector2.One, SpriteEffects.None, 0f);    
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public string GetHumanReadableTime(TimeSpan timeSpan)
        {
            int minutes = timeSpan.Minutes;
            int seconds = timeSpan.Seconds;

            if (seconds < 10)
                return minutes + ":0" + seconds;
            else
                return minutes + ":" + seconds;
        }
    }
}
