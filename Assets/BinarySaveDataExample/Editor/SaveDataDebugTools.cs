using UnityEditor;
using UnityEngine;

public class SaveDataDebugTools
{
    [MenuItem("Tools/Save Game (Binary)")]
    static void SaveBinaryGame()
    {
        if (Application.isPlaying)
        {
            var saveManager = GameObject.FindObjectOfType<SaveManager>();
            SaveManager.SaveBinary("savedata01.dat", saveManager.SaveData);
        }
    }

    [MenuItem("Tools/Load Game (Binary)")]
    static void LoadBinaryGame()
    {
        if (Application.isPlaying)
        {
            var saveManager = GameObject.FindObjectOfType<SaveManager>();
            SaveManager.LoadBinary("savedata01.dat", saveManager.SaveData);
        }
    }

    [MenuItem("Tools/Save Game (JSON)")]
    static void SaveJsonGame()
    {
        if (Application.isPlaying)
        {
            var saveManager = GameObject.FindObjectOfType<SaveManager>();
            SaveManager.SaveJson("savedata01.json", saveManager.SaveData);
        }
    }

    [MenuItem("Tools/Load Game (JSON)")]
    static void LoadJsonGame()
    {
        if (Application.isPlaying)
        {
            var saveManager = GameObject.FindObjectOfType<SaveManager>();
            SaveManager.LoadJson("savedata01.json", saveManager.SaveData);
        }
    }
}