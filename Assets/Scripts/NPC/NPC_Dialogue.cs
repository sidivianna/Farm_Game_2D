using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Dialogue : MonoBehaviour
{
    public float dialogueRange;
    public LayerMask playerLayer;
    
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        ShowDialogue();
    }

    void ShowDialogue() 
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, dialogueRange, playerLayer);

        if(hit != null)
        {
            Debug.Log("player na area de colisão");
        }
        else 
        {

        }
    }

    private void OnDrawGizmosSelected() 
    {
        Gizmos.DrawWireSphere(transform.position, dialogueRange);
    }
}
