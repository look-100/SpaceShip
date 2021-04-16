using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    public static AudioManager Instance;
    public AudioClip enemyExpClip;
    public AudioClip playerExpClip;
    public AudioClip readyClip;
    public AudioClip recoveryClip;
    public AudioClip barrierClip;
    public AudioClip upGradeClip;
    public AudioClip upFullClip;
    public AudioMixer BGMixer;
    public AudioMixerGroup soundMixer;


    AudioSource enemyExpSource;
    AudioSource playerExpSource;
    AudioSource readySource;
    AudioSource recoverySource;
    AudioSource barrierSource;
    AudioSource upGradeSource;
    AudioSource upFullSource;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        //DontDestroyOnLoad(gameObject);

        enemyExpSource = gameObject.AddComponent<AudioSource>();
        enemyExpSource.outputAudioMixerGroup = soundMixer;

        playerExpSource = gameObject.AddComponent<AudioSource>();
        playerExpSource.outputAudioMixerGroup = soundMixer;

        readySource = gameObject.AddComponent<AudioSource>();
        readySource.outputAudioMixerGroup = soundMixer;

        recoverySource = gameObject.AddComponent<AudioSource>();
        recoverySource.outputAudioMixerGroup = soundMixer;

        barrierSource = gameObject.AddComponent<AudioSource>();
        barrierSource.outputAudioMixerGroup = soundMixer;


        upGradeSource = gameObject.AddComponent<AudioSource>();
        upGradeSource.outputAudioMixerGroup = soundMixer;

        upFullSource = gameObject.AddComponent<AudioSource>();
        upFullSource.outputAudioMixerGroup = soundMixer;


    }


    public static void PlayUpFullAudio()
    {
        Instance.upFullSource.clip = Instance.upFullClip;
        Instance.upFullSource.Play();

    }
    public static void PlayUpGradeAudio()
    {
        Instance.upGradeSource.clip = Instance.upGradeClip;
        Instance.upGradeSource.Play();

    }
    public static void PlayBarrierAudio()
    {
        Instance.barrierSource.clip = Instance.barrierClip;
        Instance.barrierSource.Play();

    }

    public static void PlayRecoveryAudio()
    {
        Instance.recoverySource.clip = Instance.recoveryClip;
        Instance.recoverySource.Play();

    }

    public static void PlayReadyAudio()
    {
        Instance.readySource.clip = Instance.readyClip;
        Instance.readySource.Play();
    }
    public static void PlayEnemyExpAudio()
    {
        Instance.enemyExpSource.clip = Instance.enemyExpClip;
        Instance.enemyExpSource.Play();
    }
    public static void PlayPlayerExpAudio()
    {
        Instance.playerExpSource.clip = Instance.playerExpClip;
        Instance.playerExpSource.Play();
    }

    public void SetBGMVolume(float value)
    {
        BGMixer.SetFloat("BGMVolume", value);
    }
    public void SetSoundVolume(float value)
    {
        soundMixer.audioMixer.SetFloat("SoundVolume", value);
    }

}
