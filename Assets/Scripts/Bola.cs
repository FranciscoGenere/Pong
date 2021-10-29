using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Bola : MonoBehaviour
{
    public float velocidad = 30.0f;
    AudioSource fuenteDeAudio;
    public AudioClip audioGol, audioRaqueta, audioRebote, SonidoFinal;
    public int golesIzquierda = 0;
    public int golesDerecha = 0;
    public Text contadorIzquierda;
    public Text contadorDerecha;
    public GameObject Reiniciarlo;

    void Start ()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * velocidad;
        fuenteDeAudio = GetComponent<AudioSource>();
        contadorIzquierda.text = golesIzquierda.ToString();
        contadorDerecha.text = golesDerecha.ToString();
        
    }
    
    void OnCollisionEnter2D(Collision2D micolision){
        if (micolision.gameObject.name == "Raqueta Izquierda")
        {
            int x = 1;
            int y = direccionY(transform.position, micolision.transform.position);
            Vector2 direccion = new Vector2(x, y);
            GetComponent<Rigidbody2D>().velocity = direccion * velocidad;
            fuenteDeAudio.clip = audioRaqueta;
            fuenteDeAudio.Play();
        }
        else if (micolision.gameObject.name == "Raqueta Derecha"){
            int x = -1;
            int y = direccionY(transform.position, micolision.transform.position);
            Vector2 direccion = new Vector2(x, y);
            GetComponent<Rigidbody2D>().velocity = direccion * velocidad;
            fuenteDeAudio.clip = audioRaqueta;
            fuenteDeAudio.Play();
        }
        if (micolision.gameObject.name == "Arriba" || micolision.gameObject.name == "Abajo"){
            fuenteDeAudio.clip = audioRebote;
            fuenteDeAudio.Play();
        }
        }

    int direccionY(Vector2 posicionBola, Vector2 posicionRaqueta)
    {
        if (posicionBola.y > posicionRaqueta.y)
        {
            return 1;
        }
        else if (posicionBola.y < posicionRaqueta.y)
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }
    public void reiniciarBola(string direccion)
    {
        transform.position = Vector2.zero;
        velocidad = velocidad + 5.0f; //Aumentara 5 unidades de velocidad con un GOL

        if (direccion == "Derecha")
        {
            golesDerecha++;

            contadorDerecha.text = golesDerecha.ToString();
            GetComponent<Rigidbody2D>().velocity = Vector2.right *velocidad;
        }
        else if (direccion == "Izquierda")
        {
            golesIzquierda++;
            contadorIzquierda.text = golesIzquierda.ToString();
            GetComponent<Rigidbody2D>().velocity = Vector2.left *velocidad;
        }
        fuenteDeAudio.clip = audioGol;
        fuenteDeAudio.Play();
        if (golesDerecha >= 5)
        {
            fuenteDeAudio.clip = SonidoFinal;
            fuenteDeAudio.Play();
            GetComponent<Rigidbody2D>().velocity = Vector2.right *0;
            Destroy(this.gameObject,0.85f);
            Reiniciarlo.SetActive(true);
        }

        if (golesIzquierda >= 5)
        {
            fuenteDeAudio.clip = SonidoFinal;
            fuenteDeAudio.Play();
            GetComponent<Rigidbody2D>().velocity = Vector2.right *0;
            Destroy(this.gameObject,0.85f);
            Reiniciarlo.SetActive(true);
        }

    }
    void Update ()
    {

        

       // velocidad = velocidad + 0.1f;
    }
}