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
    }
    
    
    private void Update()
    {
        switch (_currentState)
        {
            case gameState.Title:
                gameStateText.text = "Start";
                break;
            case gameState.InGame:
                gameButton.SetActive(false);
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
}
