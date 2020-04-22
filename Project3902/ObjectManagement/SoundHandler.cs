﻿using System;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

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
        private SoundEffect doorSound;
        private SoundEffect aquamentusSound;
        private SoundEffect bombBlowSound;
        private SoundEffect bombDropSound;
        private readonly List<SoundEffectInstance> instanceList=new List<SoundEffectInstance>();

        private Boolean musicPause = false;
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
            doorSound = content.Load<SoundEffect>("SoundEffects/LOZ_Door_Unlock");
            aquamentusSound= content.Load<SoundEffect>("SoundEffects/LOZ_Boss_Scream1");
            bombDropSound = content.Load<SoundEffect>("SoundEffects/LOZ_Bomb_Drop");
            bombBlowSound = content.Load<SoundEffect>("SoundEffects/LOZ_Bomb_Blow");
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
            if (!musicPause)
            {
                MediaPlayer.Play(currentSong);
            }
        }

        public void PlaySoundEffect(String effectType, Boolean stopMusic=false)
        {
            if (stopMusic)
            {
                musicPause = true;
                MediaPlayer.Stop();
            }
            if(effectType.Equals("Sword Slash"))
            {
                effect = swordSlashSound;
            }
            else if (effectType.Equals("Sword Shoot"))
            {
                effect = swordShootSound;
            }
            else if (effectType.Equals("Bomb Blow"))
            {
                effect = bombBlowSound;
            }
            else if (effectType.Equals("Bomb Drop"))
            {
                effect = bombDropSound;
            }
            else if (effectType.Equals("Boomerang"))
            {
                effect = boomerangSound;
                var instance = effect.CreateInstance();
                instance.IsLooped = true;
                instanceList.Add(instance);
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
            else if (effectType.Equals("Door Unlock"))
            {
                effect = doorSound;
            }
            else if (effectType.Equals("Aquamentus"))
            {
                effect = aquamentusSound;
            }
            if (stopMusic)
            {
                var tempInstance = effect.CreateInstance();
                tempInstance.Play();
                while (tempInstance.State == SoundState.Playing);
                MediaPlayer.Play(currentSong);
                musicPause = false;
            }
            else
            {
                effect.Play();
            }
        }

        public void StopMusic()
        {
            MediaPlayer.Stop();
        }

        public void StopEffectInstance(Boolean all=false)
        {
            if (instanceList.Count > 0)
            {
                if (all)
                {
                    foreach (SoundEffectInstance current in instanceList)
                    {
                        current.Stop();
                    }
                    instanceList.Clear();
                }
                else
                {
                    if (instanceList[0] != null)
                    {
                        instanceList[0].Stop();
                        instanceList.Remove(instanceList[0]);
                    }

                }
            }

        }


    }
}
