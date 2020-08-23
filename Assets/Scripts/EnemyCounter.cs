using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using HighScore;

public class EnemyCounter : MonoBehaviour
{
    [SerializeField] public int currentZombies = 20;
    [SerializeField] TextMeshProUGUI zombieCount;
    [SerializeField] List<NavMeshAgent> zombieList;
    [SerializeField] public TimerHandler timer;
    [SerializeField] Canvas winGameCanvas;
    [SerializeField] Canvas gameOverCanvas;
    [SerializeField] Canvas gunReticleCanvas;

    private void Start()
    {
        winGameCanvas.enabled = false;
    }

    public void DeathCounter()
    {
        zombieCount.text = "Zombies Left\n" + currentZombies.ToString();

        if(currentZombies <= 0)
        {
            gameOverCanvas.enabled = false;
            gunReticleCanvas.enabled = false;
            winGameCanvas.enabled = true;
            FindObjectOfType<WpnSwitcher>().enabled = false;
            Time.timeScale = 0;
            timer.TimerStopper();
            

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}



