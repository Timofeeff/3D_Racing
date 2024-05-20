using UnityEngine;
using UnityEngine.UI;

public class UIHints : MonoBehaviour, IDependency<RaceStateTracker>
{
    [SerializeField] private Image panel;
    [SerializeField] private Text text;

    private RaceStateTracker raceStateTracker;
    public void Construct(RaceStateTracker obj) => raceStateTracker = obj;

    private void Start()
    {
        raceStateTracker.PreparationStarted += OnPreparationStarted;

        panel.enabled = true;
        text.enabled = true;
        enabled = true;
    }

    private void OnDestroy()
    {
        raceStateTracker.PreparationStarted -= OnPreparationStarted;
    }

    private void OnPreparationStarted()
    {
        panel.enabled = false;
        text.enabled = false;
    }
}
