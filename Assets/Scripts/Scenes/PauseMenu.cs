using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public bool isPaused = false;
    private Shooter shooter;
    // Start is called before the first frame update
    void Start()
    {
        shooter=FindObjectOfType<Shooter>();
    }

    // Update is called once per frame
void Update()
{
    if (Input.GetKeyDown(KeyCode.Escape))
    {
        if (isPaused)
        {
            Resume();
            shooter.canFire=true;
        }
        else
        {
            Pause();
            shooter.canFire=false;
        }
    }
}
void Pause()
{
    isPaused = true;
    pauseMenuUI.SetActive(true);
    Time.timeScale = 0f; // Stop the game
}

void Resume()
{
    isPaused = false;
    pauseMenuUI.SetActive(false);
    Time.timeScale = 1f; // Resume the game
}
}
