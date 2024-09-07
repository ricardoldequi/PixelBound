using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vida_do_jogador : MonoBehaviour
{

    [Header("Referências")]
    public GameObject efeitoDeExplosao;
    private Rigidbody2D oRigidbody2D;
    private Animator oAnimator;

    [Header("valores")]
    public float tempoParaDestruirJogador;


    void Awake()
    {
        oRigidbody2D = GetComponent<Rigidbody2D>();
        oAnimator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MachucarJogador()
    {
        SFXManager.instance.somDeDano.Play();
        FindObjectOfType<movimento_do_jogador>().jogadorEstaVivo = false;
        oRigidbody2D.velocity = Vector2.zero;
        oAnimator.Play("jogador_levando_dano");

        StartCoroutine(DestruirJogador());


    }

    private IEnumerator DestruirJogador()
    {
        yield return new WaitForSeconds(tempoParaDestruirJogador);
        FindObjectOfType<GameManager>().GameOver();
        Instantiate(efeitoDeExplosao, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
