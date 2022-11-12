using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandBag : MonoBehaviour {
    float time; // �^�C��
    public const float initTime = 3.0f; // �^�C�������l
    public const float multiPosition = 10.0f; // �ړ���̒����p�ϐ�
    bool isStan;
    Vector2[] randomPosition = { new Vector2(0.0f, 0.0f),
                                 new Vector2(1.0f, 1.0f),
                                 new Vector2(-1.0f, 0.0f),
                                 new Vector2(0.0f, -1.0f),
                                 new Vector2(1.0f, 0.0f),
                                 new Vector2(0.0f, 1.0f),
                                 new Vector2(1.0f, -1.0f),
                                 new Vector2(-1.0f, 1.0f)}; // �ړ�����W�̔z��

    // ����������
    void Start() {
        time = initTime; // �^�C��������
    }

    // �X�V����
    void Update() {
        RandomMove(); // �����_���ړ�
    }

    // �����_���ړ�����
    void RandomMove() {
        time -= Time.deltaTime; // �^�C���o��

        if (time <= 0) {
            if (isStan) {
                int positionIndex = Random.Range(0, 8); // �ړ�����W�̗v�f
                transform.position = randomPosition[positionIndex] * multiPosition; // �����_���ړ�
            }

            time = initTime; // �^�C��������
        }
    }

    public void ItemEffect(Blacksmith.Item.Type type, bool flag) {
        //type�͂܂������@�X�^���̂�
        isStan = flag;
    }
}
