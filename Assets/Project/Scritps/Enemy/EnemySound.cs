using UnityEngine;

public class EnemySound : MonoBehaviour {

    public int AudioInterval = 5;

    private float _lastAudioPlaytime = 0;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Time.time - _lastAudioPlaytime > AudioInterval)
        {
            _lastAudioPlaytime = Time.time;
            _audioSource.Play();
        }
    }
}
