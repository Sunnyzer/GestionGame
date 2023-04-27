using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(BuildingChoice))]
public class BuildingChoiceDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        BuildingDataTable _buildingDataTable = (BuildingDataTable)Resources.Load("BuildingDataTable");
        string[] _names = _buildingDataTable.Buildings.Select(t => t.Name).ToArray();
        SerializedProperty _currentIndex = property.FindPropertyRelative("id");
        _currentIndex.intValue = EditorGUI.Popup(position, _currentIndex.intValue, _names);
    }
}
