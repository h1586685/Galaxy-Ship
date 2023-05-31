using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class director : MonoBehaviour
{
    int hp = 100;
    public int score = 0;
    Text text_hp;

    public hpbar hpbar;

    GameObject spawn;

    public bool win = false;
    public int currentWave;
    // Start is called before the first frame update
    void Start()
    {
        text_hp = GameObject.Find("hp").GetComponent<Text>();

        hpbar.setMaxHealth(100);

        spawn = GameObject.Find("spawn");
    }

    // Update is called once per frame
    void Update()
    {
        if (!win)
        {
            currentWave = (spawn.GetComponent<spawn>().getWave());
            hpbar.setHealth(hp);
            text_hp.text = hp + "/100";
        }
        end();
    }
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void decreasehp()
    {
        GetComponent<AudioSource>().Play();
        hp -= 10;
    }
    public void IncreaseScore(int Score)
    {
        GetComponent<AudioSource>().Play();
        score += Score;
    }
    public void resethp()
    {
        hp = 100;
    }

    public void end()
    {
        if (hp == 0 && win ==false)
        {
            SceneManager.LoadScene("endScense");
        }
        else if (currentWave >=6 && win == false)
        {
            win = true;
            SceneManager.LoadScene("endScense");
        }
    }

    public bool Win() { return win; }
    public int getSocre() { return score; }
}
