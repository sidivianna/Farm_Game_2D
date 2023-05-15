using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    [System.Serializable]
    public enum idiom 
    {
        pt,
        eng,
        spa
    }

    public idiom language;

    [Header("Components")]
    public GameObject dialogueObj; //janela do dialogo
    public Image ProfileSprite; //sprite do perfil
    public Text SpeechText; // texto da fala
    public Text actorNameText; // nome do NPC

    [Header("Settings")]
    public float typingSpeed; //velocidade da fala

    //Variaveis de controle
    public bool isShowing;    //se a janela está visível
    private int index; // index das sentenças 
    private string[] sentences;

    public static DialogueControl instance;

    // awake é chamado antes de todos os Start() na hierarquia de execução de scripts.
    private void Awake() 
    {
        instance = this;
    }
    
    // É chamado antes do inicializar.
    void Start()
    {

    }

    
    void Update()
    {
        
    }

    IEnumerator TypeSentence() 
    {
        foreach (char letter  in sentences[index].ToCharArray())
        {
            SpeechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    //pular para a próxima fala/frase
    public void NextSentence() 
    {
        if(SpeechText.text == sentences[index])
        {
            if(index < sentences.Length - 1)
            {
                index ++;
                SpeechText.text = "";
                StartCoroutine(TypeSentence());
            }
            else // quando terminam os textos
            {
                SpeechText.text = "";
                index = 0;
                dialogueObj.SetActive(false);
                sentences = null;
                isShowing = false;
            }
        }
    }

    // chamar a fala do NPC
    public void Speech(string[] txt) 
    {
        if(!isShowing) 
        {
            dialogueObj.SetActive(true);
            sentences = txt;
            StartCoroutine(TypeSentence());
            isShowing = true;
        }
    }


}
