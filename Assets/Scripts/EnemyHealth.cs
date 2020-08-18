using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    [SerializeField] TextMeshProUGUI zombieCount;

    int currentZombies;


    bool isDead = false;

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
            Die();
        }
          
    }

    private void Die()
    {
        if (isDead)
        {
            for (currentZombies = 20; currentZombies >= 0; currentZombies--)
            {
                --currentZombies;
                zombieCount.text = "Zombies Left\n" + currentZombies.ToString();
            }
            return;
        }

        isDead = true;
        GetComponent<Animator>().SetTrigger("die");

    }
}
