using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverRedEnemy : MonoBehaviour
{
    [SerializeField] private float speed;  //  Velocidade do inimigo
    private Rigidbody2D rdb;  //  Rigidbody do inimigo
    private float target;  //  Variável para determinar a movimentação do inimigo
    public Vector2 startWait;  //  Variável para startar
    void Start()
    {
        rdb = GetComponent<Rigidbody2D>();
        StartCoroutine(Evade());
    }
    private void FixedUpdate()
    {
        float newMover = Mathf.MoveTowards(rdb.velocity.x, target, speed);
        rdb.velocity = new Vector2(newMover, rdb.velocity.y);

        rdb.position = new Vector2(Mathf.Clamp(rdb.position.x, -7, 7), Mathf.Clamp(rdb.position.y, -7, 7));
    }

    IEnumerator Evade()
    {
        yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y));  //TEMPO PARA INICIAÇÃO DA CORROTINA
        while(true)                                                               //LOOP INFINITO(SEMPRE VERDADEIRO)
        {
            target = Random.Range(1, 5) * -Mathf.Sign(transform.position.x);      //MUDAR VALOR DE TARGET / RETORNAR VALOR AO CONTRARIO
            yield return new WaitForSeconds(Random.Range(2, 5));                  //TEMPO PARA MUDAR DE POSIÇÃO
            target = 0;                                                           //ZERAR O TARGET
            yield return new WaitForSeconds(Random.Range(1, 5));                  //TEMPO PARA MUDAR DE POSIÇÃO
        }
    }
}
