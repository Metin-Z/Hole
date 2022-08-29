using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LevelManager : MonoBehaviour
{
    public Level[] Levels;
    private GameObject lastLevelPrefab;
    private GameObject lastLevelController;
    public GameObject nextLevelUI;
    public List<Material> Skybox;
    [HideInInspector] public List<GameObject> levelObjectList;
    public GameObject levelController;
    GameObject ParentObj;
    public void Start()
    {
        InitializeLevel();
    }
    public void InitializeLevel()
    {
        Level currentLevel = GetCurrentLevel();

        levelObjectList.ForEach(x => Destroy(x));
        levelObjectList.Clear();

        if (currentLevel == null)
        {
            Debug.LogError("Level is null.");
            return;
        }

        if (lastLevelPrefab != null)
        {
            Destroy(lastLevelPrefab);    
            Destroy(lastLevelController);    
        }
        lastLevelPrefab = Instantiate(currentLevel.Prefab);
        lastLevelController = Instantiate(currentLevel.LevelController);   
  
    }
    public void NextLevel()
    {
        nextLevelUI.SetActive(false);
        Level currentLevel = GetCurrentLevel();
        PlayerPrefs.SetInt(CommonTypes.LEVEL_DATA_KEY, currentLevel.Id + 1);
        InitializeLevel();
        //RenderSettings.skybox = Skybox[Random.Range(0, 3)];
        PlayerPrefs.SetInt(CommonTypes.LEVEL_FAKE_DATA_KEY, PlayerPrefs.GetInt(CommonTypes.LEVEL_FAKE_DATA_KEY) + 1);
    }
    public Level GetCurrentLevel()
    {
        int currentLevelId = PlayerPrefs.GetInt(CommonTypes.LEVEL_DATA_KEY);
        int totalLevelCount = Levels.Length;
        return Levels.SingleOrDefault(x => x.Id == currentLevelId % totalLevelCount);
    }
}