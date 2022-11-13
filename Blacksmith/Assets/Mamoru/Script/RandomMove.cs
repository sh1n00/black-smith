using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMove : MonoBehaviour
{
    float timer; // �o�ߎ���
    [SerializeField] float initTimerMin = 1.0f; // ���Z�b�g���ԁi�ŏ��l�j
    [SerializeField] float initTimerMax = 4.0f; // ���Z�b�g���ԁi�ő�l�j
    //public float multiPosition = 10.0f; // �ړ���̒����p�ϐ�
    [SerializeField] Transform[] randomPosition;

    // Start is called before the first frame update
    void Start()
    {
        // �o�ߎ��ԏ�����
        timer = 0.0f; 
    }

    // Update is called once per frame
    void Update()
    {
        // ���Ԍo��
        timer -= Time.deltaTime;
        if (timer <= 0.0f)
        {
            // �w�肵�����W�Ƀ����_���ړ�
            int random = Random.Range(0, randomPosition.Length);
            Vector2 targetPosition = randomPosition[random].position; //* multiPosition;
            transform.position = targetPosition;
            timer = Random.Range(initTimerMin, initTimerMax);
        }
    }
}
