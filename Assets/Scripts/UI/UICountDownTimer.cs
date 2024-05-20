using UnityEngine;
using UnityEngine.UI;

public class UICountDownTimer : MonoBehaviour, IDependency<RaceStateTracker>
{
    [SerializeField] private Image panel;
    [SerializeField] private Text text;
    [SerializeField] private Timer counDownTimer;

    private RaceStateTracker raceStateTracker;
    public void Construct(RaceStateTracker obj) => raceStateTracker = obj;

    private void Start()
    {
        raceStateTracker.PreparationStarted += OnPreparationStarted;
        raceStateTracker.Started += OnRaceStarted;

        panel.enabled = false;
        text.enabled = false;
    }

    private void OnDestroy()
    {
        raceStateTracker.PreparationStarted -= OnPreparationStarted;
        raceStateTracker.Started -= OnRaceStarted;
    }

    private void OnPreparationStarted() 
    {
        panel.enabled = true;
        text.enabled = true;
        enabled = true; 
    }

    private void OnRaceStarted()
    {
        panel.enabled = false;
        text.enabled = false;
        enabled = false;
    }

    private void Update()
    {
        text.text = raceStateTracker.CountDownTimer.Value.ToString("F0");

        if (text.text == "0")
            text.text = "GO!";
    }
}
