using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
public class ResultManager : MonoBehaviour
{
    private int _num;

    [SerializeField]
    private Animator _anim;

    private GameObject scoreManagerObject;
    private ScoreManager scoreManager;

    [SerializeField]
    private GameObject _camera;
    private bool _isCameraMove = false;
    private bool _isCameraBack = false;
    [SerializeField]
    private float _dameraSpeed = 0.1f;
    [SerializeField]
    private float _dameraSpeedGap = 0.01f;

    [SerializeField]
    private GameObject _enemySpawnPos;
    private Vector3 _enemySpawnPosFirst;
    [SerializeField]
    private GameObject _enemySandbag;


    //Particle
    [SerializeField]
    private GameObject _enemyParticle;

    [SerializeField]
    private Text _enemyNumText;

    // Start is called before the first frame update
    void Start()
    {
        scoreManagerObject = GameObject.Find("ScoreManager");
        scoreManager = scoreManagerObject.GetComponent<ScoreManager>();
        Debug.Log(scoreManager.Score);
        _enemySpawnPosFirst = _enemySpawnPos.transform.position;
        _num = scoreManager.Score / 100;
        _enemyNumText.text = _num.ToString();
        _anim = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnButtonClickTitle()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void FixedUpdate()
    {
        if(_isCameraMove)
        {
            _camera.transform.position += new Vector3(_dameraSpeed, 0, 0);
            _dameraSpeed += _dameraSpeedGap;         
            if(_camera.transform.position.x >= _enemySpawnPosFirst.x + 2.5f * _num)
            {
                TimeScaleSetting(0.1f);
                AnimMiddleToEnd();
                StartCoroutine(waitCorutine(0.21f));
                ChangeCameraMove(1);
            }
        }     

        if(_isCameraBack)
        {
            _camera.transform.position += new Vector3(-0.2f, 0, 0);
            if(_camera.transform.position.x <= 0.0f)
            {
                _camera.transform.position = new Vector3(0, 0, -10);
                AnimMiddleToEnd();
                ChangeCameraBack(1);
            }
        }
    }

    public void AnimSpawnEnemy()
    {
        for(int i = 0; i < _num; i++)
        {
            _enemySpawnPos.transform.position += new Vector3(2.5f, 0, 0);
            Instantiate(_enemySandbag, _enemySpawnPos.transform.position, Quaternion.identity);         
        }
    }

    public void ChangeCameraMove(int num)
    {
        if(num == 0)
        {
            _isCameraMove = true;
        }
        else
        {
            _isCameraMove = false;
        }
    }

    public void ChangeCameraBack(int num)
    {
        if(num == 0)
        {
            _isCameraBack = true;
        }
        else
        {
            _isCameraBack = false;
        }
    }

    public void CameraPosX(float num)
    {
        CameraPosSetting(new Vector3(num, 0, -10));
    }

    public void CameraPosSetting(Vector3 pos)
    {
        _camera.transform.position = pos;
    }

    public void AnimMiddleToEnd()
    {
        _anim.SetBool("MiddleToEnd", true);
    }

    public void TimeScaleSetting(float num)
    {
        Time.timeScale = num;
    }

    IEnumerator waitCorutine(float waitSecond)
    {
        yield return new WaitForSeconds(waitSecond);
        TimeScaleSetting(1.0f);
    }
}
