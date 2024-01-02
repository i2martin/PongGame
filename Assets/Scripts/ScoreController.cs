using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ScoreController : MonoBehaviour
{
    private int scorePlayer1 = 0;
    private int scorePlayer2 = 0;
    public int goalsTowin;
    public GameObject scoreTextPlayer1;
    public GameObject scoreTextPlayer2;

    // Update is called once per frame
    void Update()
    {
        //Who won?
        if (this.scorePlayer1 == this.goalsTowin || this.scorePlayer2 == this.goalsTowin)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    private void FixedUpdate()
    {
        TMP_Text score1 = this.scoreTextPlayer1.GetComponent<TMP_Text>();
        score1.text = this.scorePlayer1.ToString();

        TMP_Text score2 = this.scoreTextPlayer2.GetComponent<TMP_Text>();
        score2.text = this.scorePlayer2.ToString();
    }

    public void GoalPlayer1()
    {
        this.scorePlayer1++;
    }

    public void GoalPlayer2()
    { 
        this.scorePlayer2++;
    }
}
