using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BuildingData
{
    [SerializeField] Mesh mesh;
    [SerializeField] Texture2D texture;
    [SerializeField] List<Resource> resourceEarn;
    [SerializeField] List<Resource> resourcesToBuild;
}
