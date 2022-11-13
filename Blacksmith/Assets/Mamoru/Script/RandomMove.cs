using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMove : MonoBehaviour
{
    float timer; // 経過時間
    [SerializeField] float initTimerMin = 1.0f; // リセット時間（最小値）
    [SerializeField] float initTimerMax = 4.0f; // リセット時間（最大値）
    //public float multiPosition = 10.0f; // 移動先の調整用変数
    [SerializeField] Transform[] randomPosition;

    // Start is called before the first frame update
    void Start()
    {
        // 経過時間初期化
        timer = 0.0f; 
    }

    // Update is called once per frame
    void Update()
    {
        // 時間経過
        timer -= Time.deltaTime;
        if (timer <= 0.0f)
        {
            // 指定した座標にランダム移動
            int random = Random.Range(0, randomPosition.Length);
            Vector2 targetPosition = randomPosition[random].position; //* multiPosition;
            transform.position = targetPosition;
            timer = Random.Range(initTimerMin, initTimerMax);
        }
    }
}
