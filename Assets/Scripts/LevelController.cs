using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private string _nextSceneTitle;
    [SerializeField] private int _time;
    [SerializeField] private List<Item> items;
    [SerializeField] private int _goal;
    void Start()
    {
        GameManager.Time = _time;
        GameManager.CurrentGoal = _goal;

        for (int i = 0; i < items.Count; i++)
        {
            for (int j = 0; j < items[i].Count; j++)
            {
                float y = UnityEngine.Random.Range(-4.4f, 1.5f);
                float x = UnityEngine.Random.Range(-8, 8f);
                Instantiate(items[i].Prefab, new Vector3(x, y, 0), new Quaternion(0, 0, 0, 0));
            }
        }
    }

    [Serializable]
    class Item
    {
        public GameObject Prefab;
        public int Count;
    }
}
