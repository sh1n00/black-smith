using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //private bool isClick = false;

    void Start()
    {

    }

    
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
        }
    }

    private void RayDetect()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            TagCheck(hit,"Sandbag");
        }
    }

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
}
