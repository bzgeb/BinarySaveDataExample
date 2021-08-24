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
            saveManager.SaveData.SaveBinary("savedata01.dat");
        }
    }

    [MenuItem("Tools/Load Game (Binary)")]
    static void LoadBinaryGame()
    {
        if (Application.isPlaying)
        {
            var saveManager = GameObject.FindObjectOfType<SaveManager>();
            saveManager.SaveData.LoadBinary("savedata01.dat");
        }
    }

    [MenuItem("Tools/Save Game (JSON)")]
    static void SaveJsonGame()
    {
        if (Application.isPlaying)
        {
            var saveManager = GameObject.FindObjectOfType<SaveManager>();
            saveManager.SaveData.SaveJson("savedata01.json");
        }
    }

    [MenuItem("Tools/Load Game (JSON)")]
    static void LoadJsonGame()
    {
        if (Application.isPlaying)
        {
            var saveManager = GameObject.FindObjectOfType<SaveManager>();
            saveManager.SaveData.LoadJson("savedata01.json");
        }
    }
}