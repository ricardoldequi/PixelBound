using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class verificador_de_armadilha : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {

       if(other.gameObject.GetComponent<plataforma_armadilha>())
       {
            other.gameObject.GetComponent<plataforma_armadilha>().RodarCoroutineDesligarPlaforma();
       }
    }

}
