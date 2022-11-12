using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandBag : MonoBehaviour
{
    int score = 0; // �X�R�A
    float time; // �^�C���C���^�[�o��
    const float initTime = 3.0f; // �^�C�������l
    const float randomRangeMin = -15.0f; // �����_���ړ��ŏ��l
    const float randomRangeMax = 15.0f; // �����_���ړ��ő�l

    // Start is called before the first frame update
    void Start()
    {
        time = initTime; // �^�C��������
    }

    // Update is called once per frame
    void Update()
    {
        ScoreUp(); // �X�R�A�A�b�v
        RandomMove(); // �����_���ړ�
    }

    void ScoreUp()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.score++;
            Debug.Log(this.score);
        }
    }

    void RandomMove()
    {
        time -= Time.deltaTime;

        if (time <= 0)
        {
            float randomMoveX = Random.Range(randomRangeMin, randomRangeMax);
            transform.position = new Vector2(randomMoveX, 0.0f);
            time = initTime; // �^�C��������
        }
    }
}
