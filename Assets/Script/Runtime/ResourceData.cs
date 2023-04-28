using System;
using UnityEngine;

[Serializable]
public class ResourceData
{
    [SerializeField] string name;
    [SerializeField] Sprite sprite;
    public string Name => name;
    public Sprite Sprite => sprite;
}
