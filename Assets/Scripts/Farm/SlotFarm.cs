using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotFarm : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite hole;
    [SerializeField] private Sprite carrot;

    [Header("Settings")]
    [SerializeField] private int digAmount; //quantidade de escavação
    [SerializeField] private float waterAmount; // quantidade de agua para regar

    [SerializeField] private bool detecting;

    private int initialDigAmount;
    private float currentWater;

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
            if(currentWater >= waterAmount) 
            {
                spriteRenderer.sprite = carrot;

                if(Input.GetKeyDown(KeyCode.E)) 
                {
                    spriteRenderer.sprite = hole;
                    playerItems.carrots++;
                    currentWater = 0f;
                }
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
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Water"))
        {
            detecting = false;
        }

    }



}
