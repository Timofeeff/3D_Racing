using System;
using UnityEngine;

[CreateAssetMenu]
public class ResolutionSetting : Setting
{
    [SerializeField]
    private Vector2Int[] avalibaleResolution = new Vector2Int[] 
    {
        new Vector2Int(800, 600),
        new Vector2Int(1280, 720),
        new Vector2Int(1600, 900),
        new Vector2Int(1920, 1080),
    };

    private int currentResolutionIndex = 0; 

    public override bool isMinValue { get => currentResolutionIndex == 0; }
    public override bool isMaxValue { get => currentResolutionIndex == avalibaleResolution.Length - 1;}

    public override void SetNextValue()
    {
        if (isMaxValue == false)
        {
            currentResolutionIndex++;
        }
    }

    public override void SetPreviousValue()
    {
        if (isMinValue == false)
        {
            currentResolutionIndex--;
        }
    }

    public override object GetValue()
    {
        return avalibaleResolution[currentResolutionIndex];
    }

    public override string GetStringValue()
    {
        return avalibaleResolution[currentResolutionIndex].x + "x" + avalibaleResolution[currentResolutionIndex].y;
    }

    public override void Apply()
    {
        Screen.SetResolution(avalibaleResolution[currentResolutionIndex].x, avalibaleResolution[currentResolutionIndex].y, true);

        Save();
    }

    public override void Load()
    {
        currentResolutionIndex = PlayerPrefs.GetInt(title, avalibaleResolution.Length - 1);
    }

    private void Save()
    {
        PlayerPrefs.SetInt(title, currentResolutionIndex);
    }
}
