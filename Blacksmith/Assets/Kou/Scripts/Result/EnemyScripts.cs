using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScripts : MonoBehaviour
{
    [SerializeField]
    private Animator _anim;

    [SerializeField]
    private GameObject _camera;
    [SerializeField]
    private Vector3 _cameraPos;
    [SerializeField]
    private Vector3 _thisPos;
    private bool _isDie = false;

    void Start()
    {
        _camera = GameObject.FindWithTag("MainCamera");
        _thisPos = this.transform.position;
        _anim = this.gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        _cameraPos = _camera.transform.position;
        if(!_isDie)
        {
            if(_thisPos.x <= _cameraPos.x)
            {
                int num = Random.Range(1, 6);
                _anim.SetInteger("SmashType",num);
                Invoke("Destroy", 0.8f);
                _isDie = true;
            }
        }
    }

    void Destroy()
    {
        Destroy(gameObject);
    }
}