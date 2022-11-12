using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool isClick = false;

    void Start()
    {
        this.GetComponent<MeshRenderer>().material.color = Color.red;
    }

    
    void Update()
    {
        //今オブジェクトのスクリーン座標
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        //マウスのスクリーン座標　＝　今オブジェクトのスクリーン座標
        Vector3 m_MousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, pos.z);
        //マウス座標をワールド座標に変換してオブジェクトに渡す
        transform.position = Camera.main.ScreenToWorldPoint(m_MousePos);

    }
}
