using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ResourcesDataTable", menuName = "ResourcesDataTable", order = 0)]
public class ResourcesDataTable : ScriptableObject
{
    [SerializeField] List<ResourceData> datas = new List<ResourceData>();
    public List<ResourceData> Datas => datas;
}
