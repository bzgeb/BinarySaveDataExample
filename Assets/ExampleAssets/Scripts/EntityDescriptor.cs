using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu]
public class EntityDescriptor : ScriptableObject
{
    public string Uuid;
    public Entity Prefab;

#if UNITY_EDITOR
    void OnValidate()
    {
        var path = AssetDatabase.GetAssetPath(this);
        Uuid = AssetDatabase.AssetPathToGUID(path);
    }

    void Reset()
    {
        var path = AssetDatabase.GetAssetPath(this);
        Uuid = AssetDatabase.AssetPathToGUID(path);
    }
#endif
}