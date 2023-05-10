using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casting : MonoBehaviour
{
    [SerializeField] private int percentage; // chance de pescar.

    private PlayerItems player;
    private bool detectingPlayer;

    void Start()
    {
        player = FindObjectOfType<PlayerItems>();
    }

    void Update()
    {
        if (detectingPlayer = true && Input.GetKeyDown(KeyCode.E)) 
        {
            OnCasting();
        }

        void OnCasting() 
        {
            int randomValue = Random.Range(1, 100);

            if(randomValue <= percentage) 
            {
                // conseguiu pescar
                Debug.Log("Pescou");

            }
            else 
            {
                // nao pescou
                Debug.Log("Não pescou");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Player")) 
        {
            detectingPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) 
    {
        if (collision.CompareTag("Player")) 
        {
            detectingPlayer = false;
        }
    }

}
