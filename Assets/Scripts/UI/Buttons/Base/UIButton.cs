using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems; 
using UnityEngine.UI;

public class UIButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] protected bool Interectable;

    public bool Interactable { get => Interectable; set => Interectable = value; }

    private bool focuse = false;
    public bool Focuse => focuse;

    public UnityEvent OnClick; 

    public event UnityAction<UIButton> PointerEnter;
    public event UnityAction<UIButton> PointerExit;
    public event UnityAction<UIButton> PointerClick;

    public virtual void SetFocuse()
    {
        if (Interectable == false) return;

        focuse = true;
    }

    public virtual void SetUnFocuse()
    {
        if (Interectable == false) return;

        focuse = false;
    }

    public virtual void OnPointerEnter(PointerEventData eventData) 
    {
        if (Interectable == false) return;

        PointerEnter?.Invoke(this); 
    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        if (Interectable == false) return;

        PointerExit?.Invoke(this);
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        if (Interectable == false) return;

        PointerClick?.Invoke(this);
        OnClick?.Invoke();
    }
}
