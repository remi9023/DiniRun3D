using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class DinoController : MonoBehaviour
{
    public float zmoveSpeed;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position += Vector3.forward * Time.deltaTime * zmoveSpeed;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(-0.2f,0,0); 
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(0.2f, 0, 0);
        }
    }
}
