using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trofeu_final_fase : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        //passar de fase quando o payer encosta no trofeu
        if(other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<GameManager>().RodarCoroutinePassarDeFase();
        }
    }
    
}
