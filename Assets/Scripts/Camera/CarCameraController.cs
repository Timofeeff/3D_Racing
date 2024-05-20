using UnityEngine;

public class CarCameraController : MonoBehaviour, IDependency<RaceStateTracker>
{
    [SerializeField] private Car car;
    [SerializeField] private new Camera camera;
    [SerializeField] private CarCameraBloom bloom;
    [SerializeField] private CarCameraFollow follower;
    [SerializeField] private CarCameraFovCorrector fovCorrectorer;
    [SerializeField] private CarCameraShaker shaker;
    [SerializeField] private CarCameraVignette vignette;
    [SerializeField] private CarCameraPathFollower pathFollower;

    private RaceStateTracker raceStateTracker;
    public void Construct(RaceStateTracker obj) => raceStateTracker = obj;

    private void Awake()
    {
        bloom.SetProperties(car, camera);
        follower.SetProperties(car, camera);
        fovCorrectorer.SetProperties(car, camera);
        shaker.SetProperties(car, camera);
        vignette.SetProperties(car, camera);
    }

    private void Start()
    {
        raceStateTracker.PreparationStarted += OnPreparationStarted;
        raceStateTracker.Completed += OnCompleted;

        follower.enabled = false;
        pathFollower.enabled = true;
    }

    private void OnDestroy()
    {
        raceStateTracker.PreparationStarted -= OnPreparationStarted;
        raceStateTracker.Completed -= OnCompleted;
    }

    private void OnPreparationStarted()
    {
        follower.enabled = true;
        pathFollower.enabled = false;
    }

    private void OnCompleted()
    {
        pathFollower.enabled = true;
        pathFollower.StartMoveToNearesPoint();
        pathFollower.SetLookTarget(car.transform);

        follower.enabled = false;
    }
}
