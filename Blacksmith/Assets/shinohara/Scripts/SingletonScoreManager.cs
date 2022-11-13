using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class SingletonScoreManager : MonoBehaviour
{
    public static SingletonScoreManager instance;

    private void Awake()
    {
	    CheckInstance();
    }

    private void CheckInstance()
    {
	    if (instance == null)
	    {
		    instance = this;
	    }
	    else
	    {
		    Destroy(gameObject);
	    }
    }
}
