using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningScene : MonoBehaviour
{
    public void BeginGame()
    {
        SceneManager.LoadScene("Start Menu");
    }
}
