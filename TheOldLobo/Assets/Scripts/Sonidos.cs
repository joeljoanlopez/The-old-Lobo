using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System;
using UnityEngine;

public class Sonidos : MonoBehaviour
{
    private AudioSource _sfxSourde;
    // Start is called before the first frame update
    [SerializeField] private AudioSource _sfxSource;
    public void playSFX(string name)
    {
        AudioFile file = GetFileByName(name);
        if(file == null)
        {

        }
        _sfxSource.clip = file.clip;
        _sfxSource.volume = file.volume;
        _sfxSource.Play();
    }
    AudioFile GetFileName(string name)
    {

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
