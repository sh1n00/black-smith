using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ResultManager : MonoBehaviour
{
    public int Score { get; set; } = 5000;
    private int _num;

    [SerializeField]
    private Animator _anim;

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

    [SerializeField]
    private Text _enemyNumText;

    // Start is called before the first frame update
    void Start()
    {
        _enemySpawnPosFirst = _enemySpawnPos.transform.position;
        _num = Score / 100;
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
                _isCameraMove = false;
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
