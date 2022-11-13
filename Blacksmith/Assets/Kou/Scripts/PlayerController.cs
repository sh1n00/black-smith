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

    //�}�E�X�N���b�N
    private void MouseLeftClick()
    {
        if(Input.GetMouseButtonDown(0))
        {           
            if(Critical())
            {
                RayDetect(true);
                soundManager.punchPlayOnCritical();
            }
            else
            {
                RayDetect(false);
                soundManager.punchPlayOnProb();
            }
            PunchAnim();
        }
    }
    //�N���e�B�J��
    private bool Critical()
    {
        return UnityEngine.Random.Range(0, 5) == 0;
    }


    //���C
    private void RayDetect(bool critical)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            TagCheck(hit, "Sandbag", critical);
        }
    }
    //���C�̃^�b�O���`�F�b�N
    private void TagCheck(RaycastHit hit, string tagName, bool critical)
    {
        if(hit.transform.tag == tagName)
        {
            hit.collider.gameObject.GetComponent<Target>().Hit(critical);
        }
    }

    //�J�[�\��
    private void CursorObjectMovement()
    {
        //���I�u�W�F�N�g�̃X�N���[�����W
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        //�}�E�X�̃X�N���[�����W�@���@���I�u�W�F�N�g�̃X�N���[�����W
        Vector3 m_MousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, pos.z);
        //�}�E�X���W�����[���h���W�ɕϊ����ăI�u�W�F�N�g�ɓn��
        transform.position = Camera.main.ScreenToWorldPoint(m_MousePos);
    }

    //�p���`���o
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
