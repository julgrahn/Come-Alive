using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    [SerializeField] public EnemyCounter counter;


    bool isDead;


    public bool IsDead()
    {
        return isDead;
    }


    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            counter.currentZombies--;
            counter.DeathCounter();
            Die();
        }
    }

    private void Die()
    {
        if (isDead)
        {
            return;
        }

        isDead = true;
        GetComponent<Animator>().SetTrigger("die");

    }
}
