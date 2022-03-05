using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
   public static AudioManager instance;
   public AudioMixer audioMix;

   private void Awake()
   {
      if (instance != null)
      {
         Debug.LogError("Oskur");
         return;
      }
      instance = this;
   }
   
   public void SetVolume(float _volume) // Volume
   {
      audioMix.SetFloat("Volume", _volume);
   }
}
