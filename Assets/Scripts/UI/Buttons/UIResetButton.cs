using UnityEngine;
using UnityEngine.UI;

public class UIResetButton : MonoBehaviour
{
    [SerializeField] private Button resetButton;

    public void ResetButton()
    {
        PlayerPrefs.DeleteKey(RaceResultTime.SaveMark);
        PlayerPrefs.DeleteKey(RaceResultTime.SaveMarcScore);
    }
}
