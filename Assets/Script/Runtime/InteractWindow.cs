using TMPro;
using UnityEngine;

public class InteractWindow : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI objectName = null;
    [SerializeField] Transform interactUI = null;
    public TextMeshProUGUI ObjectName => objectName;
    public Transform InteractUI => interactUI;
    public Transform currentInteractUI = null;

    public void SetInteractUI(Transform _interactUI)
    {
        if (currentInteractUI) 
             Destroy(currentInteractUI);
        currentInteractUI = _interactUI;
    }
    public void SetObjectName(string _objectName)
    {
        objectName.text = _objectName;
    }
}
