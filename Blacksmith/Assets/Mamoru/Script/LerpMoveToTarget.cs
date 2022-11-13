using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpMoveToTarget : MonoBehaviour
{
    enum State
    {
        Normal,    // 通常状態
        OneGearUp, // 1段進化状態
        TwoGearUp, // 2段進化状態
    }

    public GameObject targetObject; // 移動先オブジェクト
    GameObject scoreManager; // スコアマネージャーを取得
    GameObject gameManager; // ゲームマネージャー
    RandomMove randomMoveScript;
    ScoreManager scoreManagerScript;
    GameManager gameManagerScript;
    [SerializeField] float speed = 0.1f; // スピード
    public float timerMin = 1.0f;
    public float timerMax = 4.0f;
    int score;
    State state = State.Normal; // 状態を取得
    bool isStan; // スタンしたかどうか
    bool isStartes; // ゲームスタートしたかどうか

    void Start()
    {
        // スコアマネージャースクリプトを取得
        scoreManager = GameObject.Find("ScoreManager");
        scoreManagerScript = scoreManager.GetComponent<ScoreManager>();
        // ターゲット座標スクリプトを取得
        targetObject = GameObject.Find("RandomMove");
        randomMoveScript = targetObject.GetComponent<RandomMove>();
        // ゲームマネージャースクリプトを取得
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
                // 状態遷移
                StateManage(score);
                // 移動
                transform.position = Vector2.MoveTowards(transform.position, targetObject.transform.position, speed);
            }
        }
    }

    public void ItemEffect(Blacksmith.Item.Type type, bool flag)
    {
        //typeはまだ無視　スタンのみ
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
