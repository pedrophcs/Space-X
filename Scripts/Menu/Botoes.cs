using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Botoes : MonoBehaviour
{
    public GameObject telaMenu,telaInstrucoes;  // Variáveis para trocar da tela menu para instruções
    
    // ---------------- Carregar a cena do jogo
    public void Jogar()
    {
        SceneManager.LoadScene(1);
    }
    // ---------------- Botão sair
    public void Sair()
    {
        Application.Quit();
    }
    // ---------------- Botão para ir ás instruções
    public void ComoJogar()
    {
        telaMenu.SetActive(false);
        telaInstrucoes.SetActive(true);
    }
    // ---------------- Botão para voltar ao menu
    public void VoltarMenu()
    {
        telaInstrucoes.SetActive(false);
        telaMenu.SetActive(true);
    }
}
