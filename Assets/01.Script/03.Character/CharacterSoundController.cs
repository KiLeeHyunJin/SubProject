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
        //����� �Ŵ����� ������ҽ��� ���� Ÿ�� ����Ʈ�� �߰��Ѵ�.
        Manager.Sound.AddSound(audioSource, soundType);
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource?.PlayOneShot(clip);
    }


}
