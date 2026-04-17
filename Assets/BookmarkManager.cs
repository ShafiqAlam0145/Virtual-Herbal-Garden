using UnityEngine;
using System.Collections.Generic;
using System.IO;

[System.Serializable]
public class FavoritesData
{
    public List<string> favoriteIDs = new List<string>();
}

public class BookmarkManager : MonoBehaviour
{
    private string filePath;
    public FavoritesData myFavorites = new FavoritesData();

    void Awake()
    {
        filePath = Path.Combine(Application.persistentDataPath, "favorites.json");
        LoadFavorites();
    }

    public void ToggleBookmark(string id)
    {
        if (myFavorites.favoriteIDs.Contains(id))
        {
            myFavorites.favoriteIDs.Remove(id);
            Debug.Log("Removed: " + id);
        }
        else
        {
            myFavorites.favoriteIDs.Add(id);
            Debug.Log("Bookmarked: " + id);
        }
        SaveFavorites();
    }

    public void SaveFavorites()
    {
        string json = JsonUtility.ToJson(myFavorites);
        File.WriteAllText(filePath, json);
    }

    public void LoadFavorites()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            myFavorites = JsonUtility.FromJson<FavoritesData>(json);
        }
    }
}