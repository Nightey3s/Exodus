using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public AudioSource music;
    public Rect quitGame = new Rect((Screen.width - 608) / 2, (Screen.height - 1080) / 2, 608, 1080);
    public bool pauseGame = false;
    public GameObject enemy_1, enemy_2, enemy_3, Boss;
    public float enemySpawnTime, enemyCount, enemy1des, enemy2des, enemy3des, finalScore;
    public AudioClip musicA, musicB;
    GUIStyle FS = new GUIStyle();
    GUIStyle Title = new GUIStyle();
    // Start is called before the first frame update
    void Start()
    {
        music = GetComponent<AudioSource>();
    }

    void OnGUI()
    {
        //Set style
        FS.fontSize = 40;
        FS.alignment = TextAnchor.MiddleCenter;
        FS.normal.textColor = Color.white;
        Title.fontSize = 50;
        Title.alignment = TextAnchor.MiddleRight;
        Title.normal.textColor = Color.red;

        if (pauseGame)
            quitGame = GUI.Window(0, quitGame, quitDialog, "Game Paused", Title);
    }

    void quitDialog(int windowID)//Pause game menu
    {
        float y = 20;
        GUI.Label(new Rect(100, 35 * y, quitGame.width, 100), "Return to main menu?", FS);

        if (GUI.Button(new Rect(250, 45 * y, quitGame.width - 300, 50), "Yes", FS))
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1;
            this.pauseGame = false;
        }

        if (GUI.Button(new Rect(250, 50 * y, quitGame.width - 300, 50), "Cancel", FS))
        {
            Time.timeScale = 1;
            this.pauseGame = false;
        }
    }
    public void playerDeath()
    {
        //code once player dies
        music.Stop();
    }
    public void quitOpen()//paus game
    {
        Time.timeScale = 0;
        this.pauseGame = true;
    }
    public void GameOver()//player dead
    {
        Time.timeScale = 0;
        SceneManager.LoadScene(3);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
            quitOpen();
        if (!GameObject.FindGameObjectWithTag("Boss") && ScoreManager.s != 0 && ScoreManager.s >= 1000)//boss spawner
        {
            GameObject boss = Instantiate(Boss, new Vector3(0f, 7f, 0f), Quaternion.identity);
            music.Pause();

        }
        /*EnemySpawner*/
        if (enemySpawnTime > 0)
        {
            enemySpawnTime -= Time.deltaTime;
        }
        else
        {
            int rand = UnityEngine.Random.Range(3, 8);
            enemyCount = 0;
            do {
                int enemySelector = UnityEngine.Random.Range(1, 4); //must use 4 as it is exclusive of the max value, this is only for the integer arguments
                switch (enemySelector)
                {
                    case 1:
                        GameObject box = Instantiate(enemy_1, new Vector3((UnityEngine.Random.Range(-5f, 5f)), (UnityEngine.Random.Range(7f, 12f)), 0), Quaternion.identity);
                        break;
                    case 2:
                        GameObject box2 = Instantiate(enemy_2, new Vector3((UnityEngine.Random.Range(-5f, 5f)), (UnityEngine.Random.Range(5f, 10f)), 0), Quaternion.identity);
                        break;
                    case 3:
                        GameObject box3 = Instantiate(enemy_3, new Vector3((UnityEngine.Random.Range(-5f, 5f)), (UnityEngine.Random.Range(5f, 10f)), 0), Quaternion.identity);
                        break;
                }             
                enemyCount++;
            } while (enemyCount <= rand);

            enemySpawnTime = 3f;
        }//end of EnemySpawner      

        GameObject thePlayer = GameObject.FindGameObjectWithTag("Player");//check if player is alive
        if(!thePlayer)
        {
            GameOver();

        }
    }
}
