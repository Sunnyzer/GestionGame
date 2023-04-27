using UnityEngine;

public class Farmer : MonoBehaviour, IInteract
{
    [SerializeField] FarmerStat stat;
    public FarmerStat Stat => stat;

    public void Interaction()
    {
        PlayerController.Instance.SelectItem(this);
    }
}
