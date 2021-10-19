using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomisationSet : MonoBehaviour
{
    [Header("Character Name")]
    public string characterName;
    [Header("Character Class")]
    public CharacterClass characterClass = CharacterClass.Barbarian;
    public string[] selectedClass = new string[8];
    public int selectClassIndex = 0;
    [Header("Dropdown Menu")]
    public bool showDropdown;
    public Vector2 scrollPosClass;
    public string classButton = "";
    public int statPoints = 10;
    [Header("Texture List")]
    public List<Texture2D> skin = new List<Texture2D>();
    public List<Texture2D> eyes = new List<Texture2D>();
    public List<Texture2D> hair = new List<Texture2D>();
    public List<Texture2D> mouth = new List<Texture2D>();
    public List<Texture2D> armour = new List<Texture2D>();
    public List<Texture2D> clothes = new List<Texture2D>();
    [Header("current textre Index")]
    public int skinIndex;
    public int eyesIndex, mouthIndex, hairIndex, armourIndex, clothesIndex;
    [Header("Max amount of textures per type")]
    public int skinMax;
    public int eyesMax, mouthMax, hairMax, armourMax, clothesMax;
    [Header("Renderer")]
    public Renderer characterRenderer;
    [Header("Mat Name")]
    public string[] matName = new string[6];
    [System.Serializable]
    public struct Stats
    {
        public string baseStatsName;
        public int baseStat;
        public int tempStats;
    };
    public Stats[] characterStats = new Stats[6];
    public string[] materialNames = new string[7] { "Skin", "Mouth", "Eyes", "Hair", "Clothes", "Armour", "Helm" };
    public bool classDrop;
    public string classDropDisplay = "Select Class";
    private void Start()
    {
        matName = new string[]
        {"Skin","Eye","Mouth","Hair","Clothes","Armour",};
        selectedClass = new string[] { "Barbarian", "Bad", "Druid", "Monk", "Paladin", "Ranger", "Sorcerer", "Warlock" };

        selectedClass = new string[] { "Barbarian", "Bard", "Druid", "Monk", "Paladin", "Ranger", "Sorcerer", "Warlock" };
        for (int i = 0; i < skinMax; i++)
        {
            Texture2D tempTexture = Resources.Load("Character/Skin_" + i) as Texture2D;
            skin.Add(tempTexture);
        }
        for (int i = 0; i < eyesMax; i++)
        {
            Texture2D tempTexture = Resources.Load("Character/Eyes_" + i) as Texture2D;
            eyes.Add(tempTexture);
        }
        for (int i = 0; i < mouthMax; i++)
        {
            Texture2D tempTexture = Resources.Load("Character/Mouth_" + i) as Texture2D;
            mouth.Add(tempTexture);
        }
        for (int i = 0; i < hairMax; i++)
        {
            Texture2D tempTexture = Resources.Load("Character/Hair_" + i) as Texture2D;
            hair.Add(tempTexture);
        }
        for (int i = 0; i < clothesMax; i++)
        {
            Texture2D tempTexture = Resources.Load("Character/Clothes_" + i) as Texture2D;
            clothes.Add(tempTexture);
        }
        for (int i = 0; i < armourMax; i++)
        {
            Texture2D tempTexture = Resources.Load("Character/Armour_" + i) as Texture2D;
            armour.Add(tempTexture);
        }
    }

    private void OnGUI()
    {
        //create the floats scrW and scrH that govern our 16:9 ratio
        Vector2 scr = new Vector2(Screen.width / 16, Screen.height / 9);
        //create a loop that will help with shuffling your GUI elements under eachother
        #region Buttons and Display for Custom
        for (int i = 0; i < materialNames.Length; i++)
        {
            //GUI button on the left of the screen with the contence <
            if (GUI.Button(new Rect(0.25f * scr.x, 2.5f * scr.y + (i * 0.5f * scr.y), 0.5f * scr.x, 0.5f * scr.y), "<"))
            {
                //when pressed the button will run SetTexture and grab the Material and move the texture index in the direction  -1
                SetTexture(materialNames[i], -1);
            }
            //GUI Box or Lable on the left of the screen with the contence 
            GUI.Box(new Rect(0.75f * scr.x, 2.5f * scr.y + (i * 0.5f * scr.y), 1.5f * scr.x, 0.5f * scr.y), materialNames[i]);

            //GUI button on the left of the screen with the contence >
            if (GUI.Button(new Rect(2.25f * scr.x, 2.5f * scr.y + (i * 0.5f * scr.y), 0.5f * scr.x, 0.5f * scr.y), ">"))
            {
                //when pressed the button will run SetTexture and grab the  Material and move the texture index in the direction  1
                SetTexture(materialNames[i], 1);
            }
            //move down the screen with the int using ++ each grouping of GUI elements are moved using this - happens auto coz loop
        }
        #endregion
        #region Random Reset
        //create 2 buttons one Random and one Reset
        //Random will feed a random amount to the direction 
        if (GUI.Button(new Rect(0.25f * scr.x, 2.5f * scr.y + materialNames.Length * (0.5f * scr.y), 1.25f * scr.x, 0.5f * scr.y), "Random"))
        {
            skinIndex = Random.Range(0, skinMax);
            hairIndex = Random.Range(0, hairMax);
            mouthIndex = Random.Range(0, mouthMax);
            eyesIndex = Random.Range(0, eyesMax);
            clothesIndex = Random.Range(0, clothesMax);
            armourIndex = Random.Range(0, armourMax);
            SetTexture("Skin", 0);
            SetTexture("Hair", 0);
            SetTexture("Mouth", 0);
            SetTexture("Eyes", 0);
            SetTexture("Clothes", 0);
            SetTexture("Armour", 0);
            SetTexture("Helm", 0);
        }
        //reset will set all to 0 both use SetTexture
        if (GUI.Button(new Rect(1.5f * scr.x, 2.5f * scr.y + materialNames.Length * (0.5f * scr.y), 1.25f * scr.x, 0.5f * scr.y), "Reset"))
        {
            //index = 0 is resetting the index value we are using and incrementing with so we are forcing everything to update and the index values to reset
            SetTexture("Skin", skinIndex = 0);
            SetTexture("Hair", hairIndex = 0);
            SetTexture("Mouth", mouthIndex = 0);
            SetTexture("Eyes", eyesIndex = 0);
            SetTexture("Clothes", clothesIndex = 0);
            SetTexture("Armour", armourIndex = 0);
        }
        #endregion
        #region Character Name
        //name of our character equals a GUI TextField that holds our character name and limit of characters
        //move down the screen or place somewhere else
        characterName = GUI.TextField(new Rect(0.25f * scr.x, 2.5f * scr.y + (materialNames.Length + 1) * (0.5f * scr.y), 2.5f * scr.x, 0.5f * scr.y), characterName, 32);


        #endregion
        #region Select Class
        //button for toggling dropdown
        if (GUI.Button(new Rect(12.75f * scr.x, 2.5f * scr.y, 2 * scr.x, 0.5f * scr.y), classDropDisplay))
        {
            classDrop = !classDrop;
        }
        //if dropdown - scroll view that displays our classes as selectable buttons
        if (classDrop)
        {
            float listSize = System.Enum.GetNames(typeof(CharacterClass)).Length;
            scrollPosClass = GUI.BeginScrollView(new Rect(12.75f * scr.x, 3f * scr.y, 2 * scr.x, 4f * scr.y), scrollPosClass, new Rect(0, 0, 0, listSize * 0.5f * scr.y));
            GUI.Box(new Rect(0, 0, 1.75f * scr.x, listSize * 0.5f * scr.y), "");
            for (int i = 0; i < listSize; i++)
            {
                if (GUI.Button(new Rect(0, 0.5f * scr.y * i, 1.75f * scr.x, 0.5f * scr.y), System.Enum.GetNames(typeof(CharacterClass))[i]))
                {
                    ChooseClass(i);
                    classDropDisplay = System.Enum.GetNames(typeof(CharacterClass))[i];
                    classDrop = false;
                }
            }
            GUI.EndScrollView();
        }
        #endregion      
        #region Add Points
        // stats - display stats

        //Box for points to spend
        GUI.Box(new Rect(12.75f * scr.x, 3.5f * scr.y, 2 * scr.x, 0.5f * scr.y), "Points: " + statPoints);
        // + and - buttons on either side of a box/label
        for (int i = 0; i < characterStats.Length; i++)
        {
            //-
            //if our points are below 6 && the level temp value is above 0
            if (statPoints < 6 && characterStats[i].tempStats > 0)
            {
                if (GUI.Button(new Rect(12.25f * scr.x, 4 * scr.y + (i * 0.5f * scr.y), 0.5f * scr.x, 0.5f * scr.y), "-"))
                {
                    //remove points from level temp and add points to bonus stats
                    statPoints++;
                    characterStats[i].tempStats--;
                }
            }
            //type
            //display total stats and stat name
            GUI.Box(new Rect(12.75f * scr.x, 4 * scr.y + (i * 0.5f * scr.y), 2f * scr.x, 0.5f * scr.y), characterStats[i].baseStatsName + ": " + (characterStats[i].baseStat + characterStats[i].tempStats));
            //+
            //if bonus stats are above 0
            if (statPoints > 0)
            {
                if (GUI.Button(new Rect(14.75f * scr.x, 4 * scr.y + (i * 0.5f * scr.y), 0.5f * scr.x, 0.5f * scr.y), "+"))
                {
                    //remove points from bonus stats and add points to level temp
                    statPoints--;
                    characterStats[i].tempStats++;
                }
            }
        }

        #endregion
        #region Save & Play

        //GUI Button called Save and Play 
        if (GUI.Button(new Rect(7f * scr.x, 7.5f * scr.y, 2f * scr.x, 0.5f * scr.y), "Save and Play"))
        {
            //this button will run the save function 
            SaveCharacter();
            //and also load into the game level
            SceneManager.LoadScene(2);
        }

        #endregion
    }

    void ChooseClass(int classIndex)
    {
        //15, 14, 13, 12, 10, 8
        switch (classIndex)
        {
            case 0:
                characterStats[0].baseStat = 13;//str
                characterStats[1].baseStat = 11;//dex
                characterStats[2].baseStat = 12;//con
                characterStats[3].baseStat = 10;//int
                characterStats[4].baseStat = 6;//wis
                characterStats[5].baseStat = 8;//char
                characterClass = CharacterClass.Barbarian;
                break;
            case 1:
                characterStats[0].baseStat = 6;//str
                characterStats[1].baseStat = 10;//dex
                characterStats[2].baseStat = 8;//con
                characterStats[3].baseStat = 12;//int
                characterStats[4].baseStat = 11;//wis
                characterStats[5].baseStat = 13;//char
                characterClass = CharacterClass.Bard;
                break;
            case 2:
                characterStats[0].baseStat = 10;//str
                characterStats[1].baseStat = 6;//dex
                characterStats[2].baseStat = 11;//con
                characterStats[3].baseStat = 8;//int
                characterStats[4].baseStat = 13;//wis
                characterStats[5].baseStat = 12;//char
                characterClass = CharacterClass.Cleric;
                break;
            case 3:
                characterStats[0].baseStat = 6;//str
                characterStats[1].baseStat = 12;//dex
                characterStats[2].baseStat = 8;//con
                characterStats[3].baseStat = 11;//int
                characterStats[4].baseStat = 13;//wis
                characterStats[5].baseStat = 10;//char
                characterClass = CharacterClass.Druid;
                break;
            case 4:
                characterStats[0].baseStat = 13;//str
                characterStats[1].baseStat = 11;//dex
                characterStats[2].baseStat = 12;//con
                characterStats[3].baseStat = 8;//int
                characterStats[4].baseStat = 6;//wis
                characterStats[5].baseStat = 10;//char
                characterClass = CharacterClass.Fighter;
                break;
            case 5:
                characterStats[0].baseStat = 10;//str
                characterStats[1].baseStat = 13;//dex
                characterStats[2].baseStat = 8;//con
                characterStats[3].baseStat = 11;//int
                characterStats[4].baseStat = 12;//wis
                characterStats[5].baseStat = 6;//char
                characterClass = CharacterClass.Monk;
                break;
            case 6:
                characterStats[0].baseStat = 12;//str
                characterStats[1].baseStat = 10;//dex
                characterStats[2].baseStat = 11;//con
                characterStats[3].baseStat = 6;//int
                characterStats[4].baseStat = 8;//wis
                characterStats[5].baseStat = 13;//char
                characterClass = CharacterClass.Paladin;
                break;
            case 7:
                characterStats[0].baseStat = 13;//str
                characterStats[1].baseStat = 12;//dex
                characterStats[2].baseStat = 8;//con
                characterStats[3].baseStat = 10;//int
                characterStats[4].baseStat = 11;//wis
                characterStats[5].baseStat = 6;//char
                characterClass = CharacterClass.Ranger;
                break;
            case 8:
                characterStats[0].baseStat = 6;//str
                characterStats[1].baseStat = 13;//dex
                characterStats[2].baseStat = 8;//con
                characterStats[3].baseStat = 10;//int
                characterStats[4].baseStat = 11;//wis
                characterStats[5].baseStat = 12;//char
                characterClass = CharacterClass.Rogue;
                break;
            case 9:
                characterStats[0].baseStat = 6;//str
                characterStats[1].baseStat = 8;//dex
                characterStats[2].baseStat = 13;//con
                characterStats[3].baseStat = 12;//int
                characterStats[4].baseStat = 11;//wis
                characterStats[5].baseStat = 10;//char
                characterClass = CharacterClass.Sorcerer;
                break;
            case 10:
                characterStats[0].baseStat = 8;//str
                characterStats[1].baseStat = 6;//dex
                characterStats[2].baseStat = 12;//con
                characterStats[3].baseStat = 13;//int
                characterStats[4].baseStat = 11;//wis
                characterStats[5].baseStat = 10;//char
                characterClass = CharacterClass.Warlock;
                break;
            case 11:
                characterStats[0].baseStat = 8;//str
                characterStats[1].baseStat = 10;//dex
                characterStats[2].baseStat = 8;//con
                characterStats[3].baseStat = 13;//int
                characterStats[4].baseStat = 12;//wis
                characterStats[5].baseStat = 11;//char
                characterClass = CharacterClass.Wizard;
                break;
        }
    }
    void SaveCharacter()
    {
        //SetInt for skins
        PlayerPrefs.SetInt("SkinIndex", skinIndex);
        PlayerPrefs.SetInt("HairIndex", hairIndex);
        PlayerPrefs.SetInt("MouthIndex", mouthIndex);
        PlayerPrefs.SetInt("EyesIndex", eyesIndex);
        PlayerPrefs.SetInt("ClothesIndex", clothesIndex);
        PlayerPrefs.SetInt("ArmourIndex", armourIndex);
        //SetString CharacterName, class, race
        PlayerPrefs.SetString("CharacterName", characterName);
        PlayerPrefs.SetString("CharacterClass", characterClass.ToString());
        //int loop stats
        for (int i = 0; i < characterStats.Length; i++)
        {
            PlayerPrefs.SetInt(characterStats[i].baseStatsName, (characterStats[i].baseStat + characterStats[i].tempStats));
        }
    }
    void Load()
    {

    }
    void SetTexture(string type, int index)
    {
        Texture2D texture = null;
        int matIndex = 0;
        switch (type)
        {
            case "Skin":
                texture = Resources.Load("Character/Skin_" + index) as Texture2D;
                matIndex = 1;
                break;
            case "Eyes":
                texture = Resources.Load("Character/Eyes_" + index) as Texture2D;
                matIndex = 2;
                break;
            case "Mouth":
                texture = Resources.Load("Character/Mouth_" + index) as Texture2D;
                matIndex = 3;
                break;
            case "Hair":
                texture = Resources.Load("Character/Hair_" + index) as Texture2D;
                matIndex = 4;
                break;
            case "Clothes":
                texture = Resources.Load("Character/Clothes_" + index) as Texture2D;
                matIndex = 5;
                break;
            case "Armour":
                texture = Resources.Load("Character/Armour_" + index) as Texture2D;
                matIndex = 6;
                break;
        }
        Material[] mats = characterRenderer.materials;
        mats[matIndex].mainTexture = texture;
        characterRenderer.materials = mats;
        switch (type)
        {
            //case skin
            case "Skin":
                //skin index equals our index
                skinIndex = index;
                //break
                break;
            case "Mouth":
                mouthIndex = index;
                break;
            case "Eyes":
                eyesIndex = index;
                break;
            case "Hair":
                hairIndex = index;
                break;
            case "Clothes":
                clothesIndex = index;
                break;
            case "Armour":
                armourIndex = index;
                break;
        }
    }
}
public enum CharacterClass
{
    Barbarian,
    Bard,
    Cleric,
    Druid,
    Fighter,
    Monk,
    Paladin,
    Ranger,
    Rogue,
    Sorcerer,
    Warlock,
    Wizard
}

