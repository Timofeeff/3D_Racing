using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PauseAudioSource : MonoBehaviour, IDependency<Pauser>
{
    private new AudioSource audio;
    private Pauser pauser;
    public void Construct(Pauser obj) => pauser = obj;

    private void Start()
    {
        audio = GetComponent<AudioSource>();

        pauser.PauseStateChange += OnPauseStateChange;
    }

    private void OnDestroy()
    {
        pauser.PauseStateChange -= OnPauseStateChange;
    }

    private void OnPauseStateChange(bool pause)
    {
        if (pause == true)
            audio.Stop();

        if (pause == false)
            audio.Play();
    }
}
