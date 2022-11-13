using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpMoveToTarget : MonoBehaviour
{
    enum State
    {
        Normal,    // �ʏ���
        OneGearUp, // 1�i�i�����
        TwoGearUp, // 2�i�i�����
    }

    public GameObject targetObject; // �ړ���I�u�W�F�N�g
    GameObject scoreManager; // �X�R�A�}�l�[�W���[���擾
    ScoreManager scoreManagerScript;
    [SerializeField] float speed = 0.1f; // �X�s�[�h
    State state = State.Normal;
    //int score;

    void Start()
    {
        // �X�R�A�}�l�[�W���[�X�N���v�g���擾
        scoreManager = GameObject.Find("ScoreManager");
        scoreManagerScript = scoreManager.GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        int score = scoreManagerScript.Score;
        if (Input.GetMouseButtonDown(0)) score++;
        Debug.Log(score);

        switch(score)
        {
            case 10:
                state = State.OneGearUp;
                break;
            case 20:
                state = State.TwoGearUp;
                break;
        }

        if (state == State.Normal) speed = 0.1f;
        else if (state == State.OneGearUp) speed = 0.5f;
        else if (state == State.TwoGearUp) speed = 1.0f;

        // �ړ�
        transform.position = Vector2.MoveTowards(transform.position, targetObject.transform.position, speed);
    }
}
