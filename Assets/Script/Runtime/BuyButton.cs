using UnityEngine;

public class BuyButton : MonoBehaviour
{
    [SerializeField] BuildingChoice buildingData;
    public void SetBuildingData()
    {
        BuildingData _buildingData = buildingData;
        if (PlayerInventory.Instance.UseResources(_buildingData.ResourcesToBuild))
        {
            Hand.Instance.SetSelectable(_buildingData);
        }
    }
}
