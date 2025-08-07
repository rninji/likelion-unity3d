using UnityEngine;

public class SaveService : ISaveService
{
    public void SaveData()
    {
        Debug.Log("SaveData");
    }

    public void LoadData()
    {
        Debug.Log("LoadData");
    }
}