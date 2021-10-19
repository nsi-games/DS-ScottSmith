using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomisationGet : MonoBehaviour
{
    public Renderer characterRenderer;
    public GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Load();
    }
    void Load()
    {
        SetTexture("Skin", PlayerPrefs.GetInt("SkinIndex"));
        SetTexture("Eyes", PlayerPrefs.GetInt("EyesIndex"));
        SetTexture("Mouth", PlayerPrefs.GetInt("MouthIndex"));
        SetTexture("Hair", PlayerPrefs.GetInt("HairIndex"));
        SetTexture("Clothes", PlayerPrefs.GetInt("ClothesIndex"));
        SetTexture("Armour", PlayerPrefs.GetInt("ArmourIndex"));
    }
    void SetTexture(string type, int index)
    {
        Texture2D texture = null;
        int matIndex = 0;
        Renderer rend = new Renderer();
        switch (type)
        {
            case "Skin":
                texture = Resources.Load("Character/Skin_" + index) as Texture2D;
                matIndex = 1;
                rend = characterRenderer;
                break;
            case "Mouth":
                texture = Resources.Load("Character/Mouth_" + index) as Texture2D;
                matIndex = 2;
                rend = characterRenderer;
                break;
            case "Eyes":
                texture = Resources.Load("Character/Eyes_" + index) as Texture2D;
                matIndex = 3;
                rend = characterRenderer;
                break;
            case "Hair":
                texture = Resources.Load("Character/Hair_" + index) as Texture2D;
                matIndex = 4;
                rend = characterRenderer;
                break;
            case "Clothes":
                texture = Resources.Load("Character/Clothes_" + index) as Texture2D;
                matIndex = 5;
                rend = characterRenderer;
                break;
            case "Armour":
                texture = Resources.Load("Character/Armour_" + index) as Texture2D;
                matIndex = 6;
                rend = characterRenderer;
                break;
        
        }
        Material[] mats = rend.materials;//grab
        mats[matIndex].mainTexture = texture;//change
        rend.materials = mats;//put back
    }
}