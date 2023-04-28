using TMPro;
using UnityEngine;

public class InteractWindow : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI objectName = null;
    [SerializeField] Transform interactUI = null;
    public TextMeshProUGUI ObjectName => objectName;
    public Transform InteractUI => interactUI;
    public InteractUI currentInteractUI = null;

    public void SetInteractUI(InteractUI _interactUI)
    {
        if (currentInteractUI) 
             Destroy(currentInteractUI.gameObject);
        currentInteractUI = _interactUI;
        currentInteractUI.transform.SetParent(interactUI);
        currentInteractUI.transform.position = interactUI.transform.position;
    }
    public void SetObjectName(string _objectName)
    {
        objectName.text = _objectName;
    }
}
