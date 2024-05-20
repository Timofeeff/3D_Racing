using System;
using UnityEngine;

public class UIPausePanel : MonoBehaviour, IDependency<Pauser>
{
    [SerializeField] private GameObject panel;

    private Pauser pauser;
    public void Construct(Pauser obj) => pauser = obj;

    private void Start()
    {
        panel.SetActive(false);
        pauser.PauseStateChange += OnPauseStateChanged;
    }

    private void OnDestroy()
    {
        pauser.PauseStateChange -= OnPauseStateChanged;
    }

    private void OnPauseStateChanged(bool isPause)
    {
        panel.SetActive(isPause);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) == true)
        {
            pauser.ChangePauseState();
        }
    }

    public void Unpause()
    {
        pauser.UnPause();
    }
}
