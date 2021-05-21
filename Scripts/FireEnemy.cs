using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//  ---------------------------------------------------- SCRIPT VOLTADO PARA O TIRO DO INIMIGO VERMELHO
public class FireEnemy : MonoBehaviour
{
    public GameObject bullet;  //  Pega o bullet
    public float fireRate;  //  Tempo entre os bullets instaciados
    public Transform[] spawnShot;  //  Local onde vai ser instanciado o bullet
    void Start()
    {
        InvokeRepeating("Fire", fireRate, fireRate);
    }
    public void Fire()
    {
        for (int i = 0; i < spawnShot.Length; i++)
        {
            Instantiate(bullet, spawnShot[i].position, spawnShot[i].rotation);
        }
    }
}
