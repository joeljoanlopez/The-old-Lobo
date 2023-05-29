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
    private List<AudioFile> _audioFiles;

    public void playSFX(string name)
    {
        AudioFile file = GetFileName(name);
        if(file == null)
        {

        }
        _sfxSource.clip = file.Clip;
        _sfxSource.volume = file.Volume;
        _sfxSource.Play();
    }
    AudioFile GetFileName(string name)
    {
        for (int i = 0; i < _audioFiles.Count; i++)
        {
            if (_audioFiles[i].name == name)
            {
                return _audioFiles[i];
            }
        }
        return null;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
