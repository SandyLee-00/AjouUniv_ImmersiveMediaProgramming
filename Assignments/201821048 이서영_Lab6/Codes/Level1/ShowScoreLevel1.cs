using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScoreLevel1 : MonoBehaviour
{
    public Text scoreText;
    private int scorenum;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scorenum = GameManager.scoreTask2;
        scoreText.text = GameManager.scoreTask2.ToString();
        
        if(scorenum == 7)
        {
            scoreText.text = GameManager.scoreTask2.ToString() + "Level Cleared";
        }
    }
}
