using UnityEngine;

public class SceneDependenciesContainer : Dependency
{
    [SerializeField] private RaceStateTracker raceStateTracker;
    [SerializeField] private CarInputControl carInputControl;
    [SerializeField] private TrackpointCircuit trackpointCircuit;
    [SerializeField] private Car car;
    [SerializeField] private CarCameraController carCameraController;
    [SerializeField] private RaceTimeTracker raceTimeTracker;
    [SerializeField] private RaceResultTime raceResultTime;
   
    protected override void BindAll(MonoBehaviour monoBehaviourInScene)
    {
        Bind<RaceStateTracker>(raceStateTracker, monoBehaviourInScene);
        Bind<CarInputControl>(carInputControl, monoBehaviourInScene);
        Bind<TrackpointCircuit>(trackpointCircuit, monoBehaviourInScene);
        Bind<Car>(car, monoBehaviourInScene);
        Bind<CarCameraController>(carCameraController, monoBehaviourInScene);
        Bind<RaceTimeTracker>(raceTimeTracker, monoBehaviourInScene);
        Bind<RaceResultTime>(raceResultTime, monoBehaviourInScene);
    }

    private void Awake()
    {
        FindAllObjectToBind();
    }
}
