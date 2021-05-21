using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//  ---------------------------------------------------- SCRIPT PARA DESTRUIR O OBJETO QUE O POSSUI POR DETERMINADO TEMPO
public class DestroyGameObject : MonoBehaviour
{
    public float destroyTime;
    void Start()
    {
        Destroy(gameObject, destroyTime);
    }
}

