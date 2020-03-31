﻿using System;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace Project3902.ObjectManagement
{
    class SoundHandler
    {
        private Song currentSong;
        private Song dungeonMusic;
        private Song introMusic;
        private Song gameOverMusic;
        private Song triforceMusic;

        private SoundEffect effect;
        private SoundEffect swordSlashSound;
        private SoundEffect swordShootSound;
        private SoundEffect boomerangSound;
        private SoundEffect enemyHitSound;
        private SoundEffect enemyDieSound;
        private SoundEffect linkHurtSound;
        private SoundEffect linkDieSound;
        private SoundEffect heartSound;
        private SoundEffect rupeeSound;
        private SoundEffect itemSound;
        private SoundEffectInstance instance;

        public static SoundHandler Instance { get; } = new SoundHandler();

        private SoundHandler()
        {

        }

        public void LoadAllSounds(ContentManager content)
        {
            dungeonMusic = content.Load<Song>("Songs/04 - Dungeon");
            introMusic = content.Load<Song>("Songs/01 - Intro");
            gameOverMusic = content.Load<Song>("Songs/07 - Game Over");
            triforceMusic = content.Load<Song>("Songs/06 - Triforce");
            swordSlashSound = content.Load<SoundEffect>("SoundEffects/LOZ_Sword_Slash");
            swordShootSound = content.Load<SoundEffect>("SoundEffects/LOZ_Sword_Shoot");
            boomerangSound= content.Load<SoundEffect>("SoundEffects/LOZ_Arrow_Boomerang");
            enemyHitSound = content.Load<SoundEffect>("SoundEffects/LOZ_Enemy_Hit");
            enemyDieSound = content.Load<SoundEffect>("SoundEffects/LOZ_Enemy_Die");
            linkHurtSound = content.Load<SoundEffect>("SoundEffects/LOZ_Link_Hurt");
            linkDieSound = content.Load<SoundEffect>("SoundEffects/LOZ_Link_Die");
            heartSound = content.Load<SoundEffect>("SoundEffects/LOZ_Get_Heart");
            rupeeSound = content.Load<SoundEffect>("SoundEffects/LOZ_Get_Rupee");
            itemSound = content.Load<SoundEffect>("SoundEffects/LOZ_Get_Item");

        }
        public void PlaySong(String songType)
        {
            if (songType.Equals("Intro"))
            {
                currentSong = introMusic;
            }
            else if (songType.Equals("Dungeon"))
            {
                currentSong = dungeonMusic;
            }
            else if (songType.Equals("Triforce"))
            {
                currentSong = triforceMusic;
            }
            else if (songType.Equals("Game Over"))
            {
                currentSong = gameOverMusic;
            }
            else
            {
                currentSong = dungeonMusic;
            }
            MediaPlayer.Play(currentSong);
            
            MediaPlayer.MediaStateChanged += MediaPlayer_MediaStateChanged;
        }

        private void MediaPlayer_MediaStateChanged(object sender, System.EventArgs e)
        {
            MediaPlayer.Play(currentSong);
        }

        public void PlaySoundEffect(String effectType)
        {
            if(effectType.Equals("Sword Slash"))
            {
                effect = swordSlashSound;
            }
            else if (effectType.Equals("Sword Shoot"))
            {
                effect = swordShootSound;
            }
            else if (effectType.Equals("Boomerang"))
            {
                effect = boomerangSound;
                instance = effect.CreateInstance();
                instance.IsLooped = true;
                instance.Play();
            }
            else if (effectType.Equals("Enemy Hit"))
            {
                effect = enemyHitSound;
            }
            else if (effectType.Equals("Enemy Die"))
            {
                effect = enemyDieSound;
            }
            else if (effectType.Equals("Link Hurt"))
            {
                effect = linkHurtSound;
            }
            else if (effectType.Equals("Link Die"))
            {
                effect = linkDieSound;
            }
            else if (effectType.Equals("Heart") || effectType.Equals("Key"))
            {
                effect = heartSound;
            }
            else if (effectType.Equals("Rupee"))
            {
                effect = rupeeSound;
            }
            else if (effectType.Equals("Item"))
            {
                effect = itemSound;
            }
            effect.Play();
            
        }

        public void StopMusic()
        {
            MediaPlayer.Stop();
        }

        public void StopEffectInstance()
        {
            if(instance!=null)
                instance.Stop();
        }
        

    }
}
