using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildingUI : InteractUI
{
    [SerializeField] Button upgradeButton = null;
    [SerializeField] GridLayoutGroup gridResourcesToUpgrade;
    [SerializeField] GridLayoutGroup gridResourceEarn = null;

    public void Init(Building _building)
    {
        UIManager.Instance.InteractWindow.SetObjectName(_building.BuildingData.Name);
        if (_building.BuildingData.BuildingUpgrade == null)
        {
            upgradeButton.gameObject.SetActive(false);
        }
        else
        {
            upgradeButton.onClick.AddListener(_building.BuyUpgrade);
            Resource.AddToUIGridResources(_building.BuildingData.ResourcesToUpgrade, gridResourcesToUpgrade.transform);
        }
        Resource.AddToUIGridResources(_building.BuildingData.ResourceEarn, gridResourceEarn.transform);
    }
    private void OnDestroy()
    {
        upgradeButton.onClick.RemoveAllListeners();
    }
}
