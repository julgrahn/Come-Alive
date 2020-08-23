using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using HighScore;
using UnityStandardAssets.Characters.FirstPerson;


public class EnemyCounter : MonoBehaviour
{
    [SerializeField] public int currentZombies = 20;
    [SerializeField] TextMeshProUGUI zombieCount;
    [SerializeField] List<NavMeshAgent> zombieList;
    [SerializeField] public TimerHandler timer;
    [SerializeField] Canvas winGameCanvas;
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
            GetComponent<RigidbodyFirstPersonController>().enabled = false;
            GetComponentInChildren<Weapon>().enabled = false;
            gunReticleCanvas.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
            winGameCanvas.enabled = true;
            FindObjectOfType<WpnSwitcher>().enabled = false;
            
            timer.TimerStopper();
            

            
        }
    }
}



