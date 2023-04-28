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
        upgradeButton.onClick.AddListener(_building.Upgrade);
        AddToGridResources(_building.BuildingData.ResourcesToUpgrade, gridResourcesToUpgrade.transform);
        AddToGridResources(_building.BuildingData.ResourceEarn, gridResourceEarn.transform);
    }
    void AddToGridResources(List<Resource> _resources, Transform _grid)
    {
        for (int i = 0; i < _resources.Count; i++)
        {
            ResourcesDataTable _resourcesDataTable = DataTableManager.Instance.ResourcesDataTable;
            ResourceUI _resourceUI = Instantiate(_resourcesDataTable.ResourceUI, _grid);
            _resourceUI.Init(_resources[i]);
        }
    }
    private void OnDestroy()
    {
        upgradeButton.onClick.RemoveAllListeners();
    }
}
