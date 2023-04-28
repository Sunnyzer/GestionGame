using System;
using UnityEngine;

[Serializable]
public class Resource
{
    [SerializeField,HideInInspector] int id = 0;
    [SerializeField] int amount;
    public int ID => id;
    public int Amount => amount;
    public static implicit operator ResourceData(Resource _resource)
    {
        return DataTableManager.Instance.ResourcesDataTable.Datas[_resource.id];
    }
}
