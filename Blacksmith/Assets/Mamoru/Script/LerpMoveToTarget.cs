using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpMoveToTarget : MonoBehaviour
{
    public GameObject targetObject; // 移動先オブジェクト
    [SerializeField] float speed = 0.1f; // スピード

    // Update is called once per frame
    void Update()
    {
        // 移動
        transform.position = Vector2.MoveTowards(transform.position, targetObject.transform.position, speed);
    }
}
