using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] GridLayoutGroup gridResources;
    List<ResourceUI> resourceUIs = new List<ResourceUI>();
    private void Start()
    {
        Init();
    }
    public void Init()
    {
        ResourceUI _resourceUIPrefab = DataTableManager.Instance.ResourcesDataTable.ResourceUI;
        PlayerInventory.Instance.OnResourceChange += UpdateResource;
        foreach (var item in PlayerInventory.Instance.Inventory)
        {
            ResourceUI _resourceUI = Instantiate(_resourceUIPrefab, transform);
            _resourceUI.Init(item.Key, item.Value);
            resourceUIs.Add(_resourceUI);
        }
    }
    public void UpdateResource(int _ID, int _newAmount)
    {
        resourceUIs[_ID].Init(_ID, _newAmount);
    }
}
