using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager_Script : MonoBehaviour
{
    // Start is called before the first frame update

    public void Game_Manager_Set()
    {

        ScoreManager.set();
        SaveManager.set();
        //Clock.set();
        Level_Controller_Simple.set();
        Random_Level_Gen.set();
        StartCoroutine(Random_Level_Gen.spawnn_all());
        StartCoroutine(Random_Level_Gen.spawn_enemy());
        StartCoroutine(Random_Level_Gen.spawn_item());
        StartCoroutine(Random_Level_Gen.spawn_wall());
        StartCoroutine(Random_Level_Gen.spawn_door());
    }
    void Awake()
    {
        Game_Manager_Set();
    }
    void Start()
    {
        //Debug.Log(Application.persistentDataPath); C:\Users\jaf13006\AppData\LocalLow
    }

    // Update is called once per frame
    void Update()
    {

    }
}