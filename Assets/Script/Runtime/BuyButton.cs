using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuyButton : MonoBehaviour
{
    [SerializeField] BuildingChoice buildingData;
    public void SetBuildingData()
    {
        PlayerController.Instance.SetBuildingData(buildingData);
    }
}
