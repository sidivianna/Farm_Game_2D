using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotFarm : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip holeSFX;
    [SerializeField] private AudioClip carrotSFX;

    
    [Header("Components")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite hole;
    [SerializeField] private Sprite carrot;

    [Header("Settings")]
    [SerializeField] private int digAmount; //quantidade de escavação
    [SerializeField] private float waterAmount; // quantidade de agua para regar

    [SerializeField] private bool detecting;
    private bool isPlayer; //fica verdadeiro quando o player esra encostando 

    private int initialDigAmount;
    private float currentWater;

    private bool plantedcarrot;
    private bool dugHole;

    PlayerItems playerItems;

    private void Start() 
    {
        playerItems = FindObjectOfType<PlayerItems>();
        initialDigAmount = digAmount;
    }

    private void Update() 
    {
        if(dugHole)
        {
            if(detecting) 
            { 
                currentWater += 0.01f;
            }

            //regou o solo por completo
            if(currentWater >= waterAmount && !plantedcarrot) 
            {
                audioSource.PlayOneShot(holeSFX);
                spriteRenderer.sprite = carrot;

                plantedcarrot = true;
            }

            if(Input.GetKeyDown(KeyCode.E) && plantedcarrot && isPlayer) 
                {
                    audioSource.PlayOneShot(carrotSFX);
                    spriteRenderer.sprite = hole;
                    playerItems.carrots++;
                    currentWater = 0f;
                }
        }     
    }

    public void OnHit() 
    {
        digAmount--;

        if(digAmount <= initialDigAmount / 2) 
        {
            spriteRenderer.sprite = hole;
            dugHole = true;
        }
    }

    //metodo que detecta colisão entre dois colisores(um deles sendo Trigger.)
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.CompareTag("Dig"))
        {
            OnHit();
        }

        if(collision.CompareTag("Water"))
        {
            detecting = true;
        }

        if(collision.CompareTag("Player"))
        {
            isPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Water"))
        {
            detecting = false;
        }

        if(collision.CompareTag("Player"))
        {
            isPlayer = false;
        }

    }



}
