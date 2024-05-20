using UnityEngine;

public class WindEffect : MonoBehaviour
{
    [SerializeField] private Car car;
    [SerializeField][Range(0.0f, 1.0f)] private float normalizeSpeedWind;
    [SerializeField] GameObject windPrefab;
    [SerializeField] private new AudioSource audio;

    private void Update()
    {
        if (car.NormalizeLinearVelocity >= normalizeSpeedWind)
        {
            windPrefab.SetActive(true);
            if (audio.isPlaying == false)
                audio.Play();
        }
        else
        {
            windPrefab.SetActive(false);
            audio.Stop();
        }
            
    }
}
