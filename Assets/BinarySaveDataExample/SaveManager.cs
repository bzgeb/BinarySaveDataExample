using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    static string _saveFolderPath;

    public const int CurrentSaveVersion = 1;
    public SaveData SaveData;
    public EntityConfig EntityConfig;

    void OnEnable()
    {
        if (SaveData == null)
            SaveData = ScriptableObject.CreateInstance<SaveData>();

        _saveFolderPath = $"{Application.persistentDataPath}/Saves";

        if (!Directory.Exists(_saveFolderPath))
            Directory.CreateDirectory(_saveFolderPath);
    }

    public void SaveBinary(string fileName, SaveData saveData)
    {
        var fileFullPath = $"{_saveFolderPath}/{fileName}";
        using (BinaryWriter writer = new BinaryWriter(File.Open(fileFullPath, FileMode.OpenOrCreate)))
        {
            writer.Write(saveData.Version);
            writer.Write(saveData.PlayerHealth);
            writer.Write(saveData.PlayerPosition.x);
            writer.Write(saveData.PlayerPosition.y);
            writer.Write(saveData.PlayerPosition.z);
            writer.Write(saveData.EntityUuids.Length);
            for (int i = 0; i < SaveData.EntityUuids.Length; ++i)
            {
                writer.Write(SaveData.EntityUuids[i]);
                var position = SaveData.EntityPositions[i];
                writer.Write(position.x);
                writer.Write(position.y);
                writer.Write(position.z);
            }
        }

        Debug.Log($"Saved Binary to {fileFullPath}");
    }

    public void LoadBinary(string fileName, SaveData saveData)
    {
        var fileFullPath = $"{_saveFolderPath}/{fileName}";
        using (BinaryReader reader = new BinaryReader(File.Open(fileFullPath, FileMode.Open)))
        {
            saveData.Version = reader.ReadInt32();
            saveData.PlayerHealth = reader.ReadInt32();
            saveData.PlayerPosition = new Vector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
            var entityCount = reader.ReadInt32();
            saveData.EntityUuids = new string[entityCount];
            saveData.EntityPositions = new Vector3[entityCount];
            for (int i = 0; i < entityCount; ++i)
            {
                var entityUuid = reader.ReadString();
                var entityPosition = new Vector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
                var entityDescriptor = EntityConfig.FindByUuid(entityUuid);
                Instantiate(entityDescriptor.Prefab, entityPosition, Quaternion.identity);
                saveData.EntityUuids[i] = entityUuid;
                saveData.EntityPositions[i] = entityPosition;
            }
        }

        Debug.Log($"Loaded Binary from {fileFullPath}");
    }

    public void SaveJson(string fileName, SaveData saveData)
    {
        var fileFullPath = $"{_saveFolderPath}/{fileName}";
        var jsonString = JsonUtility.ToJson(saveData);
        File.WriteAllText(fileFullPath, jsonString);

        Debug.Log($"Saved JSON to {fileFullPath}");
    }

    public void LoadJson(string fileName, SaveData saveData)
    {
        var fileFullPath = $"{_saveFolderPath}/{fileName}";
        var jsonString = File.ReadAllText(fileFullPath);
        JsonUtility.FromJsonOverwrite(jsonString, saveData);

        Debug.Log($"Loaded JSON from {fileFullPath}");
    }
}