using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip bgm;
    [SerializeField] private float bgmVolume = 0.3f;

    [SerializeField] private AudioClip startGong;

    [SerializeField] private AudioClip endGong;

    [SerializeField] private AudioClip countDown;

    [SerializeField] private List<AudioClip> punchSounds;

    [SerializeField] private List<AudioClip> beHitSounds;

    [SerializeField]
    private AudioSource audioSourceBGM;

    [SerializeField]
    private AudioSource audioSourcePunch;
    
    public void bgmPlay()
    {
        audioSourceBGM.PlayOneShot(bgm, bgmVolume);
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

    public void beHitPlay(int punchIndex)
    {
        audioSourcePunch.PlayOneShot(beHitSounds[punchIndex]);
    }

    public int getLength()
    {
        return punchSounds.Count;
    }

    public void punchPlayOnProb()
    {
        int prob = UnityEngine.Random.Range(0, 2);
        punchPlay(prob);
    }

    public void punchPlayOnCritical()
    {
        int prob = UnityEngine.Random.Range(2, 5);
        punchPlay(prob);
    }

    public void beHitPlayOnProb(int num)
    {
        beHitPlay(num);
    }

    public void stopAudioFade(float decreaseRate)
    {
        for (int i=0; i<10; i++)
        {
            audioSourceBGM.volume -= decreaseRate;
        }
    }
}
