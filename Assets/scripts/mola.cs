using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mola : MonoBehaviour
{
    public float forcaDaMola;

    private Animator oAnimator;

    void Awake(){
        oAnimator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SFXManager.instance.somDoPulo.Play();
            oAnimator.Play("animacao_mola_subindo");
            other.gameObject.GetComponent<movimento_do_jogador>().ImpulsionarJogador(forcaDaMola);
        }
    }


}
