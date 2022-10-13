using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    /* Properties */
    public static MainManager Instance = null; // Universal MainManager gameObject property.
    public Color TeamColor = Color.gray; // Selected color that'll be applied to the forklifts in the main scene. Starts off with the color gray.

    // This function is called when the script instance is being loaded.
    private void Awake()
    {
        // Does below code only if Instance hasn't been intialized b4 (if it's null).
        if(Instance == null)
        {
            Instance = this; // Sets Instance to be the gameObject it's assigned to.
            DontDestroyOnLoad(gameObject); // Sets Instance to not be destroyed when transitioning between scenes.
            LoadColor();
        }
    }

    // SaveData class. A class that holds the TeamColor data, that'll be saved and loaded in with JSON code.
    [System.Serializable]
    public class SaveData
    {
        public Color TeamColor;
    }

    // Saves TeamColor into a JSON-format file for later sessions.
    public void SaveColor()
    {
        SaveData data = new SaveData();
        data.TeamColor = TeamColor;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    // Loads in JSON file, and sets the current TeamColor to be the JSON file's TeamColor value.
    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            TeamColor = data.TeamColor;
        }
    }
}
