using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectColorer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Changes the color of a chosen object to black
        gameObject.GetComponent<Renderer>().material.color = Color.black;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
