using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WindowLoad : MonoBehaviour
{
    private Movement M;
    public GameObject LoadWindow;

    public void OpenWindow()
    {
        M = FindAnyObjectByType<Movement>();
        if (M.WindowActive == false)
        {
            GameObject CSW = (GameObject)Instantiate(LoadWindow);
            M.WindowActive = true;
        }
    }

    public void ExitWindow()
    {
        M = FindAnyObjectByType<Movement>();
        M.WindowActive = false;
        Destroy(LoadWindow);
    }
}
