using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class RaceResultTime : MonoBehaviour, IDependency<RaceTimeTracker>, IDependency<RaceStateTracker>
{
    public static string SaveMark = "_player_best_time";

    public static string SaveMarcScore = "_player_score";

    public event UnityAction ResultUpdated;

    [SerializeField] private float goldTime;

    private float playerRecordTime;
    private float currentTime;

    private int score = 0;
    public int Score => score;

    public float GoldTime => goldTime;
    public float PlayerRecordTime => playerRecordTime;
    public float CurrentTime => currentTime;
    public bool RecordWasSet => playerRecordTime != 0; 

    private RaceTimeTracker raceTimeTracker;
    public void Construct(RaceTimeTracker obj) => raceTimeTracker = obj;

    private RaceStateTracker raceStateTracker;
    public void Construct(RaceStateTracker obj) => raceStateTracker = obj;

    private void Awake()
    {
        Load();
    }

    private void Start()
    {
        raceStateTracker.Completed += OnRaceCompleted;
    }

    private void OnDestroy()
    {
        raceStateTracker.Completed -= OnRaceCompleted;
    }

    private void OnRaceCompleted()
    {

        float absoluteRecord = GetAbsoluteRecord(); 

        if (raceTimeTracker.CurrentTime < absoluteRecord || playerRecordTime == 0) 
        {
            playerRecordTime = raceTimeTracker.CurrentTime; 

            if (raceTimeTracker.CurrentTime < goldTime)
            {
                score += 1;
            }

            Save();
        }

        currentTime = raceTimeTracker.CurrentTime; 

        ResultUpdated?.Invoke();
    }

    public float GetAbsoluteRecord()
    {
        if (playerRecordTime < goldTime && playerRecordTime != 0)
        {
            return playerRecordTime;
        }
        else
        {
            return goldTime;
        }
    }

    public void Load()
    {
        playerRecordTime = PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name + SaveMark, 0);
        score = PlayerPrefs.GetInt(SaveMarcScore, 0);
    }

    private void Save()
    {
        PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + SaveMark, playerRecordTime);
        PlayerPrefs.SetInt(SaveMarcScore, score);
    }
}
