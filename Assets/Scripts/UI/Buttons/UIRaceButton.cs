using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIRaceButton : UISelectableButton, IScriptableObjectProperty
{
    [SerializeField] private RaceInfo raceInfo;

    [SerializeField] private int scoreLocker;

    [SerializeField] private Image icon;
    [SerializeField] private Image locker;
    [SerializeField] private Text title;

    public Image Locker { get => locker; set => locker = value; }

    private void Start()
    {
        ApplyProperty(raceInfo);
        FadeButton();
    }

    private void Update()
    {
        FadeButton();
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);

        if (raceInfo == null || Interactable == false) return;

        SceneManager.LoadScene(raceInfo.SceneName);
    }

    public void ApplyProperty(ScriptableObject property)
    {
        if (property == null) return;

        if (property is RaceInfo == false) return; 

        raceInfo = property as RaceInfo; 

        icon.sprite = raceInfo.Icon;
        title.text = raceInfo.Title;
    }

    public void FadeButton()
    {
        if (raceInfo == null) return;

        int score = PlayerPrefs.GetInt(RaceResultTime.SaveMarcScore, 0);

        if (scoreLocker <= score)
        {
            locker.enabled = false;
            Interactable = true;
        }
        else
        {
            locker.enabled = true;
            Interactable = false;
        }
    }
}
