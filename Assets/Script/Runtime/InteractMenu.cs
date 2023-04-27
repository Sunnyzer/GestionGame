using UnityEngine;

public class InteractMenu : MonoBehaviour, IInteract
{
    [SerializeField] protected Transform uiMenu;
    public virtual void Interaction()
    {
        UIManager.Instance.DisplayInteractUI(uiMenu);
    }
}
