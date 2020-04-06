using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue_Manager : MonoBehaviour
{
    //Agregando la Clase Dialogo y creando una Cola de las Sentencias.
    public Dialogue Dialogue;

    Queue<string> Sentences;

    public GameObject DialoguePanel;
    public Text DisplayText;

    // Variables que nos ayudaran saber en que dialogo esta y a que velocidad va hablar.
    string ActiveSentence;
    public float TypingSpeed;

    public bool isTalking;


    void Start()
    {
        Sentences = new Queue<string>();   
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && DisplayText.text == ActiveSentence)
        {
            if (isTalking == true)
            {
                DisplayNextSentence();
            }
        }

    }

    void StarDialogue()
    {
        //Al principio borramos el listado para que se reinicie cada vez que iniciamos una conversación.
        Sentences.Clear();
        foreach(string sentence in Dialogue.sentenceList)
        {
            Sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }


    //Metodo para ir pasando de frase a frase
    public void DisplayNextSentence()
    {
        if (Sentences.Count <= 0)
        {
            DisplayText.text = ActiveSentence;
            return;
        }
        //Dequeue saca la horacion en la que esta y la pasa a la variable ActiveSence.
        ActiveSentence = Sentences.Dequeue();
        DisplayText.text = ActiveSentence;
        StartCoroutine(TypeTheSentence(ActiveSentence));
    }

    //Creamos un Ienumerator para dar un tipo de "Efecto" cuando habla el NPC.
    IEnumerator TypeTheSentence(string sentence)
    {
        DisplayText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            DisplayText.text += letter;
            yield return new WaitForSeconds(TypingSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Comparamos si colisiona con el jugado y si la animacion del texto terminó.
        if (collision.CompareTag("Player"))
        {
            StarDialogue();
            DialoguePanel.SetActive(true);
            isTalking = true;
        }
    }

    /* private void OnTriggerStay2D(Collider2D collision)
       {
           if (collision.CompareTag("Player"))
           {
               Debug.Log("Esta pasando");

           }
       }*/

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DialoguePanel.SetActive(false);
        }
    }
}
