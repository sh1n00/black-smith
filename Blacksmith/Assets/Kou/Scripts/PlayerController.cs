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
        //���I�u�W�F�N�g�̃X�N���[�����W
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        //�}�E�X�̃X�N���[�����W�@���@���I�u�W�F�N�g�̃X�N���[�����W
        Vector3 m_MousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, pos.z);
        //�}�E�X���W�����[���h���W�ɕϊ����ăI�u�W�F�N�g�ɓn��
        transform.position = Camera.main.ScreenToWorldPoint(m_MousePos);

    }
}
