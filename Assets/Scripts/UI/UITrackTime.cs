using System;
using UnityEngine;
using UnityEngine.UI;

public class UITrackTime : MonoBehaviour, IDependency<RaceTimeTracker>, IDependency<RaceStateTracker>
{
    [SerializeField] private Image panel;
    [SerializeField] private Text text;

    private RaceTimeTracker raceTimeTracker;
    public void Construct(RaceTimeTracker obj) => raceTimeTracker = obj;

    private RaceStateTracker raceStateTracker;
    public void Construct(RaceStateTracker obj) => raceStateTracker = obj;

    private void Start()
    {
        raceStateTracker.Started += OnRaceStarted;
        raceStateTracker.Completed += OnRaceCompleted;

        panel.enabled = false;
        text.enabled = false;
    }

    private void OnDestroy()
    {
        raceStateTracker.Started += OnRaceStarted;
        raceStateTracker.Completed += OnRaceCompleted;
    }

    private void OnRaceStarted()
    {
        panel.enabled = true;
        text.enabled = true;
        enabled = true;
    }

    private void OnRaceCompleted()
    {
        panel.enabled = false;
        text.enabled = false;
        enabled = false;
    }

    private void Update()
    {
        text.text = StringTime.SecondToTimeString(raceTimeTracker.CurrentTime);
    }
}
