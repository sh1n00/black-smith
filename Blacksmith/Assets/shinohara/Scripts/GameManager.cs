using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{

    private GameObject _rootCanvas;

    private static GameObject rootCanvas;
    private GameObject gameButton;

    private TextMeshProUGUI gameStateText;

    private float time = 5;
    private bool endFlag = false;
    
    private enum gameState
    {
        Title,
        InGame,
        Result,
        GameOver
    }

    private static gameState _currentState = gameState.Title;

    private void Awake()
    {
        _rootCanvas = GameObject.Find("Canvas");
        rootCanvas = _rootCanvas;
        //gameButton = rootCanvas.GetComponentInChildren<GameObject>();
        gameButton = rootCanvas.transform.GetChild(0).gameObject;
        gameStateText = gameButton.GetComponentInChildren<TextMeshProUGUI>();
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(rootCanvas);
    }
    
    private void Start()
    {
        Application.targetFrameRate = 60;
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
                _currentState = gameState.GameOver;
                break;
            case gameState.GameOver:
                gameButton.SetActive(true);
                gameStateText.text = "Restart";
                break;
        }
    }

    public void OnButtonClickStart()
    {
        _currentState = gameState.InGame;
    }
    
    public void OnButtonClickTitle()
    {
        _currentState = gameState.Title;
        SceneManager.LoadScene("MainScene");
    }

    IEnumerator waitCorutine(float waitSecond)
    {
        gameButton.SetActive(true);
        gameStateText.text = "GameOver";
        yield return new WaitForSeconds(waitSecond);
        _currentState = gameState.Result;
    }
    
}
