using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<TextMeshProUGUI> list;
    [SerializeField] Player player;
    [SerializeField] private int score = 0;
    [SerializeField] private float time = 0;

    //Enemy Prefab
    private float spawnTime = 0f;
    [SerializeField] private GameObject enemyPref;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    private void Start()
    {
        for (int i = 0; i < list.Count; i++)
        {
            list[i].text = "Hello World!";
        }
    }

    private void Update()
    {
        ManagePlayer();
        ManageUI();
        ManageEnemies();

        spawnTime += Time.deltaTime;
    }

    private void ManageEnemies()
    {
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        //Spawn enemies every 5 seconds, take the MainCamera as reference
        if(spawnTime >= 1.0f)
        {
            var cam = Camera.main;
            float xMax = cam.orthographicSize * cam.aspect;
            float yMax = cam.orthographicSize;
            Vector3 pos = new Vector3(Random.Range(-xMax, xMax), yMax, 0);
            Instantiate(enemyPref, pos, Quaternion.identity);

            spawnTime = 0;
        }
    }


    private void ManagePlayer()
    {
        player.CheckFire();
    }

    private void ManageUI()
    {
        time += Time.deltaTime;

        list[0].text = "Lives: " + player.Lives.ToString();
        list[1].text = "Bombs: " + player.Bombs.ToString();
        list[2].text = "Weapon: " + player.BulletPref.name;
        list[3].text = "Score: " + score.ToString();
        //truncate the time to no show decimals
        list[4].text = "Time: " + time.ToString("F0");
    }


    public void AddScore(int value)
    {
        score += value;
    }

}
