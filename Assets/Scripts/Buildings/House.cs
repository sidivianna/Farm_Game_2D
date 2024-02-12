using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    [Header("Amounts")]
    [SerializeField] private int woodAmount;
    [SerializeField] private Color startColor;
    [SerializeField] private Color endColor;
    [SerializeField] private float timeAmount;

    [Header("Components")]
    [SerializeField] private GameObject HouseColl;
    [SerializeField] private SpriteRenderer houseSprite;
    [SerializeField] private Transform point;
   



    private bool detectingPlayer;
    private Player player;
    private PlayerAnim playerAnim;
    private PlayerItems playerItems;
    private float timeCount;
    private bool isBegining;

    void Start()
    {
        player = FindObjectOfType<Player>();
        playerAnim = player.GetComponent<PlayerAnim>();
        playerItems = player.GetComponent<PlayerItems>();
    }

    void Update()
    {
        if (detectingPlayer && Input.GetKeyDown(KeyCode.E) && playerItems.totalWood >=woodAmount) 
        {
            // construção inicilizada
            isBegining = true;
            playerAnim.OnHammeringStarted();
            houseSprite.color = startColor;
            player.transform.position = point.position;
            player.isPaused = true;
            playerItems.totalWood -= woodAmount;
        }
        if (isBegining)
        {
            timeCount += Time.deltaTime;

            if (timeCount >= timeAmount)
            {
                // Casa é finalizada
                playerAnim.OnHammeringEnded();
                houseSprite.color = endColor;
                player.isPaused = false;
                HouseColl.SetActive(true);
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

