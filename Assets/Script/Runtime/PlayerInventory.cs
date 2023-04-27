using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : Singleton<PlayerInventory>
{
    Dictionary<int, int> inventory = new Dictionary<int, int>();
    protected override void Awake()
    {
        base.Awake();
    }
    private void Start()
    {
        Init();
    }
    public void Init()
    {
        List<ResourceData> data = DataTableManager.Instance.ResourcesDataTable.Datas;
        for (int i = 0; i < data.Count; i++)
        {
            inventory.Add(i, 0);
        }
    }
    public void AddResource(Resource _resource)
    {
        AddResource(_resource.ID, _resource.Amount);
    }
    public void AddResource(int _ID, int _amount)
    {
        inventory[_ID] = _amount;
    }
}
