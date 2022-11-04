using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Void"))
        {
            SceneManager.LoadScene("Level 1");
        }
        
        /*
        if (Health.dead)
        {
            SceneManager.LoadScene("Level 1");
        }
        */
    }
}
