using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandBag : MonoBehaviour {
    public float time; // �^�C��
    public float moveTime = 1.0f;
    public float initTime = 3.0f; // �^�C�������l
    public float multiPosition = 10.0f; // �ړ���̒����p�ϐ�
    bool isStan;
    public bool isMove = false;
    public bool isInit = false;
    Vector3 savePostion;
    Vector3 targetPosition;
    Vector3[] randomPosition = { new Vector2(0.0f, 0.0f),
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
        if (isMove)
        {
            RandomMove();
        }
        else
        {
            Wait();
        }
    }

    // �����_���ړ�����
    void RandomMove() {
        if (!isInit)
        {
            savePostion = transform.position;
            int random = Random.Range(0, 8);
            targetPosition = randomPosition[random] * multiPosition;
            isInit = true;
        }
        float distancePosition = Vector3.Distance(targetPosition, savePostion);
        Vector3 Dir = targetPosition - savePostion;
        Dir = Vector3.Normalize(Dir);
        float rate = (moveTime - time) / moveTime;
        transform.position = savePostion + Dir * (distancePosition * rate);
        Debug.Log(transform.position);
        time -= Time.deltaTime;
        if (time <= 0)
        {
            isMove = false;
            isInit = false;
            time = initTime;
        }
    }

    public void ItemEffect(Blacksmith.Item.Type type, bool flag) {
        //type�͂܂������@�X�^���̂�
        isStan = flag;
    }

    void Wait()
    {
        time -= Time.deltaTime; // �^�C���o��

        if (time <= 0)
        {
            //if (!isStan)
            //{
                //int positionIndex = Random.Range(0, 8); // �ړ�����W�̗v�f
                //transform.position = randomPosition[positionIndex] * multiPosition; // �����_���ړ�
            //}

            time = moveTime; // �^�C��������
            isMove = true;
        }
    }
}
