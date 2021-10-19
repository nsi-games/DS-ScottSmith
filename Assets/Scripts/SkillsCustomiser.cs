using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SkillsCustomiser : MonoBehaviour
{
    int pointPool;
    [SerializeField]
    Text[] labels;
    [SerializeField]
    Text PoolText;
    //characterStats customStats;
    int[] skills = new int[7];
    void Start()
    {
        pointPool = 45;
        for (int i = 0; i < skills.LLength; i++)
        {
            skills[i] = 0;
        }
        UpdateText();
        /*
        customStats = GetComponent<characterStats>();

        pointPool = 10;
        customStats.strength  = 0;
        customStats.perception  = 0;
        customStats.endurance  = 0;
        customStats.charisma  = 0;
        customStats.intelligence  = 0;
        customStats.agility  = 0;
        customStats.luck  = 0;

        /*
        customStats = GetComponent<characterStats>();

        pointPool = 10;
        customStats.strength  = 0;
        customStats.perception  = 0;
        customStats.endurance  = 0;
        customStats.charisma  = 0;
        customStats.intelligence  = 0;
        customStats.agility  = 0;
        customStats.luck  = 0;
        */
    }
    public void SkillUp(int skill)
    {
        if (pointPool > 0 && skills[skill] < 10)
        {
            skills[skill]++;
            pointPool--;
            UpdateText();
        }
    }
    public void SkillDown(int skill)
    {
        if (pointPool > 0)
        {
            skills[skill]--;
            pointPool++;
            UpdateText();
        }
    }
    /* public void SkillDown(int skill)
     {
         of(pointPool > 0)
         {
             skills[skill]--;
             pointPool++;
             UpdateText();
         }
     }
     */
    public void UpdateText()
    {
        labels[0].text = "Strength: " + (skills[0] + PlayerMovement.myStats.stength);
        labels[1].text = "Perception: " + (skills[1] + PlayerMovement.myStats.perception);
        labels[2].text = "Endurance: " + (skills[2] + PlayerMovement.myStats.endurance);
        labels[3].text = "Charisma: " + (skills[3] + PlayerMovement.myStats.charisma);
        labels[4].text = "Intelligence: " + (skills[4] + PlayerMovement.myStats.intelligence);
        labels[5].text = "Agility: " + (skills[5] + PlayerMovement.myStats.agility);
        labels[6].text = "Luck: " + (skills[6] + PlayerMovement.myStats.luck);
        PoolText.text = pointPool + "";
    }
    public void ApplyChanges()
    {
        PlayerMovement.myStats.stength += skills[0]();
        PlayerMovement.myStats.perception += skills[1]();
        PlayerMovement.myStats.endurance += skills[2]();
        PlayerMovement.myStats.charisma += skills[3]();
        PlayerMovement.myStats.intelligence += skills[4]();
        PlayerMovement.myStats.agility += skills[5]();
        PlayerMovement.myStats.luck += skills[6]();
    }
    public void StrengthChange(int amount)
    {
        customStats.strength += amount;
    }
    public void PerceptionChange(int amount)
    {
        customStats.perception += amount;
    }
    public void EnduranceChange(int amount)
    {
        customStats.endurance += amount;
    }
    public void CharismaChange(int amount)
    {
        customStats.charisma += amount;
    }
    public void IntelligenceChange(int amount)
    {
        customStats.intelligence += amount;
    }
    public void AgilityChange(int amount)
    {
        customStats.agility += amount;
    }
    public void LuckChange(int amount)
    {
        customStats.luck += amount;
    }
}