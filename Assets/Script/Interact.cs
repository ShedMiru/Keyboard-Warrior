using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Interact : MonoBehaviour
{
    private Movement M;
    public GameObject TextWindow;
    public GameObject Button;
    public bool exist;

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (!exist && col.tag == "Player")
        {
            GameObject TXT = (GameObject)Instantiate(Button);
            exist = true;
        }
    }

    public void OpenTextWindow()
    {
        M = FindAnyObjectByType<Movement>();
        Destroy(Button);
        exist = false;
        if (M.WindowActive == false)
        {
            GameObject TXT = (GameObject)Instantiate(TextWindow);
            M.WindowActive = true;
        }
    }
    public void ExitTextWindow()
    {
        M = FindAnyObjectByType<Movement>();
        M.WindowActive = false;
        Destroy(TextWindow);
    }
}
