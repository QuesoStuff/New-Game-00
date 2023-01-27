using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public static class Level_Controller_Simple 
{
    //[SerializeField] internal  Camera cam;


    // Use this for initialization
    public static void set()
    {

    }

    public static void timer_end_Restart()
    {
        //StartCoroutine(COLOR2.flash_restart_timeUp());
        SaveManager.SaveGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public static void death_Restart()
    {
        //StartCoroutine(COLOR2.flash_restart_death());
        SaveManager.SaveGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}