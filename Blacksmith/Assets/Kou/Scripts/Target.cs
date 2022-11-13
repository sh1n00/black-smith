using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    //�A�j��
    [SerializeField]
    private Animator anim;
    
    //�X�R�A�}�l�[�W���[
    [SerializeField]
    private ScoreManager scoreManager;

    //�T�E���h�}�l�[�W���[
    [SerializeField]
    private SoundManager soundManager;

    [SerializeField]
    private float _timer = 0.5f;
    private float _timerTmp = 0.0f;
    [SerializeField]
    private int _score = 100;

    //�p�[�e�B�[�N��
    [SerializeField]
    private GameObject _particlePrefab;
    [SerializeField]
    private GameObject _criticalPrefab;

    //�F�ς�
    [SerializeField]
    private SpriteRenderer sprite;
    [SerializeField]
    private Color normalColor;
    [SerializeField]
    private Color hitColor;

    //�t���b�O
    private bool isCanHit = true;

    private void FixedUpdate()
    {
        if(!isCanHit)
        {
            _timerTmp++;
            if(_timerTmp >= _timer * 60.0f)
            {
                ChangeIsCanhit(true);
                ColorChange(normalColor);
                _timerTmp = 0;
            }
        }
    }

    public void Hit(bool critical)
    {
        if(isCanHit)
        {
            ChangeIsCanhit(false);
            ColorChange(hitColor);
            
            BeHitAnim();
            //�N���e�B�J���m��
            if(critical)
            {
                soundManager.beHitPlayOnProb(1);
                scoreManager.ScorePlus(_score*2);
                CriticalParticle();
            }
            else�@//�ʏ�U��
            {
                soundManager.beHitPlayOnProb(0);
                scoreManager.ScorePlus(_score);
                HitParticle();
            }      
        }
    }

    private void ChangeIsCanhit(bool flag)
    {
        isCanHit = flag;
    }

    private void ColorChange(Color color)
    {
        sprite.material.color = color;
    }
    
    //beHit���ow
    public void BeHitAnim()
    {
        anim.SetTrigger("beHit");
    }

    private void HitParticle()
    {
        Instantiate(_particlePrefab, transform.position, Quaternion.identity);
    }
    private void CriticalParticle()
    {
        Instantiate(_criticalPrefab, transform.position, Quaternion.identity);
    }
}
