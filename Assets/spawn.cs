using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    public GameObject enemyShip;
    public float spawnTime = 1.2f;

    int wave = 1;
    bool waveEnd =false;
    float roundtime = 30.0f,resttime =10.0f;
    Text waveAndTime;
    float temp,temp2;

    public timeBar TimeBar;
    GameObject dir;
    void Start()
    {
        dir = GameObject.Find("director");
        InvokeRepeating("addenemy", temp, spawnTime);
        InvokeRepeating("timer",1, 1);
        waveAndTime = GameObject.Find("wave").GetComponent<Text>();
        temp = roundtime;
        temp2 = resttime;
        TimeBar.setMaxTIME((int)roundtime);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void addenemy()
    {
        Renderer rd = this.gameObject.GetComponent<Renderer>();
        float y1 = transform.position.y - rd.bounds.size.y / 2;
        float y2 = transform.position.y + rd.bounds.size.y / 2;
        Vector2 spawnPoint = new Vector2 (transform.position.x , Random.Range(y1, y2));
        Instantiate(enemy, spawnPoint, Quaternion.identity);

        if (wave >= 2)
        {
            spawnPoint = new Vector2(transform.position.x, Random.Range(y1, y2));
            Instantiate(enemyShip, spawnPoint, Quaternion.identity);
        }
    }

    void timer()
    {
        if (temp >= 0)
        {
            waveAndTime.text = temp + "/" + roundtime;
            TimeBar.setTime((int)temp);
            temp--;
        }
        if (temp == -1)
        {
            CancelInvoke("addenemy");
            if (waveEnd == false)
            {
                wave++;
            }
            waveEnd = true;
        }
        if (waveEnd == true)
        {
            TimeBar.setMaxTIME((int)resttime);
            TimeBar.setTime((int)temp2);
            waveAndTime.text = "WAVE " + wave + " / " + temp2;
            temp2--;
            if (temp2 == 0)
            {
                temp = roundtime;
                temp2 = resttime;
                dir.GetComponent<director>().resethp();
                spawnTime *= 0.83f;
                TimeBar.setTime((int)temp);
                TimeBar.setMaxTIME((int)roundtime);
                InvokeRepeating("addenemy", 0, spawnTime);
                waveEnd = false;
            }
        }
    }

    public int getWave() { return wave; }
}
