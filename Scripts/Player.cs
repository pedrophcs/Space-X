using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ------------------- enum para os Power Ups
public enum ItemEffect
{
    shield, levelUp, special
}

public class Player : MonoBehaviour
{

    private float speed = 5;  //  Velocidade do Player
    private float nextEnemy;  //  Variável para intervalo dos disparos
    private bool isDead = false;  //  Variável apra identificar se o Player está vivo
    [SerializeField] private float spawnTime;  //  Tempo para o Player ressurgir depois que perde 1 vida
    [SerializeField] private float InvencibilityTime;  // Tempo em que o Player fica inalvejavel depois que perde 1 vida
    [SerializeField] private float fireRate;  //  Variável usada para o intervalo dos disparos
    [SerializeField] public int fireLevel;  //  Identificar o nível do tiro
    [SerializeField] private int lives = 3;  //  Variável que determina a vida do Player
    [SerializeField] private int specialLevel;  //  Quantidade de cargas para o Special

    public GameObject shield;  //  Pega o escudo
    public GameObject laser, laser2;  //  Pega o Special (os 2 são instanciados ao mesmo tempo)
    public Transform[] bulletControl;  //  Posições de onde serão instanciados os bullets
    public GameObject bullet;  //  Variável para pegar o bullet do Player
    private SpriteRenderer sprite;  //  Pegar sprite do Player para desativa-lo quando "morrer"
    private Vector3 startPosition;  //  Posição inicial do Player
    private CaracterLife caracterLife;  //  Pegar componentende desse script

    void Start()
    {
        caracterLife = GetComponent<CaracterLife>();
        startPosition = transform.position;
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // ------------------------- Limite do Player na tela
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -7, 7), Mathf.Clamp(transform.position.y, -4.20f, 1.20f));

        // ------------------------- Comandos do Player no jogo
        if (!isDead)  // ------------------------- Só entra quando está vivo
        {
            Move();
            if (Input.GetButton("Fire1") && Time.time > nextEnemy)
            {
                Disparo();
            }

            if (Input.GetKeyDown(KeyCode.Space) && specialLevel > 0)
            {
                Special();
            }
        }
    }

    // ------------------------- Movimentação
    public void Move()
    {
        var h = Input.GetAxisRaw("Horizontal");
        var v = Input.GetAxisRaw("Vertical");
        transform.Translate(Vector3.up * v * speed * Time.deltaTime);
        transform.Translate(Vector3.right * h * speed * Time.deltaTime);
    }
    // ------------------------- Tiro especial
    public void Special()
    {
        Instantiate(laser, transform);
        Instantiate(laser2, transform);
        specialLevel--;
    }
    // ------------------------- Tiro normal
    public void Disparo()
    {
        if (!isDead)
        {
            nextEnemy = fireRate + Time.time;
            if (fireLevel >= 1)
            {
                Instantiate(bullet, bulletControl[0].position, bulletControl[0].rotation);
            }
            if (fireLevel >= 2)
            {
                Instantiate(bullet, bulletControl[1].position, bulletControl[1].rotation);
                Instantiate(bullet, bulletControl[2].position, bulletControl[2].rotation);
            }
            if (fireLevel >= 3)
            {
                Instantiate(bullet, bulletControl[3].position, bulletControl[3].rotation);
                Instantiate(bullet, bulletControl[4].position, bulletControl[4].rotation);
            }
        }
    }
    // ------------------------- Respawn do jogador
    public void Respawn()
    {
        lives--;
        if (lives > 0)
        {
            StartCoroutine(Spawning());
        }
        else
        {
            lives = 0;
            isDead = true;
            sprite.enabled = false;
            LevelController.levelController.GameOver();
        }
        LevelController.levelController.SetLivesText(lives);
    }
    // ------------------------- Spawn do Player depois de perder uma vida
    IEnumerator Spawning()
    {
        isDead = true;
        sprite.enabled = false;
        if (fireLevel > 1)
            fireLevel--;
        gameObject.layer = 9;
        yield return new WaitForSeconds(spawnTime);
        isDead = false;
        transform.position = startPosition;
        for (float i = 0; i < InvencibilityTime; i += 0.1f)
        {
            sprite.enabled = !sprite.enabled;
            yield return new WaitForSeconds(0.1f);
        }
        gameObject.layer = 6;
        sprite.enabled = true;
        caracterLife.isDead = false;
    }
    // ------------------------- Método dos Power Ups
    public void SetItemEffect(ItemEffect effect)
    {
        if (effect == ItemEffect.levelUp)
        {
            fireLevel++;
            if (fireLevel >= 3)
                fireLevel = 3;
        }
        else if (effect == ItemEffect.special)
        {
            specialLevel++;
            LevelController.levelController.SetSpecial(specialLevel);
        }
        else if (effect == ItemEffect.shield)
        {
            Instantiate(shield, transform);
        }
    }

}
