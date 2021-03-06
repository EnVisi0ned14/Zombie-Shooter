using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] float hitPoints = 100f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealth(float damage)
    {
        DeathHandler deathSequence = GetComponent<DeathHandler>();
        hitPoints = hitPoints - damage;
        if (hitPoints <= 0)
        {
            deathSequence.HandleDeath();
        }
    }

}
