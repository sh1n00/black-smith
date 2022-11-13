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
    GameObject gameManager; // �Q�[���}�l�[�W���[
    RandomMove randomMoveScript;
    ScoreManager scoreManagerScript;
    GameManager gameManagerScript;
    [SerializeField] float speed = 0.1f; // �X�s�[�h
    public float timerMin = 1.0f;
    public float timerMax = 4.0f;
    int score;
    State state = State.Normal; // ��Ԃ��擾
    bool isStan; // �X�^���������ǂ���
    bool isStartes; // �Q�[���X�^�[�g�������ǂ���

    void Start()
    {
        // �X�R�A�}�l�[�W���[�X�N���v�g���擾
        scoreManager = GameObject.Find("ScoreManager");
        scoreManagerScript = scoreManager.GetComponent<ScoreManager>();
        // �^�[�Q�b�g���W�X�N���v�g���擾
        targetObject = GameObject.Find("RandomMove");
        randomMoveScript = targetObject.GetComponent<RandomMove>();
        // �Q�[���}�l�[�W���[�X�N���v�g���擾
        gameManager = GameObject.Find("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();

        timerMin = randomMoveScript.initTimerMin;
        timerMax = randomMoveScript.initTimerMax;
        score = scoreManagerScript.Score;
        isStartes = gameManagerScript.isStartedTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (isStartes)
        {
            if (!isStan)
            {
                // ��ԑJ��
                StateManage(score);
                // �ړ�
                transform.position = Vector2.MoveTowards(transform.position, targetObject.transform.position, speed);
            }
        }
    }

    public void ItemEffect(Blacksmith.Item.Type type, bool flag)
    {
        //type�͂܂������@�X�^���̂�
        isStan = flag;
    }

    private void StateManage(int scoreValue)
    {
        switch (scoreValue)
        {
            case 10:
                state = State.OneGearUp;
                break;
            case 20:
                state = State.TwoGearUp;
                break;
        }

        if (state == State.Normal)
        {
            speed = 0.1f;
        }
        else if (state == State.OneGearUp)
        {
            speed = 0.5f;
            timerMin = 1.0f;
            timerMax = 3.0f;
        }
        else if (state == State.TwoGearUp)
        {
            speed = 1.0f;
            timerMin = 0.2f;
            timerMax = 2.0f;
        }
    }
}
