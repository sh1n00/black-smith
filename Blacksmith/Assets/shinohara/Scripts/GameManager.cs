using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private GameObject rootCanvas;
    [SerializeField]
    private GameObject gameButton;

    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject Target;

    private TextMeshProUGUI gameStateText;
    [SerializeField]
    private TextMeshProUGUI timeText;

    private float time = 5;
    private bool endFlag = false;
    
    private const float consumeTime = 0.01666f;
    
    private enum gameState
    {
        Title,
        InGame,
        Result,
    }

    private static gameState _currentState = gameState.Title;

    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    private void Awake()
    {
        gameStateText = gameButton.GetComponentInChildren<TextMeshProUGUI>();
        Target.SetActive(false);
        timeText.text = "";
    }

    private void Update()
    {
        if (endFlag)
        {
            time -= consumeTime;
            timeText.text = "Time: " + (int)time;
        }
    }

    private void LateUpdate()
    {
        switch (_currentState)
        {
            case gameState.Title:
                gameStateText.text = "Start";
                break;
            case gameState.InGame:
                Target.SetActive(true);
                endFlag = true;
                gameButton.SetActive(false);
                if (time <= 0)
                {
                    gameButton.SetActive(true);
                    gameStateText.text = "Finish";
                    Player.SetActive(false);
                    Target.SetActive(false);
                    if(endFlag) StartCoroutine(waitCorutine(1f));
                    endFlag = false;
                }
                break;
            case gameState.Result:
                SceneManager.LoadScene("Result");
                _currentState = gameState.Title;
                break;
        }
    }

    public void OnButtonClickStart()
    {
        _currentState = gameState.InGame;
    }
    

    IEnumerator waitCorutine(float waitSecond)
    {
        yield return new WaitForSeconds(waitSecond);
        _currentState = gameState.Result;
    }
    
}
