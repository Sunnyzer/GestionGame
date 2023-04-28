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
    [SerializeField] string resourceEarnSentence = "Resource Earn : ";

    public void Init(Building _building)
    {
        //upgradeButton.onClick.AddListener();
        List<Resource> resources = _building.BuildingData.ResourceEarn;
        for (int i = 0; i < resources.Count; i++)
        {
            ResourcesDataTable _resourcesDataTable = DataTableManager.Instance.ResourcesDataTable;
            ResourceUI _resourceUI = Instantiate(_resourcesDataTable.ResourceUI, gridResourcesToUpgrade.transform);
            _resourceUI.Init(resources[i]);
            GameObject _textResource = new GameObject(_resourcesDataTable.Datas[resources[i].ID].Name);
            TextMeshProUGUI _text = _textResource.AddComponent<TextMeshProUGUI>();
            _text.text = resourceEarnSentence + _resourcesDataTable.Datas[resources[i].ID].Name + " " + resources[i].Amount;
            _text.fontSize = 15;
            _text.horizontalAlignment = HorizontalAlignmentOptions.Center;
            _text.verticalAlignment = VerticalAlignmentOptions.Middle;
            _text.transform.SetParent(gridResourceEarn.transform);
        }

    }
}
