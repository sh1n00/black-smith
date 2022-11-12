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
    private TextMeshProUGUI gameStateText;
    
    private enum gameState
    {
        Stay,
        Title,
        InGame,
        Result
    }

    private gameState _currentState;
    
    // Start is called before the first frame update
    void Start()
    {
        _currentState = gameState.Stay;
    }
    
    private void Update()
    {
        switch (_currentState)
        {
            case gameState.Stay:
                break;
            case gameState.Title:
                Debug.Log("Title 2 InGame");
                gameStateText.text = "InGame";
                break;
            case gameState.InGame:
                Debug.Log("InGame 2 Result");
                gameStateText.text = "Result";
                _currentState = gameState.Result;
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
        _currentState = gameState.Stay;
    }
}
