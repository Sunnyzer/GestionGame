using UnityEngine;

public class BuyButton : MonoBehaviour
{
    [SerializeField] BuildingChoice buildingData;
    public void SetBuildingData()
    {
        BuildingData _buildingData = buildingData;
        Hand.Instance.SetSelectable(_buildingData);
    }
}
