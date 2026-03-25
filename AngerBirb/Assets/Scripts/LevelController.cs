using System;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public string _next;
    Monster[] _monsters;
    void OnEnable()
    {
        _monsters = FindObjectsByType<Monster>(FindObjectsSortMode.None);
    }
    void Update()
    {
        if(MonsterAreDead())
            GoToNextLevel();
    }
    bool MonsterAreDead()
    {
        foreach(var monster in _monsters)
        {
            if(monster.gameObject.activeSelf)
                return false;
        }
        return true;
    }
    void GoToNextLevel()
    {
        Debug.Log("level Compleate");
        SceneManager.LoadScene(_next);
    }
}
