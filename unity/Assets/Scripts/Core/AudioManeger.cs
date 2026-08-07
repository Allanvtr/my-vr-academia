using System;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class AudioManeger : MonoBehaviour
{
    private List<AudioClip> audios;

    public List<AudioClip> GetAudios(){
        return audios;
    }

    public void AddAudio(AudioClip audio)
    {
        audios.Add(audio);
    }
}