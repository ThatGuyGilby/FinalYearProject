using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NemesisData
{
    readonly string[] NEMESIS_MALE_NAMES = { "Adam", "Ben", "Charlie", "Dan", "Elijah", "Frank", "George" };
    readonly string[] NEMESIS_FEMALE_NAMES = { "Amy", "Beth" };
    readonly string[] NEMESIS_TITLES = { "the Brawler", "Black Blade", "theTark Slayer", "the Blood Drinker", "the Dark One", "the Veiled One", "the Pit Lord" };

    public int PID;
    public int gender;
    public string name;
    public string title;

    public NemesisData()
    {
        PID = Random.Range(-2147483647, 2147483647);
        gender = Random.Range(0, 2);
        if (gender == 0) name = NEMESIS_MALE_NAMES[Random.Range(0, NEMESIS_MALE_NAMES.Length)];
        else name = NEMESIS_FEMALE_NAMES[Random.Range(0, NEMESIS_FEMALE_NAMES.Length)];
        title = NEMESIS_TITLES[Random.Range(0, NEMESIS_TITLES.Length)];
    }
}