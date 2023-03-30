using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

//Script Class, Important related documentation: https://docs.unity3d.com/Manual/AssetBundlesIntro.html
public class LevelFileManager : MonoBehaviour
{
    public string GameObjectTag = "RoomObject"; // Tag for savable objects
    private GameObject[] assetsToSave;
    [SerializeField] private string[] assetNames;
    [SerializeField] private Vector3[] assetPositions;
    [SerializeField] private string[] assetBundleNames;
    private string filePath;
    private bool Loaded;

  
    // Start is called before the first frame update
    void Start()
    {
        //Save the current Scene to a json file Named after the current SceneName.
        //#TODO Ideally will only be called with user input name in Level Editor, Will need changed.
       //  saveToFile(SceneManager.GetActiveScene().name);
        loadFromFile("SampleScene");
        //Set Load to False
        //Loaded = false;
    }

    // Update is called once per frame
    void Update()
    {
        //update check for if the level has been loaded #TODO Load should be a single call from the active Level scene in Start() but is here for flexibility for testing 
        /*
        if (!Loaded)
        {
            loadFromFile("SampleScene");
            Loaded = true;
        }
        */
    }
    // Populates the arrays with all assets tagged RoomObject in the scene
    public void findRoomObjects()
    {
        //Clear the list if it's not empty
        if (assetsToSave != null)
        {
            for (int i = 0; i < assetsToSave.Length; i++)
            {
                Destroy(assetsToSave[i]);
            }
        }
        //Populate arrays
        assetsToSave = GameObject.FindGameObjectsWithTag(GameObjectTag);
        assetNames = new string[assetsToSave.Length];
        assetPositions = new Vector3[assetsToSave.Length];
        assetBundleNames = new string[assetsToSave.Length];

        for(int j=0; j < assetsToSave.Length; j++)
        {
            assetNames[j] = assetsToSave[j].name;
            assetPositions[j] = assetsToSave[j].transform.position;
            //  assetBundleNames[j] = UnityEditor.AssetDatabase.GetAssetPath(assetsToSave[j]);
            assetBundleNames[j] = "schoolassets";
        }
    }
    
    //Saves the current level to a JSON file
    public void saveToFile(string fileName)
    {
        levelData levelContent = new levelData();
        findRoomObjects();// populates arrays
        //Fills Level content object with array data and then converts to JSON.
        levelContent.setAssetBundleNames(assetBundleNames);
        levelContent.setAssetNames(assetNames);
        levelContent.setAssetPositions(assetPositions);
        string jsonContent = JsonUtility.ToJson(levelContent);// Convert to Json String.
        
        filePath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + fileName + ".json";//Create JSON Filepath off of provided fileName #TODO Check exact save location
        Debug.Log("Saving Data at " + filePath);

        // Write to file
        StreamWriter writer = new StreamWriter(filePath);
        writer.Write(jsonContent);
        writer.Close();
    }

    //Loads the desired level data from a JSON file and populates scene
    public void loadFromFile(string fileName)
    {
        //Load the desired data file
        filePath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + fileName + ".json";//Create JSON Filepath off of provided fileName #TODO Check exact save location
        Debug.Log("Loading Data at " + filePath);
        StreamReader reader = new StreamReader(filePath); 
        string jsonContent = reader.ReadToEnd();
        reader.Close();
        levelData levelContent = JsonUtility.FromJson<levelData>(jsonContent);// extract levelData from json

        //Populate scene based on extracted data
        populateScene(levelContent);
    }

    //Populate the scene from the leveldata provided
    private void populateScene(levelData level)
    {
        //Clear the scene just in case
        foreach(GameObject roomObject in GameObject.FindGameObjectsWithTag(GameObjectTag))
        {
            Destroy(roomObject);
        }

        //Create objects in the room
        List<AssetBundle> activeBundles = new List<AssetBundle>(); // Loaded Bundle reference list
        for (int i = 0; i < level.getAssetBundleNames().Length; i++)
        {
            foreach (AssetBundle loadedBundle in AssetBundle.GetAllLoadedAssetBundles()) // Prevent the same asset bundle from being loaded more than one
            {
                if (!activeBundles.Contains(loadedBundle) && loadedBundle.name != level.getAssetBundleNames()[i]) // Will only load the bundle if it is not already loaded and the level data bundlename does not match.
                {
                    activeBundles.Add(AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, level.getAssetBundleNames()[i])));
                    
                }    
            }

            for (int j = 0; j < activeBundles.Count; j++) {
                if (activeBundles[j].name == level.getAssetBundleNames()[i]) {
                    Instantiate(activeBundles[j].LoadAsset<GameObject>(level.getAssetNames()[i]), level.getAssetPositions()[i], Quaternion.identity);
                }
            }
            
        }
    }
}


// CLASS for saving Level Data
[System.Serializable]
public class levelData
{
    [SerializeField]
    private string[] assetBundleNames;
    [SerializeField]
    private string[] assetNames;
    [SerializeField]
    private Vector3[] assetPositions;

    //set AssetBundleNames Array assets
    public void setAssetBundleNames(string[] bundleNamesToSet)
    {
        assetBundleNames = bundleNamesToSet;
    }
    //set GameObject Array assets
    public string[] getAssetBundleNames()
    {
        return assetBundleNames;
    }
    //set assetNames array
    public void setAssetNames(string[] namesToSet)
    {
        assetNames = namesToSet;
    }
    //get assetNames
    public string[] getAssetNames()
    {
        return assetNames;
    }
    //set assetPositions
    public void setAssetPositions(Vector3[] posToSet)
    {
        assetPositions = posToSet;
    }
    //get assetPositions
    public Vector3[] getAssetPositions()
    {
        return assetPositions;
    }
}

