using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BuildingData
{
    [SerializeField] string name;
    [SerializeField] Transform mesh;
    [SerializeField] Transform ui;
    [SerializeField] Texture2D texture;
    [SerializeField] List<Resource> resourcesEarn;
    [SerializeField] List<Resource> resourcesToBuild;
    [SerializeField] float generationRate = 1;

    public string Name => name;
    public Transform Mesh => mesh;
    public Transform UI => ui;
    public Texture2D Texture => texture;
    public List<Resource> ResourceEarn => resourcesEarn;
    public List<Resource> ResourcesToBuild => resourcesToBuild;
    public float GenerationRate => generationRate;
}
