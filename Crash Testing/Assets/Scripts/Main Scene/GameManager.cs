using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int times_completed = 0;
    public GameObject maze_parent;
    [SerializeField] private TranslatePlatform[] maze_plats;
    [SerializeField] private TextMeshProUGUI timer_text;
    [SerializeField] private TextMeshProUGUI best_time_text;
    [SerializeField] private CannonController[] disc_cannons;
    private float timer;
    private float minutes;
    private float seconds;
    public bool count_time { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
        times_completed = 0;
        maze_plats = maze_parent.GetComponentsInChildren<TranslatePlatform>();
        if (MainManager.Instance != null)
        {
            best_time_text.text = "Best Time: " + MainManager.Instance.best_str;
        }
        else
        {
            count_time = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (count_time) {
            UpdateTimer();
        }
    }

    private void UpdateTimer()
    {
        timer += Time.deltaTime;
        minutes = Mathf.FloorToInt(timer / 60);
        seconds = Mathf.FloorToInt(timer % 60);
        timer_text.text = "Timer: " + string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void StartTimer()
    {
        timer = 0.0f;
        count_time = true;
    }
    
    public void StopTimer()
    {
        count_time = false;
        if (MainManager.Instance != null)
        {
            if (timer <= MainManager.Instance.best_time || MainManager.Instance.best_str == "")
            {
                MainManager.Instance.UpdateBestTime(timer);
                MainManager.Instance.Save();
                best_time_text.text = "Best Time: " + MainManager.Instance.best_str;
            }
        }
    }

    public void ToggleCannons(bool status)
    {
        foreach(CannonController cannon in disc_cannons)
        {
            if (cannon.is_active != status)
            {
                cannon.is_active = status;
                cannon.ResetCannon();
                if (status)
                {
                    cannon.first_time = true;
                    StartCoroutine(cannon.StartSpawn());
                }
            }
            else { break; }
        }
    }

    public void TogglePlatforms(bool status)
    {
        foreach(TranslatePlatform platform in maze_plats)
        {
            if(platform.active != status) { platform.active = status; } else { break; }
            
        }
    }
}
