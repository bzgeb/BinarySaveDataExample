using System.IO;
using UnityEngine;

[CreateAssetMenu]
public class SaveData : ScriptableObject
{
    string _saveFolderPath;

    public int Version;
    public int PlayerHealth;
    public Vector3 PlayerPosition;

    void OnEnable()
    {
        _saveFolderPath = $"{Application.persistentDataPath}/Saves";
        if (!Directory.Exists(_saveFolderPath))
        {
            Directory.CreateDirectory(_saveFolderPath);
        }

        Version = SaveManager.CurrentSaveVersion;
    }

    public void SaveBinary(string fileName)
    {
        var fileFullPath = $"{_saveFolderPath}/{fileName}";
        using (BinaryWriter writer = new BinaryWriter(File.Open(fileFullPath, FileMode.OpenOrCreate)))
        {
            writer.Write(Version);
            writer.Write(PlayerHealth);
            writer.Write(PlayerPosition.x);
            writer.Write(PlayerPosition.y);
            writer.Write(PlayerPosition.z);
        }

        Debug.Log($"Saved Binary to {fileFullPath}");
    }

    public void LoadBinary(string fileName)
    {
        var fileFullPath = $"{_saveFolderPath}/{fileName}";
        using (BinaryReader reader = new BinaryReader(File.Open(fileFullPath, FileMode.Open)))
        {
            Version = reader.ReadInt32();
            PlayerHealth = reader.ReadInt32();
            PlayerPosition = new Vector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
        }
        
        Debug.Log($"Loaded Binary from {fileFullPath}");
    }

    public void SaveJson(string fileName)
    {
        var fileFullPath = $"{_saveFolderPath}/{fileName}";
        var jsonString = JsonUtility.ToJson(this);
        File.WriteAllText(fileFullPath, jsonString);

        Debug.Log($"Saved JSON to {fileFullPath}");
    }

    public void LoadJson(string fileName)
    {
        var fileFullPath = $"{_saveFolderPath}/{fileName}";
        var jsonString = File.ReadAllText(fileFullPath);
        JsonUtility.FromJsonOverwrite(jsonString, this);
        
        Debug.Log($"Loaded JSON from {fileFullPath}");
    }
}
