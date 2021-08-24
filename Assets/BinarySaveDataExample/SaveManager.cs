using System;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public const int CurrentSaveVersion = 1;
    public SaveData SaveData;

    void OnEnable()
    {
        if (SaveData == null)
            SaveData = ScriptableObject.CreateInstance<SaveData>();
    }
}
