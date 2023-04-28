using System;
using System.Collections.Generic;
using Unity.VisualScripting;

public class PlayerInventory : Singleton<PlayerInventory>
{
    public event Action<int, int> OnResourceChange;
    Dictionary<int, int> inventory = new Dictionary<int, int>();
    public Dictionary<int, int> Inventory
    {
        get
        {
            if (inventory.Count == 0)
                Init();
            return inventory;
        }
    }
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
        if (inventory.Count != 0) return;
        List<ResourceData> data = DataTableManager.Instance.ResourcesDataTable.Datas;
        for (int i = 0; i < data.Count; i++)
        {
            inventory.Add(i, 0);
        }
    }
    public bool HaveEnoughResources(List<Resource> _inventory)
    {
        foreach (Resource _resource in _inventory)
        {
            if (!HaveEnoughResources(_resource))
                return false;
        }
        return true;
    }
    public bool HaveEnoughResources(Dictionary<int, int> _inventory)
    {
        foreach (KeyValuePair<int, int> _resource in _inventory)
        {
            if (!HaveEnoughResources(_resource.Key, _resource.Value))
                return false;
        }
        return true;
    }
    public bool HaveEnoughResources(Resource _resource) => HaveEnoughResources(_resource.ID, _resource.Amount);
    public bool HaveEnoughResources(int _ID, int _amount) => _amount <= Inventory[_ID];
    public bool UseResources(List<Resource> _inventory)
    {
        if (!HaveEnoughResources(_inventory)) return false;
        foreach (Resource _resource in _inventory)
            RemoveResource(_resource);
        return true;
    }
    public bool UseResources(Dictionary<int, int> _inventory)
    {
        if (!HaveEnoughResources(_inventory)) return false;
        foreach (var _resource in _inventory)
            RemoveResource(_resource.Key, _resource.Value);
        return true;
    }
    public void AddResource(Resource _resource)
    {
        AddResource(_resource.ID, _resource.Amount);
    }
    public void AddResource(int _ID, int _amount)
    {
        inventory[_ID] += _amount;
        OnResourceChange?.Invoke(_ID, inventory[_ID]);
    }
    public void RemoveResource(Resource _resource)
    {
        RemoveResource(_resource.ID, _resource.Amount);
    }
    public void RemoveResource(int _ID, int _amount)
    {
        inventory[_ID] -= _amount;
        OnResourceChange?.Invoke(_ID, inventory[_ID]);
    }
}
