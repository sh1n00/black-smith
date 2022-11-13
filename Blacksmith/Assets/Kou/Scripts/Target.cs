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
    [SerializeField]
    private Color criticalColor;

    //`�X�v���C�g
    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    [SerializeField]
    private Sprite[] _sprite;

    //�t���b�O
    private bool isCanHit = true;

    private void Start()
    {
        SpriteChange(_sprite[0]);
    }

    private void FixedUpdate()
    {
        if(!isCanHit)
        {
            _timerTmp++;
            if(_timerTmp >= _timer * 60.0f)
            {
                ChangeIsCanhit(true);
                ColorChange(normalColor);
                SpriteChange(_sprite[0]);
                _timerTmp = 0;
            }
        }
    }

    public void Hit(bool critical)
    {
        if(isCanHit)
        {
            ChangeIsCanhit(false);            
            BeHitAnim();
            //�N���e�B�J���m��
            if(critical)
            {
                ColorChange(criticalColor);
                soundManager.beHitPlayOnProb(1);
                scoreManager.ScorePlus(_score*2);
                SpriteChange(_sprite[2]);
                CriticalParticle();
            }
            else�@//�ʏ�U��
            {
                ColorChange(hitColor);
                soundManager.beHitPlayOnProb(0);
                scoreManager.ScorePlus(_score);
                SpriteChange(_sprite[1]);
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

    //�X�v���C�g�ϊ�
    private void SpriteChange(Sprite texture)
    {
        _spriteRenderer.sprite = texture;
    }
}
