using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class EndZone : MonoBehaviour
{
    public GameManager manager;
    private CannonController cannon;
    public GameObject barrier;
    public AudioClip victory_noise;
    public TextMeshProUGUI victory1_text;
    public TextMeshProUGUI victory2_text;
    [Range(0f, 1f)] private float victory_volume = 1f;
    [SerializeField] private float launch_delay;
    [SerializeField] private ParticleSystem confetti;
    // Start is called before the first frame update
    void Start()
    {
        cannon = GameObject.Find("End Cannon Controller").gameObject.GetComponent<CannonController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && manager.count_time)
        {
            AudioSource.PlayClipAtPoint(victory_noise, transform.position, victory_volume);
            if(manager.times_completed == 0)
            {
                victory1_text.gameObject.SetActive(true);
            }
            else
            {
                victory2_text.gameObject.SetActive(true);
            }
            manager.times_completed++;
            confetti.Play();
            barrier.SetActive(true);
            StartCoroutine(LaunchCountdown());
            manager.StopTimer();
            
        }
    }

    private IEnumerator LaunchCountdown()
    {
        yield return new WaitForSeconds(launch_delay);
        confetti.Stop();
        cannon.is_active = true;
        cannon.SpawnProjectile();
        cannon.is_active = false;
        barrier.SetActive(false);
        yield return new WaitForSeconds(2.0f);
        victory1_text.gameObject.SetActive(false);
        victory2_text.gameObject .SetActive(false);
    }
}
