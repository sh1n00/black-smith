using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMove : MonoBehaviour
{
    float timer; // �o�ߎ���
    [SerializeField] float initTimerMin = 1.0f; // ���Z�b�g���ԁi�ŏ��l�j
    [SerializeField] float initTimerMax = 4.0f; // ���Z�b�g���ԁi�ő�l�j
    public float multiPosition = 10.0f; // �ړ���̒����p�ϐ�
    Vector3[] randomPosition = { new Vector2(0.0f, 0.0f),
                                 new Vector2(1.0f, 1.0f),
                                 new Vector2(-1.0f, 0.0f),
                                 new Vector2(0.0f, -1.0f),
                                 new Vector2(1.0f, 0.0f),
                                 new Vector2(0.0f, 1.0f),
                                 new Vector2(1.0f, -1.0f),
                                 new Vector2(-1.0f, 1.0f)}; // �ړ�����W�̔z��

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
            Vector2 targetPosition = randomPosition[random] * multiPosition;
            transform.position = targetPosition;
            timer = Random.Range(initTimerMin, initTimerMax);
            Debug.Log("���Z�b�g����" + timer);
        }
    }
}
