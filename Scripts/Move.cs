using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// ---------------------------------------------------- SCRIPT PARA MOVER ALGUNS OBJETOS PARA CIMA OU PARA BAIXOq
public class Move : MonoBehaviour
{
    private Rigidbody2D rdb;  //  Pega o Rigidbody do objeto
    [SerializeField] private float speed;  //  Velocidade em que vai subir ou descer
    void Start()
    {
        rdb = GetComponent<Rigidbody2D>();
        rdb.velocity = transform.up * speed;
    }
}
