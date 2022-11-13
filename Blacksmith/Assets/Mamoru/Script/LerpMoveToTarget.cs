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
    ScoreManager scoreManagerScript;
    [SerializeField] float speed = 0.1f; // スピード
    State state = State.Normal;
    //int score;

    void Start()
    {
        // スコアマネージャースクリプトを取得
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

        // 移動
        transform.position = Vector2.MoveTowards(transform.position, targetObject.transform.position, speed);
    }
}
