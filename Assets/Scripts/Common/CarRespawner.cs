using UnityEngine;

public class CarRespawner : MonoBehaviour, IDependency<RaceStateTracker>, IDependency<Car>, IDependency<CarInputControl>
{
    [SerializeField] private float respawnHeight;

    private TrackPoint respawnTrackPoint;

    private RaceStateTracker raceStateTracker;
    public void Construct(RaceStateTracker obj) => raceStateTracker = obj;

    private Car car;
    public void Construct(Car obj) => car = obj;

    private CarInputControl carControl;
    public void Construct(CarInputControl obj) => carControl = obj;

    private void Start()
    {
        raceStateTracker.TrackPointPassed += OnTrackPointPassed;
    }

    private void OnDestroy()
    {
        raceStateTracker.TrackPointPassed -= OnTrackPointPassed;
    }

    private void OnTrackPointPassed(TrackPoint point)
    {
        respawnTrackPoint = point; 
    }

    private void Respawn()
    {
        if (respawnTrackPoint == null) return; 
                                               
        if (raceStateTracker.State != RaceState.Race) return; 

        car.Respawn(respawnTrackPoint.transform.position + respawnTrackPoint.transform.up * respawnHeight, respawnTrackPoint.transform.rotation);

        carControl.Reset();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) == true)
        {
            Respawn();
        }
    }
}
