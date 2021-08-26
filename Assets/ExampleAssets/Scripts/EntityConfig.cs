using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EntityConfig : ScriptableObject
{
    [SerializeField] List<EntityDescriptor> _entityDescriptors = new List<EntityDescriptor>();

    public EntityDescriptor FindByUuid(string uuid)
    {
        foreach (var entityDescriptor in _entityDescriptors)
        {
            if (entityDescriptor.Uuid == uuid)
                return entityDescriptor;
        }
        
        return null;
    }
}
