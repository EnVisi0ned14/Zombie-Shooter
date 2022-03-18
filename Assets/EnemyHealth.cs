using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public bool isAlive = true;

    [SerializeField] float hitPoints = 100f;

    // create a public method which reduces hitpoints by the ammount of damage
    public void TakeDamage(float Damage)
    {
        BroadcastMessage("OnDamageTaken");
        hitPoints = hitPoints - Damage;
        if(hitPoints <= 0)
        {
            GetComponent<Animator>().SetTrigger("Dead");
            isAlive = false;
        }
    }
}
