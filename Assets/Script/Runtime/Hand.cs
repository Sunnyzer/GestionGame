using UnityEditor;
using UnityEngine;

public class Hand : Singleton<Hand>
{
    [SerializeField] LayerMask layerMask;

    ISelectable selectable = null;

    public ISelectable CurrentSelect => selectable;

    public void SetSelectable(ISelectable _selectable)
    {
        if (selectable != null)
            selectable.Deselect();
        selectable = _selectable;
    }
    public void Deselect()
    {
        selectable.Deselect();
        selectable = null;
    }
    public void Interact()
    {
        bool _hit = PlayerCursor.Instance.Hit(out RaycastHit _raycastHit, layerMask);
        if (!_hit) return;
        if(selectable != null)
        {
            if (_raycastHit.collider.TryGetComponent(out ISelectable _selectable) && _selectable == selectable)
            {
                selectable?.Deselect();
                selectable = null;
                return;
            }
            selectable.Select(_raycastHit);
            return;
        }
        IInteract _interact = _raycastHit.collider.GetComponent<IInteract>();
        if (_interact == null) return;
        _interact.Interaction();
    }
}
