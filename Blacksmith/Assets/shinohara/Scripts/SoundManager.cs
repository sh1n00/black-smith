using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip bgm;

    [SerializeField] private AudioClip startGong;
        
    [SerializeField] private AudioClip endGong;

    [SerializeField] private List<AudioClip> punchSounds;

    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void bgmPlay()
    {
        audioSource.PlayOneShot(bgm);
    }

    public void startGongPlay()
    {
        audioSource.PlayOneShot(startGong);
    }
    
    public void endGongPlay()
    {
        audioSource.PlayOneShot(endGong);
    }

    public void punchPlay(int punchIndex)
    {
        audioSource.PlayOneShot(punchSounds[punchIndex]);
    }
    
}
