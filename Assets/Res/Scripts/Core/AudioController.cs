using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioController : SingletonMono<AudioController>
{
    [HideInInspector]
    public AudioSource bgSource;
    [HideInInspector]
    public AudioSource effectSource;

    string lastName;
  public  string AudioControllerResDir = string.Empty;

    public override   void Awake()
    {
        base.Awake();
        bgSource = gameObject.AddComponent<AudioSource>();
        bgSource.playOnAwake = false;
        bgSource.volume = 1;
        bgSource.loop = true;

        effectSource = gameObject.AddComponent<AudioSource>();
        effectSource.loop = false;
        effectSource.playOnAwake = false;
        effectSource.volume = 0.7f;
    }
    public float BgVolume
    {
        get { return bgSource.volume;}
        set { bgSource.volume = value; }
    }

    public float EffectVolume
    {
        get { return effectSource.volume; }
        set { effectSource.volume = value; }
    }
    public void PlayBg(string audioName)
    {
        if (bgSource.clip==null)
        {
            lastName = "";
        }
        else
        {
                    lastName = audioName;
        }

        if (lastName!=audioName)
        {
            var clip = LoadAudioClip(audioName);

            //播放
            if (clip)
            {
                bgSource.clip = clip;
                bgSource.Play();
            }
        }
    }
    public void StopBg()
    {
        if (bgSource != null)
        {
            bgSource.Stop();
            bgSource.clip = null;
        }
    }

    public void PlayEffect(string audioName)
    {
        if (audioName==null)
        {
            return;
        }
        var clip = LoadAudioClip(audioName);
        //播放
        if (clip)
        {
            effectSource.PlayOneShot(clip);
        }
    }
    public void StopEffect()
    {
        if (effectSource != null)
        {
            effectSource.Stop();
            effectSource.clip = null;
        }
    }

    public void StopAll()
    {
        if (bgSource != null)
        {
            bgSource.Stop();
            bgSource.clip = null;
        }
        if (effectSource != null)
        {
            effectSource.Stop();
            effectSource.clip = null;
        }
    
    }
    private AudioClip LoadAudioClip(string audioName)
    {
        string path = null;
        //路径
        if (string.IsNullOrEmpty(AudioControllerResDir))
        {
            path = "";
        }
        else
        {
            path = AudioControllerResDir + "/" + audioName;
        }

        //加载
        AudioClip clip = Resources.Load<AudioClip>(path);
        return clip;
    }
}

