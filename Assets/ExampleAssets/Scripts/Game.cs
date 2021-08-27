using UnityEngine;

public class Game : MonoBehaviour
{
    public EntityConfig EntityConfig;

    public void SaveGame(bool useJson)
    {
        SaveData saveData = ScriptableObject.CreateInstance<SaveData>();

        var entities = FindObjectsOfType<Entity>();
        saveData.SetEntities(entities);

        if (useJson)
        {
            SaveManager.SaveJson("savedata01.json", saveData);
        }
        else
        {
            SaveManager.SaveBinary("savedata01.dat", saveData);
        }
    }

    public void LoadGame(bool useJson)
    {
        var entities = FindObjectsOfType<Entity>();
        foreach (var entity in entities)
        {
            Destroy(entity.gameObject);
        }

        SaveData saveData = ScriptableObject.CreateInstance<SaveData>();
        if (useJson)
        {
            SaveManager.LoadJson("savedata01.json", saveData);
        }
        else
        {
            SaveManager.LoadBinary("savedata01.dat", saveData);
        }

        for (int i = 0; i < saveData.EntityUuids.Length; ++i)
        {
            var entityUuid = saveData.EntityUuids[i];
            var entityPosition = saveData.EntityPositions[i];

            var entityDescriptor = EntityConfig.FindByUuid(entityUuid);
            Instantiate(entityDescriptor.Prefab, entityPosition, Quaternion.identity);
        }
    }
}