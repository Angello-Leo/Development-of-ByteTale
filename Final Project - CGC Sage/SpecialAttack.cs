using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;

namespace Final_Project___CGC_Sage
{
    public class SpecialAttack : PictureBox
    {
        private Panel gamePanel;
        private List<CreateEnemy> words;
        private Player player;
        private Action onAttackComplete;
        private bool ultimateReady = false;
        private WaveOutEvent soundEffectPlayer;
        private AudioFileReader audioFileReader;

        public SpecialAttack(Panel gamePanel, List<CreateEnemy> words, Player _player, Action onComplete = null)
        {
            this.gamePanel = gamePanel;
            this.words = words;
            this.player = _player;
            this.onAttackComplete = onComplete;
        }

        public async void Activate()
        {
            // STEP 1: Show Gaster Blaster GIF at bottom center
            PictureBox gasterBlaster = new PictureBox();
            string gifPath = Path.Combine(Application.StartupPath, "Resources", "GasterBlasterGIF.gif");
            string soundPath = Path.Combine(Application.StartupPath, "Resources", "gaster_blaster_sound_effect.wav");


            if (File.Exists(gifPath))
            {
                Image gifImage = Image.FromFile(gifPath);
                gifImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
                gasterBlaster.Image = gifImage;
            }
            else
            {
                MessageBox.Show("Gaster Blaster GIF not found:\n" + gifPath);
                return;
            }

            gasterBlaster.Size = new Size(200, 200); 
            gasterBlaster.SizeMode = PictureBoxSizeMode.StretchImage;
            gasterBlaster.BackColor = Color.Transparent;

            // Bottom-center position
            int xOffset = 0; // positive moves it right
            int yOffset = -80; // negative moves it higher

            gasterBlaster.Location = new Point(
                (gamePanel.Width - gasterBlaster.Width) / 2 + xOffset,
                gamePanel.Height - gasterBlaster.Height + yOffset
            );


            gamePanel.Controls.Add(gasterBlaster);
            gasterBlaster.BringToFront();
            if (File.Exists(soundPath))
            {
                PlaySoundEffect(soundPath);
            }
            else
            {
                MessageBox.Show("Laser sound not found:\n" + soundPath);
            }
            // STEP 2: Wait for animation to "charge"
            await Task.Delay(1000); // adjust as needed

            // STEP 3: Flash laser effect
            Panel flash = new Panel
            {
                BackColor = Color.White,
                Size = gamePanel.Size,
                Location = new Point(0, 0)
            };
            gamePanel.Controls.Add(flash);
            flash.BringToFront();

            await Task.Delay(150); // duration of flash
            gamePanel.Controls.Remove(flash);
            flash.Dispose();

            // STEP 4: Remove all enemies
            var enemiesToRemove = gamePanel.Controls.OfType<CreateEnemy>().ToList();
            foreach (var enemy in enemiesToRemove)
            {
                gamePanel.Controls.Remove(enemy.AttachedPicture);
                enemy.AttachedPicture.Dispose();

                gamePanel.Controls.Remove(enemy);
                enemy.Dispose();

                words.Remove(enemy);
            }

            // STEP 5: Clean up Gaster Blaster
            await Task.Delay(300); // optional short delay before removing gif
            gamePanel.Controls.Remove(gasterBlaster);
            gasterBlaster.Dispose();

            onAttackComplete?.Invoke();
        }

        private void PlaySoundEffect(string filePath)
        {
            DisposeSoundEffect(); // Dispose previous if any

            audioFileReader = new AudioFileReader(filePath);
            soundEffectPlayer = new WaveOutEvent();
            soundEffectPlayer.Init(audioFileReader);
            soundEffectPlayer.PlaybackStopped += (s, e) => DisposeSoundEffect();
            soundEffectPlayer.Play();
        }

        private void DisposeSoundEffect()
        {
            if (soundEffectPlayer != null)
            {
                soundEffectPlayer.Stop();
                soundEffectPlayer.Dispose();
                soundEffectPlayer = null;
            }
            if (audioFileReader != null)
            {
                audioFileReader.Dispose();
                audioFileReader = null;
            }
        }
    }
}
