using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    [SerializeField] public AudioSource deathSound;


    public AudioClip deathClip;

    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
        if(hitPoints <= 0)
        {
            deathSound.clip = deathClip;
            deathSound.Play();
            GetComponent<DeathHandler>().HandleDeath();
        }
    }
}
