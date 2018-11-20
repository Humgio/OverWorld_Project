using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameSettings : MonoBehaviour {
    public const string PLAYER_SPAWN_POINT = "Player Spawn Point";      //This is the name of the gameobject that the player will spawn on at the start of the level.
    
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    public void SaveCharacterData()
    {
        GameObject pc = GameObject.Find("pc");
        PlayerCharacter pcClass = pc.GetComponent<PlayerCharacter>();

        //PlayerPrefs.DeleteAll();

        PlayerPrefs.SetString("Player Name",pcClass.Name);
        for (int i = 0; i < Enum.GetValues(typeof(AttributeName)).Length; i++)
        {
            PlayerPrefs.SetInt(((AttributeName)i).ToString()+" - Base Value",pcClass.GetPrimaryAttribute(i).BaseValue);
            if (i < Enum.GetValues(typeof(AttributeName)).Length - 2)
            {
            PlayerPrefs.SetInt(((AttributeName)i).ToString()+" - Exp To Level", pcClass.GetPrimaryAttribute(i).ExpToLevel);
            }
        }
        for (int i = 0; i < Enum.GetValues(typeof(VitalName)).Length; i++)
        {
            PlayerPrefs.SetInt(((VitalName)i).ToString() + " - Base Value", pcClass.GetVital(i).BaseValue);
            PlayerPrefs.SetInt(((VitalName)i).ToString() + " - Exp To Level", pcClass.GetVital(i).ExpToLevel);
            PlayerPrefs.SetInt(((VitalName)i).ToString() + " - Current Value", pcClass.GetVital(i).CurValue);

//            PlayerPrefs.SetString(((VitalName)i).ToString() + " - Mods", pcClass.GetVital(i).GetModifyingAttributesString());
        }
        for (int i = 0; i < Enum.GetValues(typeof(SkillName)).Length; i++)
        {
            PlayerPrefs.SetInt(((SkillName)i).ToString() + " - Base Value", pcClass.GetSkill(i).BaseValue);
            PlayerPrefs.SetInt(((SkillName)i).ToString() + " - Exp To Level", pcClass.GetSkill(i).ExpToLevel);

//            PlayerPrefs.SetString(((SkillName)i).ToString() + " - Mods",pcClass.GetSkill(i).GetModifyingAttributesString());
        }
    }
    public void LoadCharacterData()
    {
        GameObject pc = GameObject.Find("pc");
        PlayerCharacter pcClass = pc.GetComponent<PlayerCharacter>();

        //Setting the pc name
        pcClass.Name = PlayerPrefs.GetString("Player Name", "Name Me");

        Debug.Log(pcClass.name);

        for (int i = 0; i < Enum.GetValues(typeof(AttributeName)).Length; i++)
        {
            pcClass.GetPrimaryAttribute(i).BaseValue = PlayerPrefs.GetInt(((AttributeName)i).ToString() + " - Base Value",0);
            if (i < Enum.GetValues(typeof(AttributeName)).Length - 2)
            {
                pcClass.GetPrimaryAttribute(i).ExpToLevel = PlayerPrefs.GetInt(((AttributeName)i).ToString() + " - Exp To Level",Attribute.STARTING_EXP_COST);
            }
        }
        for (int i = 0; i < Enum.GetValues(typeof(VitalName)).Length; i++)
        {
            pcClass.GetVital(i).BaseValue = PlayerPrefs.GetInt(((VitalName)i).ToString() + " - Base Value", 0);
            pcClass.GetVital(i).ExpToLevel = PlayerPrefs.GetInt(((VitalName)i).ToString() + " - Exp To Level", 0);

            pcClass.GetVital(i).Update();

            pcClass.GetVital(i).CurValue = PlayerPrefs.GetInt(((VitalName)i).ToString() + " - Cur Value",1);
//            PlayerPrefs.GetString(((VitalName)i).ToString() + " - Mods", pcClass.GetVital(i).GetModifyingAttributesString());
        }
        for (int i = 0; i < Enum.GetValues(typeof(SkillName)).Length; i++)
        {
            pcClass.GetSkill(i).BaseValue = PlayerPrefs.GetInt(((SkillName)i).ToString() + " - Base Value", 0);
            pcClass.GetSkill(i).ExpToLevel = PlayerPrefs.GetInt(((SkillName)i).ToString() + " - Exp To Level", 0);
        }
    }
}
