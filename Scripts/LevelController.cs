using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController levelController;
    public Text recordText;  //  Variável que pega o Record
    public Text scoreText;  //  Variável que pega o Score
    public GameObject gameOverText;  //  Variável para ativar e desativar a mensagem de GameOver
    public GameObject[] enemies;  //  Vetor de inimigos que serão instaciados
    public GameObject pause;  //  Variável para ir para o texto "Pause"
    public Vector2 spawnWait;  //  Vector para pegar 2 valores e colocar no método "SpawnWaves"
    public float waveWait;  //  
    public float waveWaitMin;
    public float spawnWaitMin;
    public int enemyCountMax = 10;

    private int score;
    private int enemyCount = 1;
    private bool gameOver = false;
    private bool isPause = false;
    
    [SerializeField] private Text textSpecial;
    [SerializeField] private Text textLives;
    [SerializeField] private float startWait;
    void Start()
    {
        levelController = this;
        StartCoroutine(SpawnWaves());
    }
    void Update()
    {
        if (gameOver)
        {
            if (Input.GetMouseButton(0))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        if (isPause == false && Input.GetKeyDown(KeyCode.P) && !gameOver)
        {
            Time.timeScale = 0;
            pause.SetActive(true);
            isPause = true;
        }
        else if (isPause == true && Input.GetKeyDown(KeyCode.P) && !gameOver)
        {
            Time.timeScale = 1;
            pause.SetActive(false);
            isPause = false;

        }
    }
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (!gameOver)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                GameObject enemy = enemies[Random.Range(0, enemies.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-7, 7), 7, 0);
                Instantiate(enemy, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(Random.Range(spawnWait.x, spawnWait.y));
            }
            enemyCount++;
            if (enemyCount >= enemyCountMax)
            {
                enemyCount = enemyCountMax;
                spawnWait.x -= 0.1f;
                spawnWait.y -= 0.1f;
            }
            if (spawnWait.y <= spawnWaitMin)
            {
                spawnWait.y = spawnWaitMin;
            }
            if (spawnWait.x <= spawnWaitMin)
            {
                spawnWait.x = spawnWaitMin;
            }
            yield return new WaitForSeconds(waveWait);
            waveWait -= 0.1f;
            if (waveWait <= waveWaitMin)
            {
                waveWait = waveWaitMin;
            }
        }
    }
    public void SetLivesText(int lives)
    {
        textLives.text = lives.ToString();
    }
    public void SetScore(int scorePoints)
    {
        score += scorePoints;
        scoreText.text = score.ToString();
    }
    public void SetSpecial(int special)
    {
        textSpecial.text = special.ToString();
    }
    public void GameOver()
    {
        gameOver = true;
        gameOverText.SetActive(true);
        if (PlayerPrefs.GetInt("MaxScore") < score)
            PlayerPrefs.SetInt("MaxScore", score);

        recordText.text = "Record: " + PlayerPrefs.GetInt("MaxScore");

    }
    
}
