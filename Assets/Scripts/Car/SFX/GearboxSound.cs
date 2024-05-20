using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GearboxSound : MonoBehaviour
{
    [SerializeField] private Car car;

    private AudioSource gearboxAudioSource;

    private void Start()
    {
        gearboxAudioSource = GetComponent<AudioSource>();
    }

    public void GearboxAudioPlay()
    {
        gearboxAudioSource.Play();
    }
}
