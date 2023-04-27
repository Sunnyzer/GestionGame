using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(Resource),true)]
public class ResourceDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        ResourcesDataTable _resourcesDataTable = (ResourcesDataTable)Resources.Load("ResourcesDataTable");
        string[] _names = _resourcesDataTable.Datas.Select(t => t.Name).ToArray();
        Rect _rect = new Rect(position.position, new Vector2(100,25));
        SerializedProperty _currentIndex = property.FindPropertyRelative("id");
        _currentIndex.intValue = EditorGUI.Popup(_rect, _currentIndex.intValue, _names);
        _rect = new Rect(position.position - Vector2.down * 20, new Vector2(100, 18));
        SerializedProperty _s = property.FindPropertyRelative("amount");
        _s.intValue = EditorGUI.IntField(_rect, _s.intValue);
        EditorGUI.EndProperty();
    }
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return 40;
    }
}