using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandBag : MonoBehaviour {
    public float time; // タイム
    public float moveTime = 1.0f;
    public float initTime = 3.0f; // タイム初期値
    public float multiPosition = 10.0f; // 移動先の調整用変数
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
                                 new Vector2(-1.0f, 1.0f)}; // 移動先座標の配列

    // 初期化処理
    void Start() {
        time = initTime; // タイム初期化
    }

    // 更新処理
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

    // ランダム移動処理
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
        //typeはまだ無視　スタンのみ
        isStan = flag;
    }

    void Wait()
    {
        time -= Time.deltaTime; // タイム経過

        if (time <= 0)
        {
            //if (!isStan)
            //{
                //int positionIndex = Random.Range(0, 8); // 移動先座標の要素
                //transform.position = randomPosition[positionIndex] * multiPosition; // ランダム移動
            //}

            time = moveTime; // タイム初期化
            isMove = true;
        }
    }
}
