using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BuildingChoice
{
    [SerializeField,HideInInspector] int id = 0;
    public static implicit operator BuildingData(BuildingChoice _choice)
    {
        return DataTableManager.Instance.BuildingDataTable.Buildings[_choice.id];
    }
}
