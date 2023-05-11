using System;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

[Serializable]
public class Resource
{
    [SerializeField,HideInInspector] int id = 0;
    [SerializeField] int amount;
    public int ID => id;
    public int Amount => amount;
    public Resource(int _ID, int _amount)
    {
        id = _ID;
        amount = _amount;
    }
    public static implicit operator ResourceData(Resource _resource)
    {
        return DataTableManager.Instance.ResourcesDataTable.Datas[_resource.id];
    }
    public static void AddToUIGridResources(List<Resource> _resources, Transform _grid)
    {
        for (int i = 0; i < _grid.childCount; i++)
        {
            GameObject.Destroy(_grid.GetChild(i).gameObject);
        }
        for (int i = 0; i < _resources.Count; i++)
        {
            ResourcesDataTable _resourcesDataTable = DataTableManager.Instance.ResourcesDataTable;
            ResourceUI _resourceUI = GameObject.Instantiate(_resourcesDataTable.ResourceUI, _grid);
            _resourceUI.Init(_resources[i]);
        }
    }
}
