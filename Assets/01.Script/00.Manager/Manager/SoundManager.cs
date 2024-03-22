using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public enum SoundType
    { SFX, Voice, Animal,}

    [SerializeField] AudioSource bgmSource;
    [SerializeField] AudioSource sfxSource;
    [SerializeField] AudioSource voiceSource;
    [SerializeField] AudioSource animalSource;

    List<AudioSource> sfxLists = new List<AudioSource>();
    List<AudioSource> voiceLists = new List<AudioSource>();
    List<AudioSource> animalLists = new List<AudioSource>();

    public float BGMVolume { get { return bgmSource.volume; } set { bgmSource.volume = value;  } }
    public float SFXVolume { get { return sfxSource.volume; } set { sfxSource.volume = value; ChangeVolume(sfxLists, value); } }
    public float VoiceVolume { get { return voiceSource.volume; } set { voiceSource.volume = value; ChangeVolume(voiceLists, value); } }
    public float AnimalVolume { get { return animalSource.volume; } set { animalSource.volume = value; ChangeVolume(animalLists, value); } }

    public void PlayBGM(AudioClip clip, bool isContinue = false)
    {
        if (isContinue && bgmSource.clip.name == clip.name)
         return;
        StopPlay(bgmSource, clip);
    }
    public void PlaySFX(AudioClip clip) => sfxSource.PlayOneShot(clip);
    public void PlayVoice(AudioClip clip) => StopPlay(voiceSource, clip);
    public void PlayAnimal(AudioClip clip) => animalSource.PlayOneShot(clip);
    /// <summary>
    /// ����Ʈ ����� �����մϴ�.
    /// </summary>
    public void StopSFX()
    {
        if (sfxSource.isPlaying)
            sfxSource.Stop();
    }
    /// <summary>
    ///  BGM ����� �����մϴ�.
    /// </summary>
    public void StopBGM()
    {
        if (bgmSource.isPlaying)
            bgmSource.Stop();
    }
   
    /// <summary>
    /// �Ű������� ��������� ����Ǵ� ���带 �����ϰ� Ŭ���� ����մϴ�.
    /// </summary>
    /// <param name="audio"></param>
    /// <param name="clip"></param>
    void StopPlay(AudioSource audio, AudioClip clip)
    {
        if (audio.isPlaying)
            audio.Stop();
        audio.clip = clip;
        audio.Play();
    }
    /// <summary>
    /// ����Ʈ�� ��� ������ ������ �缳���մϴ�.
    /// </summary>
    /// <param name="lists"></param>
    /// <param name="volume"></param>
    void ChangeVolume(List<AudioSource> lists, float volume)
    {
        foreach (var audio in lists)
            audio.volume = volume;
    }
    /// <summary>
    /// �Ű������� ������� �ش� Ÿ�� �� ����Ʈ���� �����մϴ�.
    /// </summary>
    /// <param name="audio"></param>
    /// <param name="type"></param>
    public void RemoveSound(AudioSource audio, SoundType type)
    {
        switch (type)
        {
            case SoundType.SFX:
                sfxLists.Remove(audio);
                break;
            case SoundType.Voice:
                voiceLists.Remove(audio);
                break;
            case SoundType.Animal:
                animalLists.Remove(audio);
                break;
        }
    }
    /// <summary>
    /// �Ű������� ������� �ش� Ÿ�� ����Ʈ�� �߰��մϴ�.
    /// </summary>
    /// <param name="audio"></param>
    /// <param name="type"></param>
    public void AddSound(AudioSource audio, SoundType type)
    {
        switch (type)
        {
            case SoundType.SFX:
                sfxLists.Add(audio);
                break;
            case SoundType.Voice:
                voiceLists.Add(audio);
                break;
            case SoundType.Animal:
                animalLists.Add(audio);
                break;
        }
    }
}
