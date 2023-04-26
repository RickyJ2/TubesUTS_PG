using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollideEnemy : MonoBehaviour
{
    [SerializeField] PoinLevel poinLevel;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")){
            die();
        }
    }

    private void die()
    {
        poinLevel.ResetLevel(); 
        SceneManager.LoadScene("GameOver");
    }
}
