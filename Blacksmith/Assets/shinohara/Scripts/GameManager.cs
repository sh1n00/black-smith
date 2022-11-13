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

    private GameObject scoreManagerObject;
    private ScoreManager scoreManager;
    [SerializeField] private SoundManager soundManager;
    
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject Target;
    
    [SerializeField]
    private GameObject gameButton;

    [SerializeField]
    private TextMeshProUGUI timeText;
    [SerializeField]
    private TextMeshProUGUI displayText;
    private TextMeshProUGUI gameStateText;

    [SerializeField] GameObject title;
    [SerializeField] Image count;
    [SerializeField] Sprite[] threeCounts;
    [SerializeField] Sprite goSprite;
    

    private bool isEnded = true;
    private bool isStartedCountDown = false;
    public bool isStartedTimer = false;
    
    private float timeLimited = 5;
    
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
        scoreManager.ResetScore();
        DontDestroyOnLoad(scoreManager);
    }

    private void Awake()
    {
        scoreManagerObject = GameObject.Find("ScoreManager");
        scoreManager = scoreManagerObject.GetComponent<ScoreManager>();
        gameStateText = gameButton.GetComponentInChildren<TextMeshProUGUI>();
        Target.SetActive(false);
        timeText.text = "";
    }

    private void Update()
    {
        if (isStartedTimer)
        {
            timeLimited -= consumeTime;
            timeText.text = "Time: " + (int)timeLimited;
        }
    }

    private void LateUpdate()
    {
        switch (_currentState)
        {
            case gameState.Title:
                gameButton.SetActive(true);
                gameStateText.text = "Start";
                displayText.text = "";
                break;
            case gameState.InGame:
                Target.SetActive(true);
                gameButton.SetActive(false);
                if(isStartedCountDown) StartCoroutine(countDown());
                if (timeLimited <= 0)
                {
                    displayText.text = "Finish";
                    Player.SetActive(false);
                    Target.SetActive(false);
                    if(isEnded) StartCoroutine(waitCorutine(1f));
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
        title.SetActive(false);
        _currentState = gameState.InGame;
        isStartedCountDown = true;
    }

    IEnumerator waitCorutine(float waitSecond)
    {
        isEnded = false;
        soundManager.endGongPlay();
        yield return new WaitForSeconds(waitSecond);
        _currentState = gameState.Result;
    }

    IEnumerator countDown()
    {
        timeText.text = "Time: " + timeLimited;
        isStartedCountDown = false;
        count.gameObject.SetActive(true);
        count.sprite = threeCounts[0];
        soundManager.coundDownPlay();
        yield return new WaitForSeconds(1.0f);
        count.sprite = threeCounts[1];
        soundManager.coundDownPlay();
        yield return new WaitForSeconds(1.0f);
        count.sprite = threeCounts[2];
        soundManager.coundDownPlay();
        yield return new WaitForSeconds(1.0f);
        count.sprite = goSprite;
        soundManager.startGongPlay();
        yield return new WaitForSeconds(1.0f);
        count.gameObject.SetActive(false);
        displayText.text = "";
        isStartedTimer = true;
        soundManager.bgmPlay();
    }

}
