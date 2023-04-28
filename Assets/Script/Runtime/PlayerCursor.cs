using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerCursor : Singleton<PlayerCursor>
{
    public bool Hit(out RaycastHit _raycastHit, LayerMask _layerMask)
    {
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        _raycastHit = new RaycastHit();
        if (EventSystem.current.IsPointerOverGameObject()) return false;
        return Physics.Raycast(_ray, out _raycastHit, 100, _layerMask);
    }
}
