using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CharacterGenerator : MonoBehaviour {
    private PlayerCharacter _toon;
    private const int STARTING_POINTS = 100;
    private int latePotential;
    private const int MIN_STARTING_ATTRIBUTE_VALUE = 0;
    public GameObject playerPrefab;

    public void Start()
    {
        GameObject pc = Instantiate(playerPrefab,Vector3.zero,Quaternion.identity) as GameObject;

        pc.name = "pc";
        //_toon = new PlayerCharacter();
        //_toon.Awake();
        latePotential = STARTING_POINTS;
        _toon = pc.GetComponent<PlayerCharacter>();
        GenerateRandomAttributeNumber(STARTING_POINTS);

        GameSettings gsScript = GameObject.Find("GameSettings").GetComponent<GameSettings>();
        //Change the cur value of the vitals to the max modified value of that vital

        gsScript.SaveCharacterData();

        Application.LoadLevel("Level0");
    }
    private void Update()
    {
//        _toon.StatUpdate();
    }
    public void OnGUI()
    {
        //DISPLAY AT CHARACTER CREATION PAGE
        //DisplayName();
        //DisplayAttributes();
        //DisplayVitals();
        //DisplaySkill();
        //DisplayPointsLeft();
        //DisplayCreateButton();
    }
    private void GenerateRandomAttributeNumber(int sp)
    {
        for (int i = 0; i < Enum.GetValues(typeof(AttributeName)).Length; i++)
        {
            //Devides the Starting points by the ammount of attributes. There is a random int number picked from that avarage and set as RandStat.
            int RandStat = UnityEngine.Random.Range(MIN_STARTING_ATTRIBUTE_VALUE, sp / Enum.GetValues(typeof(AttributeName)).Length);
            //Takes the random number away from the starting points pool.
            sp -= RandStat;
            //Assigns the random number to the assigned attribute.
            _toon.GetPrimaryAttribute(i).BaseValue = RandStat;
            //If the attribute is 0 then add 1 point
            if (_toon.GetPrimaryAttribute(i).BaseValue == 0)
            {
                _toon.GetPrimaryAttribute(i).BaseValue += 1;
            }
        }
        latePotential += sp;
    }
    private void DisplayName()
    {
        GUI.Label(new Rect(10, 10, 50, 25), "Name:");
        _toon.Name = GUI.TextField(new Rect(65, 10, 100, 25), _toon.Name);
    }
    private void DisplayAttributes()
    {
        for (int i = 0; i < Enum.GetValues(typeof(AttributeName)).Length; i++)
        {
            GUI.Label(new Rect(10, 40 + (i * 15), 100, 25), ((AttributeName)i).ToString());
            GUI.Label(new Rect(115, 40 + (i * 15), 30, 25), _toon.GetPrimaryAttribute(i).AdjustedBaseValue.ToString());
        }
    }
    private void DisplayVitals()
    {
        for (int i = 0; i < Enum.GetValues(typeof(VitalName)).Length; i++)
        {
            GUI.Label(new Rect(10, 70 + ((i + 8)* 15), 100, 25), ((VitalName)i).ToString());
            GUI.Label(new Rect(115, 70 + ((i + 8) * 15), 30, 25), _toon.GetVital(i).AdjustedBaseValue.ToString());
        }
    }
    private void DisplaySkill()
    {
        for (int i = 0; i < Enum.GetValues(typeof(SkillName)).Length; i++)
        {
            GUI.Label(new Rect(250, 40 + (i * 15), 100, 25), ((SkillName)i).ToString());
            GUI.Label(new Rect(355, 40 + (i * 15), 30, 25), _toon.GetSkill(i).AdjustedBaseValue.ToString());
        }
    }
    private void DisplayPointsLeft()
    {
        GUI.Label(new Rect(250, 10, 100, 25),"Points Left: "+ latePotential);
    }
    private void DisplayCreateButton()
    {
        if(GUI.Button(new Rect(Screen.width/2 - 50,Screen.height/2 + 100,100,25), "Create"))
        {
            GameSettings gsScript = GameObject.Find("GameSettings").GetComponent<GameSettings>();
            //Change the cur value of the vitals to the max modified value of that vital

            gsScript.SaveCharacterData();

            Application.LoadLevel("Level0");
        }
    }
}
