using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casting : MonoBehaviour
{
    [SerializeField] private int percentage; //cahance de pescar.
    [SerializeField] private GameObject fishPrefab;

    private PlayerItems player;
    private PlayerAnim playerAnim;

    private bool detectingPlayer;

    void Start()
    {
        player = FindObjectOfType<PlayerItems>();
        playerAnim = player.GetComponent<PlayerAnim>();
    }

    void Update()
    {
        if (detectingPlayer && Input.GetKeyDown(KeyCode.E)) 
        {
            playerAnim.OnCastingStarted();
            //OnCasting();
        }
    }

    public void OnCasting() 
    {
        int randomValue = Random.Range(1, 100);

        if(randomValue <= percentage)
        {
            Instantiate(fishPrefab, player.transform.position + new Vector3(Random.Range(-3, -1f), 0f, 0f), Quaternion.identity);
            Debug.Log("Pescou");
        }
        else
        {
            Debug.Log("Não Pescou");
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
