using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class coletavel : MonoBehaviour
{

    public GameObject efeitoDeExplosao; 

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            SFXManager.instance.somDaColeta.Play();
            Instantiate(efeitoDeExplosao, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
