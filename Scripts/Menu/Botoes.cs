using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Botoes : MonoBehaviour
{
    public GameObject telaMenu,telaInstrucoes;  // Vari�veis para trocar da tela menu para instru��es
    
    // ---------------- Carregar a cena do jogo
    public void Jogar()
    {
        SceneManager.LoadScene(1);
    }
    // ---------------- Bot�o sair
    public void Sair()
    {
        Application.Quit();
    }
    // ---------------- Bot�o para ir �s instru��es
    public void ComoJogar()
    {
        telaMenu.SetActive(false);
        telaInstrucoes.SetActive(true);
    }
    // ---------------- Bot�o para voltar ao menu
    public void VoltarMenu()
    {
        telaInstrucoes.SetActive(false);
        telaMenu.SetActive(true);
    }
}
