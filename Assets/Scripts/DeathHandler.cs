using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;
    [SerializeField] Canvas gunReticleCanvas;

    private void Start()
    {
        gunReticleCanvas.enabled = true;
        gameOverCanvas.enabled = false;
    }

    public void HandleDeath()
    {
        GetComponent<RigidbodyFirstPersonController>().enabled = false;
        GetComponentInChildren<Weapon>().enabled = false;
        gunReticleCanvas.enabled = false;
        gameOverCanvas.enabled = true;
        Time.timeScale = 0;
        FindObjectOfType<WpnSwitcher>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
