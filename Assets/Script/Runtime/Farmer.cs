using UnityEngine;

public class Farmer : MonoBehaviour, IInteract, ISelectable
{
    [SerializeField] FarmerStat stat;
    [SerializeField] MeshRenderer meshRenderer;
    public FarmerStat Stat => stat;

    public void Interaction()
    {
        Hand.Instance.SetSelectable(this);
        meshRenderer.material.color = Color.red;
    }

    public void Select(RaycastHit _result)
    {
        if (_result.collider.TryGetComponent(out Building _building))
        {
            _building.AddFarmer(this);
            Hand.Instance.Deselect();
            return;
        }
        transform.position = _result.point;
    }
    public void Deselect()
    {
        meshRenderer.material.color = Color.white;
    }
}
