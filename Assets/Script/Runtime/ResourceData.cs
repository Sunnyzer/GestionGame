using System;
using UnityEngine;

[Serializable]
public class ResourceData
{
    [SerializeField] string name;
    [SerializeField] Texture2D texture;
    public string Name => name;
    public Texture2D Texture => texture;
}
