using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CharacterDevelopment : MonoBehaviour
{
    private PlayerCharacter _toon;
    private float targetTime = 3.0f;
    private void Update()
    {
        //targetTime -= Time.deltaTime;
        //if (targetTime <= 0.0f)
        //{
        //    Timerended();
        //}
    }
    private void Timerended()
    {
        print("The timer ended");
    }
    private void OnGUI()
    {
            CryInteraction();
    }
    private void CryInteraction()
    {
        GameObject pc = GameObject.Find("pc");
        PlayerCharacter _toon = pc.GetComponent<PlayerCharacter>();
        if (!_toon.GetSkill((int)InteractionName.Cry).Known)
        {
            _toon.GetSkill((int)InteractionName.Cry).Known = true;
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2, 100, 50), "Cry"))
        {
            if (_toon.GetPrimaryAttribute((int)AttributeName.Potential).BaseValue > 0)
            {
                _toon.GetPrimaryAttribute((int)AttributeName.Might).BaseValue++;
                _toon.GetPrimaryAttribute((int)AttributeName.Potential).BaseValue--;
                _toon.GetPrimaryAttribute((int)AttributeName.UnlockedPotential).BaseValue++;
            }
        }
    }
    private void LaughInteraction()
    {
        GameObject pc = GameObject.Find("pc");
        PlayerCharacter _toon = pc.GetComponent<PlayerCharacter>();
        _toon.GetSkill((int)InteractionName.Laugh).Known = true;
        if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2, 100, 50), "Laugh"))
        {
            if (_toon.GetPrimaryAttribute((int)AttributeName.Potential).BaseValue > 0)
            {
                _toon.GetPrimaryAttribute((int)AttributeName.Might).BaseValue++;
                _toon.GetPrimaryAttribute((int)AttributeName.Potential).BaseValue--;
                _toon.GetPrimaryAttribute((int)AttributeName.UnlockedPotential).BaseValue++;
            }
        }
    }
    private void FartInteraction()
    {
        GameObject pc = GameObject.Find("pc");
        PlayerCharacter _toon = pc.GetComponent<PlayerCharacter>();
        _toon.GetSkill((int)InteractionName.Fart).Known = true;
        if (GUI.Button(new Rect(Screen.width / 2 + 50, Screen.height / 2, 100, 50), "Fart"))
        {
            if (_toon.GetPrimaryAttribute((int)AttributeName.Potential).BaseValue > 0)
            {
                _toon.GetPrimaryAttribute((int)AttributeName.Might).BaseValue++;
                _toon.GetPrimaryAttribute((int)AttributeName.Potential).BaseValue--;
                _toon.GetPrimaryAttribute((int)AttributeName.UnlockedPotential).BaseValue++;
            }
        }
    }
}
