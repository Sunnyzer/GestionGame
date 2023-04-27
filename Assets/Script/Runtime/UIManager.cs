using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] InteractWindow interactWindow = null;
    public InteractWindow InteractWindow => interactWindow;
    public void DisplayInteractUI(Transform _ui)
    {
        Transform _menu = Instantiate(_ui);
        interactWindow.SetInteractUI(_menu);
    }
}
