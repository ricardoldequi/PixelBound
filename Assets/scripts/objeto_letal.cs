using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objeto_letal : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
         {
            other.gameObject.GetComponent<vida_do_jogador>().MachucarJogador();

         }
        
    }

  
}