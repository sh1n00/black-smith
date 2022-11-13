using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip bgm;

    [SerializeField] private AudioClip startGong;

    [SerializeField] private AudioClip endGong;

    [SerializeField] private AudioClip countDown;

    [SerializeField] private List<AudioClip> punchSounds;

    [SerializeField]
    private AudioSource audioSourceBGM;

    [SerializeField]
    private AudioSource audioSourcePunch;
    
    public void bgmPlay()
    {
        audioSourceBGM.PlayOneShot(bgm);
    }

    public void startGongPlay()
    {
        audioSourcePunch.PlayOneShot(startGong);
    }

    public void endGongPlay()
    {
        audioSourcePunch.PlayOneShot(endGong);
    }

    public void coundDownPlay()
    {
        audioSourcePunch.PlayOneShot(countDown);
    }

    public void punchPlay(int punchIndex)
    {
        audioSourcePunch.PlayOneShot(punchSounds[punchIndex]);
    }

    public int getLength()
    {
        return punchSounds.Count;
    }

    public void punchPlayOnProb()
    {
        int prob = UnityEngine.Random.Range(0, 30);
        if (prob == 0)
        {
            audioSourcePunch.volume = 0.7f;
            punchPlay(3);
        }
        else punchPlay(0);

    }

    public void stopAudioFade(float decreaseRate)
    {
        for (int i=0; i<10; i++)
        {
            audioSourceBGM.volume -= decreaseRate;
        }
    }
}
