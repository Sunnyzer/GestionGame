using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
    void Update()
    {
        bool _mouseDown = Input.GetMouseButtonDown(0);
        if (!_mouseDown) return;
        Hand.Instance.Interact();
    }
}
