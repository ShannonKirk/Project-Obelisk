using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour {

    [SerializeField] GameObject deathScreen;

    [SerializeField] Text timeAlive;
    [SerializeField] Text kills;
    [SerializeField] Text punches;
    [SerializeField] Text punchEfficancy;

    public void killPlayer()
    {
        PlayerManager.alive = false;
        deathScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        //set stats
        timeAlive.text = "Seconds Survived: " + PlayerManager.SecondsPlayerAlive;
        kills.text = "Things you punched: " + PlayerManager.enemiesPlayerKilled;
        punches.text = "Times you punched: " + PlayerManager.timesPlayerPunched;
        punchEfficancy.text = "Punch Efficancy Rating: " + (float)PlayerManager.enemiesPlayerKilled / PlayerManager.timesPlayerPunched * 100 + "%";

        PlayerManager.ResetStats();
    }

    public void respawnPlayer()
    {
        PlayerManager.alive = true;
        deathScreen.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PlayerManager.player.transform.position = PlayerManager.respawnPoint;

        if (PlayerManager.player.GetComponent<Rigidbody>())
        { PlayerManager.player.GetComponent<Rigidbody>().velocity = new Vector3(); }

    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void reload()
    {
        
        SceneManager.LoadScene("Greybox With Enemies");
        PlayerManager.alive = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PlayerManager.ResetStats();
    }
}
