using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtkHazard : MonoBehaviour
{
    public int Damage;

    private void onTriggerEnter2D(Collider2D other){
        if(other.GetComponent<PlayerHealth>()){
            other.GetComponent<PlayerHealth>().TakeDamage(Damage);
        }
    }
}
