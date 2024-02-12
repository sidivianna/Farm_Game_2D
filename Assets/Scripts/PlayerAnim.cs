using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Player player;
    private Animator anim;

    private Casting cast;
    
    void Start() 
    {
        player = GetComponent<Player>();    
        anim = GetComponent<Animator>();

        cast = FindObjectOfType<Casting>();
    }

    void Update() 
    {
        OnMove();
        OnRun();
    }
  
    #region Movement
    
    public void OnCastingStarted() 
    {
        anim.SetTrigger("isCasting");
        player.isPaused = true;
    }   
    public void OnCastingEnded() 
    {
        cast.OnCasting();
        player.isPaused = false;
    }

    public void OnHammeringStarted() 
    {
        anim.SetBool("hammering", true);
    }
    public void OnHammeringEnded() 
    {
        anim.SetBool("hammering", false);
    }

    


    void OnMove() 
    {
        if(player.direction.sqrMagnitude > 0)
        {
            if(player.isRolling)
            {
                anim.SetTrigger("IsRoll");
            }
            else 
            {
                anim.SetInteger("transition", 1);
            }
            
        }
        else
        {
            anim.SetInteger("transition", 0);
        }

        if(player.direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        if(player.direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }

        if(player.isCutting)
        {
            anim.SetInteger("transition", 3);
        }

        if(player.isDigging)
        {
            anim.SetInteger("transition", 4);
        }

        if(player.isWatering)
        {
            anim.SetInteger("transition", 5);
        }

    }

    void OnRun() 
    {
        if(player.isRunning)
        {
            anim.SetInteger("transition", 2);
        }
        
    }
    

    #endregion
}

    
