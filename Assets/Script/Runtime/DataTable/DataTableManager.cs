using UnityEngine;

public class DataTableManager : Singleton<DataTableManager>
{
    [SerializeField] ResourcesDataTable resourcesDataTable;
    [SerializeField] BuildingDataTable buildingDataTable;
    public BuildingDataTable BuildingDataTable => buildingDataTable;
    public ResourcesDataTable ResourcesDataTable => resourcesDataTable;
}
