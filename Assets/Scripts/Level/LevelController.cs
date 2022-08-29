using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    GameObject level;
    public int levelChildCount;
    LevelManager _levelManager;
    private void Start()
    {
        StartCoroutine(FindLevel());
        _levelManager = FindObjectOfType<LevelManager>();
    }
    private void Update()
    {
        level = GameObject.FindGameObjectWithTag("Level");
        levelChildCount = level.transform.childCount;
        if (levelChildCount == 0)
        {
            _levelManager.nextLevelUI.SetActive(true);
        }
    }
    public IEnumerator FindLevel()
    {
        yield return new WaitForSeconds(0.5f);
    }
}
