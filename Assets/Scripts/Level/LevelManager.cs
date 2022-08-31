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
    SliderUI _slider;
    UpgradeSystem _upgrade;
    public void Start()
    {
        InitializeLevel();
        _slider = FindObjectOfType<SliderUI>();
        _upgrade = FindObjectOfType<UpgradeSystem>();
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
        PlayerPrefs.SetInt("ScaleUpControl", 0);
        PlayerPrefs.SetInt("SpeedUpControl", 0);
        PlayerPrefs.SetInt("SkinChangeControl", 0);
        _upgrade.nextLevel = true;
        _upgrade.scaleUpId = 1;
        _upgrade.speedUpId = 1;
        _upgrade.skinChangeId = 1;
        _slider.slideValue = 0;
        _slider.StartCoroutine("SliderMaxValue");
        
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