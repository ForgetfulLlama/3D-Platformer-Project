using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timer_text;
    [SerializeField] private TextMeshProUGUI best_time_text;
    [SerializeField] private Collider spawnCollider;

    private float timer;
    private float minutes;
    private float seconds;
    public bool count_time { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
        //best_time_text.text = "Best Time: " + MainManager.Instance.best_str;
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
        if (timer <= MainManager.Instance.best_time || MainManager.Instance.best_str == "")
        {
            MainManager.Instance.UpdateBestTime(timer);
            MainManager.Instance.Save();
            best_time_text.text = "Best Time: " + MainManager.Instance.best_str;
        }
        
    }
}
