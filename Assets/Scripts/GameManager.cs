using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int score;
    int hp;
    public static GameManager inst;
    [SerializeField] Text scoreText;
    [SerializeField] Text hpText;
    [SerializeField] Movement movement;

    // Start is called before the first frame update
    void Start()
    {
        hp = 3;
    }

    public void IncrementScore()
    {
        score+=10;
        scoreText.text = "Score: " + score;
        movement.speed += (score/50)*0.2f;
    }

    public void DecrementScore()
    {
        if (score - 5 < 0)
            return;
        score-=5;
        scoreText.text = "Score: " + score;
    }

    public void IncrementHP()
    {
        if (hp == 3)
            return;
        hp++;
        hpText.text = "HP: " + hp;
    }

    public void DecrementHP()
    {
        if (hp == 0)
        {
            movement.Die();
            return;
        }
        hp--;
        hpText.text = "HP: " + hp;
    }

    void Awake()
    {
        inst = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            IncrementHP();
        if (Input.GetKeyDown(KeyCode.R))
            movement.ChangeColor();
        if (Input.GetKeyDown(KeyCode.Q))
            IncrementScore();
    }
}
