using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildingDataTable", menuName = "BuildingDataTable", order = 0)]
public class BuildingDataTable : ScriptableObject
{
    [SerializeField] List<BuildingData> buildings = new List<BuildingData>();
    public List<BuildingData> Buildings => buildings;
}
