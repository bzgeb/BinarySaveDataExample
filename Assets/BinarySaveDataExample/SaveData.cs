using UnityEngine;

[CreateAssetMenu]
public class SaveData : ScriptableObject
{
    public int Version;
    public int PlayerHealth;
    public Vector3 PlayerPosition;

    void OnEnable()
    {
        Version = SaveManager.CurrentSaveVersion;
    }
}
