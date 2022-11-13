using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Animator anim;

    private bool punchFlag = true;

    [SerializeField]
    private SoundManager soundManager;
    
    void Update()
    {
        MouseLeftClick();
        CursorObjectMovement();
    }

    //マウスクリック
    private void MouseLeftClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RayDetect();
            PunchAnim();
            // Random.Range(0, soundManager.getLength());
            soundManager.punchPlay(1);
        }
    }
    //レイ
    private void RayDetect()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            TagCheck(hit, "Sandbag");
        }
    }
    //レイのタッグをチェック
    private void TagCheck(RaycastHit hit, string tagName)
    {
        if(hit.transform.tag == tagName)
        {
            hit.collider.gameObject.GetComponent<Target>().Hit();
        }
    }

    //カーソル
    private void CursorObjectMovement()
    {
        //今オブジェクトのスクリーン座標
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        //マウスのスクリーン座標　＝　今オブジェクトのスクリーン座標
        Vector3 m_MousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, pos.z);
        //マウス座標をワールド座標に変換してオブジェクトに渡す
        transform.position = Camera.main.ScreenToWorldPoint(m_MousePos);
    }

    //パンチ演出
    public void PunchAnim()
    {
        if(punchFlag)
        {
            anim.SetTrigger("punch"); 
        }
        else
        {
            anim.SetTrigger("punchL");
        }
        punchFlag = !punchFlag;
    }
}
