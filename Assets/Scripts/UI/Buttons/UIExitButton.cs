using UnityEngine;
using UnityEngine.UI;

public class UIExitButton : MonoBehaviour
{
    [SerializeField] private Button exitButton;

    public void Quit()
    {
        Application.Quit();
    }
}
