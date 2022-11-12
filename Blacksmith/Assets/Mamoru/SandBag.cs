using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandBag : MonoBehaviour
{
    int score = 0;
    [SerializeField] float time = 3.0f;
    [SerializeField] const float randomRangeMin = -30.0f;
    [SerializeField] const float randomRangeMax = 30.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            this.score++;
            Debug.Log(this.score);
        }

        if (time <= 0)
        {
            float randomMoveX = Random.Range(randomRangeMin, randomRangeMax);
            transform.position = new Vector2(randomMoveX, 0.0f);
            time = 3.0f;
        }
    }
}
