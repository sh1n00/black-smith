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

    private GameObject _rootCanvas;

    private GameObject rootCanvas;
    private GameObject gameButton;

    private TextMeshProUGUI gameStateText;

    private float time = 5;
    private bool endFlag = false;
    
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
        rootCanvas = GameObject.Find("Canvas");
        gameButton = rootCanvas.transform.GetChild(0).gameObject;
        gameStateText = gameButton.GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (endFlag)
        {
            time -= 0.03666f;
        }
    }

    private void LateUpdate()
    {
        switch (_currentState)
        {
            case gameState.Title:
                gameStateText.text = "Start";
                endFlag = true;
                break;
            case gameState.InGame:
                gameButton.SetActive(false);
                if (time <= 0)
                {
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
        gameButton.SetActive(true);
        gameStateText.text = "GameOver";
        yield return new WaitForSeconds(waitSecond);
        _currentState = gameState.Result;
    }
    
}
