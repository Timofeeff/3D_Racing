using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CarCameraBloom : CarCameraComponent
{
    [SerializeField][Range(0.0f, 1.0f)] private float normalizeSpeedBloom;
    [SerializeField] private float bloomAmount;
    [SerializeField] private float maxBloomAmount;

    private PostProcessVolume postProcessing;
    private Bloom bloom;

    private void Awake()
    {      
        postProcessing = GetComponent<PostProcessVolume>();
        postProcessing.profile.TryGetSettings(out bloom);
    }

    private void Update()
    {
        if (car.NormalizeLinearVelocity > normalizeSpeedBloom)
        {
            bloom.intensity.value += bloomAmount * Time.deltaTime;

            if (bloom.intensity.value > maxBloomAmount)
            {
                bloom.intensity.value = maxBloomAmount;
            }
        }
        else
        {
            bloom.intensity.value -= bloomAmount * Time.deltaTime;

            if (bloom.intensity.value <= 0)
                bloom.intensity.value = 0;
        }
    }
}
