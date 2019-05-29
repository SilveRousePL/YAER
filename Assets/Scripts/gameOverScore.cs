using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gameOverScore : MonoBehaviour
{
    public void Start()
    {
        getScore();
    }

    public void getScore()
    {
        GetComponent<TextMeshProUGUI>().text = "Score: " + Player.score.ToString();
    }
}
