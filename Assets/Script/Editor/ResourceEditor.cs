using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(Resource))]
public class ResourceEditor : PropertyDrawer
{
    int i = 0;
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        ResourcesDataTable _resourcesDataTable = (ResourcesDataTable)Resources.Load("ResourcesDataTable");
        if (!_resourcesDataTable) return;
        string[] _names = _resourcesDataTable.Datas.Select(t => t.Name).ToArray();
        GUILayout.BeginVertical();
        i = EditorGUILayout.MaskField(i, _names);
        GUILayout.EndVertical();
        string _name = property.FindPropertyRelative("name").stringValue;
        _name = _names[i];
        property.serializedObject.ApplyModifiedProperties();
    }
}