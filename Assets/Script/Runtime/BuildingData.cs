using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BuildingData : ISelectable
{
    [SerializeField] string name;
    [SerializeField] Transform mesh;
    [SerializeField] Texture2D texture;
    [SerializeField] List<Resource> resourcesEarn;
    [SerializeField] List<Resource> resourcesToBuild;
    [SerializeField] List<Resource> resourcesToUpgrade;
    [SerializeField] float generationRate = 1;
    [SerializeField] BuildingChoice buildingUpgrade;

    public string Name => name;
    public Transform Mesh => mesh;
    public Texture2D Texture => texture;
    public List<Resource> ResourceEarn => resourcesEarn;
    public List<Resource> ResourcesToBuild => resourcesToBuild;
    public List<Resource> ResourcesToUpgrade => resourcesToUpgrade;
    public float GenerationRate => generationRate;
    public BuildingData BuildingUpgrade => buildingUpgrade;

    public void CreateBuilding(Vector3 _position)
    {
        Building _prefab = DataTableManager.Instance.BuildingDataTable.BuildingPrefab;
        Building building = GameObject.Instantiate(_prefab, _position, Quaternion.identity);
        building.SetBuildingData(this);
    }
    public void Select(RaycastHit _result)
    {
        if(_result.collider.gameObject == Ground.Instance.gameObject && PlayerInventory.Instance.UseResources(resourcesToBuild))
            CreateBuilding(_result.point);
    }
    public void Deselect()
    {
        
    }
}
