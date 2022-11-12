using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandBag : MonoBehaviour {
    float time; // タイム
    public const float initTime = 3.0f; // タイム初期値
    public const float multiPosition = 10.0f; // 移動先の調整用変数
    bool isStan;
    Vector2[] randomPosition = { new Vector2(0.0f, 0.0f),
                                 new Vector2(1.0f, 1.0f),
                                 new Vector2(-1.0f, 0.0f),
                                 new Vector2(0.0f, -1.0f),
                                 new Vector2(1.0f, 0.0f),
                                 new Vector2(0.0f, 1.0f),
                                 new Vector2(1.0f, -1.0f),
                                 new Vector2(-1.0f, 1.0f)}; // 移動先座標の配列

    // 初期化処理
    void Start() {
        time = initTime; // タイム初期化
    }

    // 更新処理
    void Update() {
        RandomMove(); // ランダム移動
    }

    // ランダム移動処理
    void RandomMove() {
        time -= Time.deltaTime; // タイム経過

        if (time <= 0) {
            if (isStan) {
                int positionIndex = Random.Range(0, 8); // 移動先座標の要素
                transform.position = randomPosition[positionIndex] * multiPosition; // ランダム移動
            }

            time = initTime; // タイム初期化
        }
    }

    public void ItemEffect(Blacksmith.Item.Type type, bool flag) {
        //typeはまだ無視　スタンのみ
        isStan = flag;
    }
}
