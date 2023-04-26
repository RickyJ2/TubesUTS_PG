using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropArea : MonoBehaviour
{
    [SerializeField] Transform player;
    private PoinLevel poinLevel;

    private void Start()
    {
        poinLevel = player.GetComponent<PoinLevel>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {

            poinLevel.AddPoint();
            Destroy(collision.gameObject);
        }
    }
}
