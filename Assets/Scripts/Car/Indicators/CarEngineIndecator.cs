using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
class EngineIndecatorColor
{
    public float MaxRpm;
    public Color color;
}

public class CarEngineIndecator : MonoBehaviour
{
    [SerializeField] private Car car;
    [SerializeField] private Image image;
    [SerializeField] private EngineIndecatorColor[] colors;

    private void Update()
    {
        image.fillAmount = car.EngineRpm / car.EngineMaxRpm;

        for (int i = 0; i < colors.Length; i++)
        {
            if (car.EngineRpm <= colors[i].MaxRpm)
            {
                image.color = colors[i].color;
                break;
            }
        }
    }
}
