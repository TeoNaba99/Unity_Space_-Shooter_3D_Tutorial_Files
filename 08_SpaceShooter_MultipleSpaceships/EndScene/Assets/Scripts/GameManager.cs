﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    public GameObject[] spaceshipPrefabs;
    public Texture2D[] spaceshipTextures;

    public static GameManager Instance;


    private int currentSpaceshipIdx = 0;
    public int CurrentSpaceshipIdx => currentSpaceshipIdx;
    public GameObject currentSpaceship => spaceshipPrefabs[currentSpaceshipIdx];

    /*
    public GameObject currentSpaceship(){
        spaceshipPrefabs[currentSpaceshipIdx];
    }
    */

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

        spaceshipTextures = new Texture2D[spaceshipPrefabs.Length];
        for(int i = 0; i < spaceshipPrefabs.Length; ++i)
        {
            GameObject prefab = spaceshipPrefabs[i];
            Texture2D texture = AssetPreview.GetAssetPreview(prefab);
            spaceshipTextures[i] = texture;
        }

        DontDestroyOnLoad(gameObject);

    }

    public void ChangeCurrentSpaceship(int idx)
    {
        currentSpaceshipIdx = idx;
    }
}
