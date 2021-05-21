using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaracterLife : MonoBehaviour
{
    private static int chanceToDropItem = 0;  // Vari�vel para controlar as chances de cair um Power Up 
    private SpriteRenderer sprite;  // Vari�vel para alterar a cor dos sprites (Hit)
    public GameObject explosion;  // Vari�vel de explos�o para o player e inimigos
    public GameObject[] dropItems;  // Vetor que dropa os Power Ups
    public Color damageColor;  // Vari�vel que muda a cor do sprite quando leva dano
    public int health;  // Vida de todos os objetos
    public int scorePoints;  // Valor dos scores nos inimigos
    [HideInInspector]
    public bool isDead = false;  // Vari�vel para identificar se o objeto est� vivo
    
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // ------------- M�todo para vida do objeto
    public void TakeDamage(int damage)
    {
        if(!isDead)  // ------------- Verifica se n�o est� morto
        {
            health -= damage;
            if(health <= 0)  // ------------- Quando estiver morto
            {
                isDead = true;
                if(explosion != null)
                Instantiate(explosion, transform.position, transform.rotation);
                if(this.GetComponent<Player>() != null)  // ------------- Verifica se � o Player
                {
                    GetComponent<Player>().Respawn();
                }
                else    // ------------- Se n�o for o Player
                {
                    chanceToDropItem++;
                    int random = Random.Range(0, 100);
                    if(random< chanceToDropItem && dropItems.Length > 0)
                    {
                        Instantiate(dropItems[Random.Range(0, dropItems.Length)], transform.position, Quaternion.identity);
                        chanceToDropItem = 0;
                    }
                    LevelController.levelController.SetScore(scorePoints);
                   
                    Destroy(gameObject);
                }
            }
            else
            {
                StartCoroutine(TakingDamage());
            }

        }
    }
    // ------------- Pisca a cor do sprite quando leva dano
    IEnumerator TakingDamage()
    {
        sprite.color = damageColor;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    }
}
