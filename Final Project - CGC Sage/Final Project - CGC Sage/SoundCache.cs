using System;
using System.Collections.Generic;
using System.IO;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace Final_Project___CGC_Sage
{


    public class CachedSound
    {
        public float[] AudioData { get; private set; }
        public WaveFormat WaveFormat { get; private set; }

        public CachedSound(byte[] audioBytes)
        {
            using (var ms = new MemoryStream(audioBytes))
            using (var reader = new WaveFileReader(ms))
            {
                WaveFormat = reader.WaveFormat;
                var wholeFile = new List<float>();

                int bytesPerSample = reader.WaveFormat.BitsPerSample / 8;
                int bytesRead;
                byte[] buffer = new byte[reader.WaveFormat.SampleRate * reader.WaveFormat.BlockAlign]; // read 1 second chunks

                while ((bytesRead = reader.Read(buffer, 0, buffer.Length)) > 0)
                {
                    // Convert bytes to floats
                    for (int i = 0; i < bytesRead; i += bytesPerSample)
                    {
                        float sample = 0f;

                        if (bytesPerSample == 2)
                        {
                            // 16-bit PCM to float
                            short sample16 = BitConverter.ToInt16(buffer, i);
                            sample = sample16 / 32768f;
                        }
                        else if (bytesPerSample == 4)
                        {
                            // 32-bit PCM to float
                            sample = BitConverter.ToSingle(buffer, i);
                        }
                        else
                        {
                            // Add support if needed for other bit depths
                            throw new InvalidOperationException("Unsupported bit depth: " + bytesPerSample * 8);
                        }

                        wholeFile.Add(sample);
                    }
                }
                AudioData = wholeFile.ToArray();
            }
        }
    }

    public class CachedSoundPlayer : IDisposable
    {
        private IWavePlayer outputDevice;
        private WaveOutEvent waveOut;
        private MixingSampleProvider mixer;

        public CachedSoundPlayer()
        {
            outputDevice = new WaveOutEvent();
            mixer = new MixingSampleProvider(WaveFormat.CreateIeeeFloatWaveFormat(44100, 2));
            mixer.ReadFully = true;
            outputDevice.Init(mixer);
            outputDevice.Play();
        }

        public void PlaySound(CachedSound sound)
        {
            ISampleProvider source = new CachedSoundSampleProvider(sound);

            // Resample to mixer format sample rate if needed
            if (source.WaveFormat.SampleRate != mixer.WaveFormat.SampleRate)
            {
                source = new WdlResamplingSampleProvider(source, mixer.WaveFormat.SampleRate);
            }

            // Convert mono to stereo if channel counts differ
            if (source.WaveFormat.Channels == 1 && mixer.WaveFormat.Channels == 2)
            {
                source = new MonoToStereoSampleProvider(source);
            }
            else if (source.WaveFormat.Channels != mixer.WaveFormat.Channels)
            {
                throw new InvalidOperationException("Unsupported channel conversion.");
            }

            mixer.AddMixerInput(source);
        }

        public void Dispose()
        {
            outputDevice.Dispose();
        }
    }

    public class CachedSoundSampleProvider : ISampleProvider
    {
        private CachedSound cachedSound;
        private long position;

        public CachedSoundSampleProvider(CachedSound cachedSound)
        {
            this.cachedSound = cachedSound;
        }

        public int Read(float[] buffer, int offset, int count)
        {
            int availableSamples = cachedSound.AudioData.Length - (int)position;
            int samplesToCopy = Math.Min(availableSamples, count);
            Array.Copy(cachedSound.AudioData, position, buffer, offset, samplesToCopy);
            position += samplesToCopy;
            return samplesToCopy;
        }

        public WaveFormat WaveFormat => cachedSound.WaveFormat;
    }

}
