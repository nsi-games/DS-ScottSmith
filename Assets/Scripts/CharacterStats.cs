using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [Header("SPECIAL Skills")]
    public int strength;
    public int perception, endurance, charisma, intelligence, agility, luck;

    [Header("General Stats")]
    public float health;
    public float first;
    public float hunger;
    public float radiation;

    public enum clans
    {
        brotherhoodPfSteel,
        khan,
        caesarsLegion,
        mrHouse,
        boomers,
        ncr,
        independant
    }
    [Header("Allegiance")]
    public clans myClan;
}