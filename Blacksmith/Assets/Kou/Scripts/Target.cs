using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ColorChange(Color color)
    {
        this.GetComponent<MeshRenderer>().material.color = color;
    }

    public void Hit()
    {
        ColorChange(Color.red);
    }
}
