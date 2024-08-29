using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimento_do_jogador : MonoBehaviour
{

    [Header("Referências")]
    private  Rigidbody2D oRigidbody2D;

    [Header("Movimento Horizontal")]
    public float VelocidadeJogador;
    public bool indoParaDireita;

    void Awake()
    {
        oRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovimentarJogador();
        
    }

    private void MovimentarJogador()
    {
        //da movimento ao jogador e usa variavel para definir velocidade de movimento
        float movimentoHorizontal = Input.GetAxis("Horizontal");
        oRigidbody2D.velocity = new Vector2(movimentoHorizontal * VelocidadeJogador, oRigidbody2D.velocity.y);

    //condição para validar qual lado o personagem está caminhando(direita ou esquerda)
    //utilizada para espelhar a imagem do personagem quando ele caminha na direção oposta
    if(movimentoHorizontal> 0)
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
        indoParaDireita = true;
    }
    else if(movimentoHorizontal < 0)
    {
        transform.localScale = new Vector3(-1f, 1f, 1f);
        indoParaDireita = false;
    }


    }
}
