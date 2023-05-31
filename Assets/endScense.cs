using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endScense : MonoBehaviour
{
    Text text;
    GameObject dir;

    public int score;
    public bool win = false;
    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.Find("ENDTEXT").GetComponent<Text>();
        dir = GameObject.Find("director");
        cul();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void cul()
    {
        score = dir.GetComponent<director>().getSocre();
        win = dir.GetComponent<director>().Win();
        if (win)
        text.text = "YOU WIN!" +"\nand you get\n"+ score + "\npoint";
        else
        text.text = "YOU LOSE!" + "\nand you get\n" + score +"\npoint";
    }
}
