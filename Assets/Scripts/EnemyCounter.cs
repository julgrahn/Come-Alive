using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyCounter : MonoBehaviour
{
    [SerializeField] public int currentZombies = 20;
    [SerializeField] TextMeshProUGUI zombieCount;
    [SerializeField] List<NavMeshAgent> zombieList;
    [SerializeField] public TimerHandler timer;

    public void DeathCounter()
    {
        zombieCount.text = "Zombies Left\n" + currentZombies.ToString();

        if(currentZombies <= 0)
        {
            timer.TimerStopper();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            //zombieCount.text = "You win";
        }
    }
}



