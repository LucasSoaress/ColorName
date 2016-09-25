using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ballsSpawn : MonoBehaviour
{
    public GameObject[] canos;
    public GameObject bola;
    public GameObject barra;
    public Color[] cores;
    private string[] nomeDasCores;
    private float tempo;
    private int cor;
    public static int pontos;
    public Text mostrarPontos;
    private float tempoLimite;
    public static int erros;
    public Text mostrarVida;


    void Start()
    {
        erros = 5;
        tempoLimite = 2;
        cor = 0;
        pontos = 0;
        tempo = 0;
        nomeDasCores = new string [] { "vermelho", "amarelo", "verde" };
    }

    void Update()
    {
        mostrarVida.text ="Vida: " +  erros.ToString();
        if (pontos >= 50)
        {
            tempoLimite = 1;
        }
        else if (pontos >= 100)
        {
            tempoLimite = 0.5f;
        }
        else if(pontos >= 150)
        {
            tempoLimite = 0.3f;
        }

        tempo += 1 * Time.deltaTime;
        mostrarPontos.text = pontos.ToString();

        if (erros < 1)
        {
            Time.timeScale = 0f;
            mostrarPontos.text = "GAME" + "\n" + "OVER!";
            mostrarPontos.fontSize = 50;
        }

        if (tempo >= tempoLimite)
        {
            int cor = Random.RandomRange(0, cores.Length);
            int i = Random.Range(0, canos.Length);
            Instantiate(bola, canos[i].transform.position, Quaternion.identity);
            bola.GetComponent<SpriteRenderer>().color = cores[cor];
            bola.tag = nomeDasCores[cor];
            tempo = 0;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (cor >= 3)
            {
                cor = 0;
            }

            barra.GetComponent<SpriteRenderer>().color = cores[cor];
            barra.tag = nomeDasCores[cor];
            cor += 1;
        }
    }

   
}
