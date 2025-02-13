using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUIHandler : MonoBehaviour
{
    public ThirdPersonController controller;

    public void Resume()
    {
        controller.paused = controller.TogglePause();
    }

    public void Return()
    {
        Resume();
        SceneManager.LoadScene(0);
    }
}
