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
    private GameObject stateObject;

    [SerializeField]
    public TextMeshProUGUI gameStateText;
    
    private enum gameState
    {
        Title,
        InGame,
        Result
    }

    private gameState _currentState;
    
    // Start is called before the first frame update
    void Start()
    {
        _currentState = gameState.Title;
    }
    
    private void Update()
    {
        switch (_currentState)
        {
            case gameState.Title:
                if (Input.GetMouseButton(0))
                {
                    Debug.Log("Title 2 InGame");
                    gameStateText.text = "InGame";
                }
                break;
            case gameState.InGame:
                if (Input.GetMouseButton(0))
                {
                    Debug.Log("InGame 2 Result");
                    gameStateText.text = "Result";
                    _currentState = gameState.Result;
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
    
    private void OnButtonClickTitle()
    {
        _currentState = gameState.Title;
    }
}
