using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpMoveToTarget : MonoBehaviour
{
    public GameObject targetObject; // �ړ���I�u�W�F�N�g
    [SerializeField] float speed = 0.1f; // �X�s�[�h

    // Update is called once per frame
    void Update()
    {
        // �ړ�
        transform.position = Vector2.MoveTowards(transform.position, targetObject.transform.position, speed);
    }
}
