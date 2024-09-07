using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataforma_armadilha : MonoBehaviour
{
    public GameObject efeitoDeExplosao;
   public float tempoParaDesligar;
   private Animator oAnimator;

void Awake()
{
    oAnimator = GetComponent<Animator>();
}
   public void RodarCoroutineDesligarPlaforma()
   {
        StartCoroutine(DesligarPlataforma());
   }

   private IEnumerator DesligarPlataforma()
   {
        oAnimator.Play("animacao_plataforma_parada");
        yield return new WaitForSeconds(tempoParaDesligar);
        Instantiate(efeitoDeExplosao, transform.position, transform.rotation);
        Destroy(this.gameObject);

   }
}
