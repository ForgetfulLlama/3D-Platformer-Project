using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI best_time_text;
    // Start is called before the first frame update
    void Start()
    {
        string best_time = "N/A";
        if(MainManager.Instance.best_str != "") { best_time = MainManager.Instance.best_str; }
        best_time_text.text = "Best Time - " + best_time;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        MainManager.Instance.Save();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
