using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Initialization : MonoBehaviour
{

    public List<GameObject> Prefabs;


    void Start()
    {
        foreach (GameObject prefab in Prefabs)
        {
            GameObject go = Instantiate(prefab);
            DontDestroyOnLoad(go);
        }

        SceneManager.LoadScene("Menu");
    }
}
