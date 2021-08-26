using UnityEngine;

[CreateAssetMenu]
public class SaveData : ScriptableObject
{
    public int Version;
    public int PlayerHealth;
    public Vector3 PlayerPosition;
    public string[] EntityUuids;
    public Vector3[] EntityPositions;

    void OnEnable()
    {
        Version = SaveManager.CurrentSaveVersion;
    }

    public void SetEntities(Entity[] entities)
    {
        EntityUuids = new string[entities.Length];
        EntityPositions = new Vector3[entities.Length];
        for (int i = 0; i < entities.Length; ++i)
        {
            EntityUuids[i] = entities[i].EntityDescriptor.Uuid;
            EntityPositions[i] = entities[i].transform.position;
        }
    }
}