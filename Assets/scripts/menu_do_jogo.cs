using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu_do_jogo : MonoBehaviour
{
    public string nomeDaPrimeiraFase;
    public GameObject painelDoMenuInicial, painelDaTelaDeCreditos;

   public void CarregarJogo()
   {
        SceneManager.LoadScene(nomeDaPrimeiraFase);
   }

   public void AtivarPainelDaTelaDeCreditos()
   {
        painelDoMenuInicial.SetActive(false);
        painelDaTelaDeCreditos.SetActive(true);
   }

   public void AtivarPainelDoMenuInicial()
   {
        painelDaTelaDeCreditos.SetActive(false);
        painelDoMenuInicial.SetActive(true);
   }
   
   public void SairDoJogo()
   {
        Debug.Log("saiu do jogo");
        Application.Quit();
   }
}
