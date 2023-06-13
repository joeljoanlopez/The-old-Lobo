using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class Sonidos : MonoBehaviour
{
    private AudioSource _sfxSourde;
    // Start is called before the first frame update
    [SerializeField] private AudioSource _sfxSource;
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private List<AudioFile> _audioFiles;
    public static Sonidos instance;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    public static void playSFX(string name, AudioSource orgSource = null)
    {
        instance._playSFX(name, orgSource);
    }
    public void _playSFX(string name, AudioSource orgSource = null)
    {
        AudioFile file = GetFileName(name);

        var source = orgSource==null ? _sfxSource : orgSource;
        if (file == null)
        {

        }
        source.clip = file.Clip;
        source.volume = file.Volume;
        source.Play();
    }
    public static void playMusic(string name, AudioSource orgSource = null)
    {
        instance._playMusic(name, orgSource);
    }
    public void _playMusic (string name, AudioSource orgSource = null)
    {
        AudioFile file = GetFileName(name);
        if (file == null)
        {
            return;
        }
        var source = orgSource == null ? _musicSource : orgSource;
        source.clip = file.Clip;
        source.volume = file.Volume;
        source.Play();
    }
    





    AudioFile GetFileName(string name)
    {
        for (int i = 0; i < _audioFiles.Count; i++)
        {
            if (_audioFiles[i].Name == name)
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
