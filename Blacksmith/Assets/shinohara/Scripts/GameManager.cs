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
    
    [SerializeField]
    private GameObject gameButton;

    private TextMeshProUGUI gameStateText;

    private float time = 5;
    private bool endFlag = true;
    
    private enum gameState
    {
        Title,
        InGame,
        Result
    }

    private gameState _currentState = gameState.Title;

    private void Start()
    {
        gameStateText = gameButton.GetComponentInChildren<TextMeshProUGUI>();
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        time -= 0.03666f;
        Debug.Log(time);
    }

    private void LateUpdate()
    {
        switch (_currentState)
        {
            case gameState.Title:
                gameStateText.text = "Start";
                break;
            case gameState.InGame:
                gameButton.SetActive(false);
                if (time <= 0)
                {
                    Debug.Log(endFlag);
                    if(endFlag) StartCoroutine(waitCorutine(1f));
                    endFlag = false;
                }
                break;
            case gameState.Result:
                SceneManager.LoadScene("Result");
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
    }

    IEnumerator waitCorutine(float waitSecond)
    {
        gameButton.SetActive(true);
        gameStateText.text = "GameOver";
        yield return new WaitForSeconds(waitSecond);
        _currentState = gameState.Result;
    }
    
}
