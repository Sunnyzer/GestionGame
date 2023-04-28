using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildingDataTable", menuName = "BuildingDataTable", order = 0)]
public class BuildingDataTable : ScriptableObject
{
    [SerializeField] BuildingUI buildingUI = null;
    [SerializeField] Building buildingPrefab = null;
    [SerializeField] List<BuildingData> buildings = new List<BuildingData>();
    public List<BuildingData> Buildings => buildings;
    public Building BuildingPrefab => buildingPrefab;
    public BuildingUI BuildingUI => buildingUI;
}
