using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigos : MonoBehaviour
{
    [Header("Camihnho do inimigo")]
    public Transform[] pontosDoCaminho;

    public int pontoAtual;
    [Header("Movimento do inimigo")]

    public float velocidadeInimigo;
    public float ultimaPosicaoX;

    // Start is called before the first frame update
    void Start()
    {
        pontoAtual = 0;
        transform.position = pontosDoCaminho[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        MoverInimigo();
        EspelharInimigo();
    }

    private void MoverInimigo()
    {
        // move o inimigo para o proximo ponto do array
        transform.position = Vector2.MoveTowards(transform.position, pontosDoCaminho[pontoAtual].position,velocidadeInimigo * Time.deltaTime);

        // verifica se o inimigo chegou no ponto
        if(transform.position == pontosDoCaminho[pontoAtual].position)
        {
            // troca o proximo ponto que o inimigo precisa ir 
            pontoAtual +=1;

            // armazena a posição x atual do inimigo
            ultimaPosicaoX = transform.localPosition.x;

            // verifica se o proximo ponto existe no array
            if(pontoAtual >= pontosDoCaminho.Length)
            {
                pontoAtual = 0;
            }
        }
    }

    private void EspelharInimigo()
    {

        // espelha o sprite do inimigo dependendo da direção
        if(transform.localPosition.x < ultimaPosicaoX)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if(transform.localPosition.x > ultimaPosicaoX)
        {
            GetComponent<SpriteRenderer>().flipX = true;

        }
    }
}
