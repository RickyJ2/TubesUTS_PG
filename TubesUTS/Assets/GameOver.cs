using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void restart(){
     SceneManager.LoadScene("Level1");
    }
    public void noRestart(){
     SceneManager.LoadScene("Menu");
    }
    
}
