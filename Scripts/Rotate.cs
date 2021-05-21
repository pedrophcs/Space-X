using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//  ---------------------------------------------------- ROTAÇÃO DO ASTEROIDE
public class Rotate : MonoBehaviour
{
    private float rotateSpeed;
    void Start()
    {
        rotateSpeed = Random.Range(-200, 200);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotateSpeed) * Time.deltaTime);
    }
}
