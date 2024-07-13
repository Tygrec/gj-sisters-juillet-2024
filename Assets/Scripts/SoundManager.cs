using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiPlayerTK;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public MidiFilePlayer midiPlayer;

    public void Play(string midiName)
    {
        midiPlayer.MPTK_Stop();
        midiPlayer.MPTK_MidiName = midiName;
        midiPlayer.MPTK_Play();
    }
}
