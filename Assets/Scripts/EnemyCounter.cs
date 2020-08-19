using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;


public class EnemyCounter : MonoBehaviour
{
    [SerializeField] public int currentZombies = 20;
    [SerializeField] TextMeshProUGUI zombieCount;
    [SerializeField] List<NavMeshAgent> zombieList;



    public void DeathCounter()
    {
        zombieCount.text = "Zombies Left\n" + currentZombies.ToString();

        if(currentZombies <= 0)
        {
            zombieCount.text = "You win";
        }
    }
}



