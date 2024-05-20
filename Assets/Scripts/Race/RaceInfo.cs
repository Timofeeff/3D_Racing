using UnityEngine;

[CreateAssetMenu]
public class RaceInfo : ScriptableObject
{
    [SerializeField] private string sceneName;
    [SerializeField] private Sprite icon;
    [SerializeField] private string title; 
    [SerializeField] private RaceInfo previouseRaceInfo;

    public string SceneName => sceneName;
    public Sprite Icon => icon;
    public string Title => title;

    public RaceInfo PreviouseRaceInfo { get => previouseRaceInfo; set => previouseRaceInfo = value; }
}
