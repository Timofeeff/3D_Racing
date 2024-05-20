using UnityEngine;

public class ActivatedTrackPoint : TrackPoint
{
    [SerializeField] private GameObject hint;

    private void Start()
    {
        hint.SetActive(isTarget); // isTarget чтобы при перезапуске не слетало.
    }

    protected override void OnPassed()
    {
        hint.SetActive(false);
    }

    protected override void OnAssignAsTarget()
    {
        hint.SetActive(true);
    }
}
