using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform player;  //  Vari�vel  para pegar a posi��o do Player
    public float speed;  //  Vari�vel de velocidade (UFO)
    void Start()
    {
        player = FindObjectOfType<Player>().transform;
    }

    //  Comando para o "UFO" seguir o Player
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
}
