using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    MinigameJumpController  minigameJump;
    public Transform respawnPoint;
    SpriteRenderer spriteRenderer;
    public Sprite passive,active;

    private void Awake(){
        GameObject miniGameObj = GameObject.FindGameObjectWithTag("Player");
        minigameJump= miniGameObj.GetComponent<MinigameJumpController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void OnTriggerEnter2D(Collider2D collision){


        if(collision.CompareTag("Player") && minigameJump != null){

            spriteRenderer.sprite = active;
            minigameJump.UpdateCheckPoint(respawnPoint.position);
            
        }
    }

}
