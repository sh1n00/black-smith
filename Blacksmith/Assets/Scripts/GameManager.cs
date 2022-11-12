using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
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
                    _currentState = gameState.InGame;
                }
                break;
            case gameState.InGame:
                if (Input.GetMouseButton(0))
                {
                    Debug.Log("GameOver");
                    _currentState = gameState.Result;
                }

                break;
            case gameState.Result:
                

        }
    }
}
