using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PoinLevel : MonoBehaviour
{
    [SerializeField] int scoreRequirement = 10;
    [SerializeField] int scoreIncrement = 10; 
    [SerializeField] Text scoreText;
    [SerializeField] Text levelText;

    //set ke 0 kalau uda ada main screen
    static private int level = 1;
    private int score = 0;

    public void Start()
    {
        UpdateUI();
    }

    public void LevelUp()
    {
        level++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //level 0: MainScreen
        //Level 1,2,3: Scene Game
        //Level 4: FinishScreen
    }

    public void AddPoint()
    {
        score += scoreIncrement;
        UpdateUI();
        if (score >= scoreRequirement)
        {
            LevelUp();
        }
    }

    private void UpdateUI() {
        scoreText.text = "Score: " + score.ToString();
        levelText.text = "Level: " + level.ToString();
    }
   
}
