using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class manage : MonoBehaviour

{
    public string[] palabras;
    public string palabraAdivina;
    public GameObject letra;
    public Transform panelPalabra;
    public List<string> carateres;
    public InputField IntroducirLetras;
    public GameObject _ahorcado;
    public int numerofallos;
    public AudioSource fallo;
    public AudioSource acierto;
    public AudioSource ganar;
    public AudioSource perder;
    public GameObject panel_perder;
    public GameObject panel_ganar;
    public int contador;
    public AudioSource fondo;
   
    // Start is called before the first frame update
    void Start()
    {
        palabraAdivina = palabras[Random.Range(0, palabras.Length)];

        for(int i = 0; i < palabraAdivina.Length; i++)
        {
            Instantiate(letra, panelPalabra);
        }

        for(int i=0; i < palabraAdivina.ToString().Length; i++)
        {
            char word = palabraAdivina[i];
            carateres.Add(word.ToString());
        }

        fondo.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void anhadirLetra()
    {
        if (palabraAdivina.Contains(IntroducirLetras.text))
        {
            for(int i = 0; i< carateres.Count; i++)
            {
                if (carateres[i].Equals(IntroducirLetras.text))
                {
                    acierto.Play();
                    panelPalabra.GetChild(i).GetComponent<Text>().text = IntroducirLetras.text;
                    contador++;
                    if(contador == palabraAdivina.Length)
                    {
                        panel_ganar.SetActive(true);
                        ganar.Play();
                    }
                }
            }
        }
        else
        {
            _ahorcado.transform.GetChild(numerofallos).gameObject.SetActive(true);
            numerofallos++;
            fallo.Play();
            if (numerofallos >= _ahorcado.transform.childCount)
            {

                panel_perder.SetActive(true);
                perder.Play();
            }
        }
        IntroducirLetras.text = "";
    }

    public void reiniciar()
    {
        SceneManager.LoadScene(0);
    }

    public void cerrar()
    {
        Application.Quit();
    }
}
