using UnityEngine;

public class Farmer : MonoBehaviour, IInteract, ISelectable
{
    [SerializeField] FarmerStat stat;
    [SerializeField] MeshRenderer meshRenderer;
    [SerializeField] Building myBuilding;

    public Building MyBuilding => myBuilding;
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
            if(myBuilding)
            {
                myBuilding.RemoveFarmer(this);
            }
            _building.AddFarmer(this);
            myBuilding = _building;
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
