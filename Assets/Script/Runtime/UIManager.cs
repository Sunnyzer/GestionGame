using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] InteractWindow interactWindow = null;
    public InteractWindow InteractWindow => interactWindow;
    public void DisplayInteractUI(InteractUI _ui)
    {
        interactWindow.SetInteractUI(_ui);
    }
}
