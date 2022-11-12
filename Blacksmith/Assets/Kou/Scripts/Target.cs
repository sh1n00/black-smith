using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    //アニメ
    [SerializeField]
    private Animator anim;
    //スコアマネージャー
    [SerializeField]
    private ScoreManager scoreManager;

    [SerializeField]
    private float _timer = 0.5f;
    private float _timerTmp = 0.0f;
    [SerializeField]
    private int _score = 100;

    //パーティークル
    [SerializeField]
    private GameObject _particlePrefab;

    //色変え
    [SerializeField]
    private SpriteRenderer sprite;
    [SerializeField]
    private Color normalColor;
    [SerializeField]
    private Color hitColor;

    //フラッグ
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

    public void Hit()
    {
        if(isCanHit)
        {
            ChangeIsCanhit(false);
            ColorChange(hitColor);
            ScorePlus(_score);
            BeHitAnim();
            HitParticle();
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

    private void ScorePlus(int num)
    {
        scoreManager.Score += num;
        Debug.Log(scoreManager.Score);
    }
    //beHit演出
    public void BeHitAnim()
    {
        anim.SetTrigger("beHit");
    }

    private void HitParticle()
    {
        Instantiate(_particlePrefab, transform.position, Quaternion.identity);
    }
}
