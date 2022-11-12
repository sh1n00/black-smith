using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Animator anim;

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
            RayDetect();
            PunchAnim();
        }
    }
    //���C
    private void RayDetect()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            TagCheck(hit, "Sandbag");
        }
    }
    //���C�̃^�b�O���`�F�b�N
    private void TagCheck(RaycastHit hit, string tagName)
    {
        if(hit.transform.tag == tagName)
        {
            hit.collider.gameObject.GetComponent<Target>().Hit();
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
        anim.SetTrigger("punch");
    }
}
