using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandBag : MonoBehaviour
{
    int score = 0; // スコア
    float time; // タイムインターバル
    const float initTime = 3.0f; // タイム初期値
    const float randomRangeMin = -15.0f; // ランダム移動最小値
    const float randomRangeMax = 15.0f; // ランダム移動最大値

    // Start is called before the first frame update
    void Start()
    {
        time = initTime; // タイム初期化
    }

    // Update is called once per frame
    void Update()
    {
        ScoreUp(); // スコアアップ
        RandomMove(); // ランダム移動
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
            time = initTime; // タイム初期化
        }
    }
}
