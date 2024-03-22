using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSoundController : MonoBehaviour
{
    [SerializeField] SoundManager.SoundType soundType;
    AudioSource audioSource;
    public void Awake()
    {
        audioSource = gameObject.GetOrAddComponent<AudioSource>();
        //오디오 매니저에 오디오소스를 사운드 타입 리스트에 추가한다.
        Manager.Sound.AddSound(audioSource, soundType);
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource?.PlayOneShot(clip);
    }


}
