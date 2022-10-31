using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private GameObject levelShift;

    // Update is called once per frame
    void Update()
    {
        if (levelShift != null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D colliosion)
    {
        if (colliosion.CompareTag("Player"))
        {
            levelShift = colliosion.gameObject;
        }
    }

}
