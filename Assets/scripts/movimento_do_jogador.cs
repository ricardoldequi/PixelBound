using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimento_do_jogador : MonoBehaviour
{

    [Header("Referências")]
    private  Rigidbody2D oRigidbody2D;
    private Animator oAnimator;

    [Header("Movimento Horizontal")]
    public float VelocidadeJogador;
    public bool indoParaDireita;

    [Header("Pulo")]
    public bool estaNoChao;
    public float alturaDoPulo;
    public float tamanhoDoRaioDeVerificacao;
    public Transform verificadorDeChao;
    public LayerMask layerDoChao;

    [Header("Wall Jump")]
    public bool estaNaParede;
    public bool estaPulandoNaParede;
    public Transform verificadorDeParede;
    public float forcaXDoWallJump;
    public float forcaYDoWallJump;

    [Header("Verificacoes")]
    public bool jogadorEstaVivo;



    void Awake()
    {
        oRigidbody2D = GetComponent<Rigidbody2D>();
        oAnimator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        jogadorEstaVivo = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(jogadorEstaVivo == true)
        {
            MovimentarJogador();
            Pular();
            Wall_Jump();
        }
    }

    // cuida do moviento horizontal do jogador
    private void MovimentarJogador()
    {
            //da movimento ao jogador e usa variavel para definir velocidade de movimento
            //a vairavei movimentoHorizontal busca os valores de A e D do teclado para criar o movimento, se for para esquerda é negativo e para direita é positivo
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

        // toca as nimações do jogador (Parado e andando)
        if(movimentoHorizontal == 0 && estaNoChao == true)
        {
            oAnimator.Play("jogador_idle");
        }
        else if (movimentoHorizontal != 0 && estaNoChao == true && estaNaParede == false)
        {
            oAnimator.Play("jogador_andando");

        }

    }

    private void Pular()
    {
        //cria circulo de sobreposição para validar se o jogador está no chao ou não
        estaNoChao = Physics2D.OverlapCircle(verificadorDeChao.position, tamanhoDoRaioDeVerificacao, layerDoChao);

        //verifica se o botão de pular foi apertado e se o jogador esta no chao
        if(Input.GetButtonDown("Jump") && estaNoChao == true)
        {
            SFXManager.instance.somDoPulo.Play();

            //aplica forca no eixo x,y
            oRigidbody2D.AddForce(new Vector2(0f, alturaDoPulo), ForceMode2D.Impulse);
        }

        if(estaNoChao == false && estaNaParede == false)
        {
            oAnimator.Play("jogador_pulando");

        }
    }


    private void Wall_Jump(){
        // verifica se o jogador está incostando na parede
        estaNaParede = Physics2D.OverlapCircle(verificadorDeParede.position, tamanhoDoRaioDeVerificacao, layerDoChao);


        if(estaNaParede == true && estaNoChao == false)
        {
            oAnimator.Play("jogador_deslisando_parede");
        }

        // diz que o jogador está na patede e está pulando
        if(Input.GetButtonDown("Jump") && estaNaParede == true && estaNoChao == false)
        {
        SFXManager.instance.somDoPulo.Play();           
        estaPulandoNaParede = true; 
        }

        // faz o jogador pular na parede
        if (estaPulandoNaParede == true)
        {
            if (indoParaDireita == true)
            {
                oRigidbody2D.velocity = new Vector2(-forcaXDoWallJump, forcaYDoWallJump);
            }
            else 
            {
                oRigidbody2D.velocity = new Vector2(forcaXDoWallJump, forcaYDoWallJump);
            }

            Invoke (nameof(DeixarEstarPulandoNaParedeComoFalso), 0.1f);
        }

    }

    private void DeixarEstarPulandoNaParedeComoFalso()
    {
        estaPulandoNaParede = false;
    }

    public void ImpulsionarJogador(float forcaDoImpulso)
    {
        oRigidbody2D.velocity = new Vector2(oRigidbody2D.velocity.x, 0f);
        oRigidbody2D.AddForce(new Vector2(0f, forcaDoImpulso), ForceMode2D.Impulse);
    }

}
