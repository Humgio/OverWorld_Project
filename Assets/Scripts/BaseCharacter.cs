using UnityEngine;
using System.Collections;
using System;


public class BaseCharacter : MonoBehaviour {
    private string _name;
    private int _level;
    private uint _freeExp;

    private Attribute[] _primaryAttributes;
    private Vital[] _vital;
    private Skill[] _skill;
    private InteractionSkills[] _inter;

    public void Awake()
    {
        _name = string.Empty;
        _level = 0;
        _freeExp = 0;

        _primaryAttributes = new Attribute[Enum.GetValues(typeof(AttributeName)).Length];
        _vital = new Vital[Enum.GetValues(typeof(VitalName)).Length];
        _skill = new Skill[Enum.GetValues(typeof(SkillName)).Length];

        SetupPrimaryAttributes();
        SetupVitals();
        SetupSkills();
    }
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    public int Level
    {
        get { return _level; }
        set { _level = value;}
    }
    public uint FreeExp
    {
        get { return _freeExp; }
        set { _freeExp = value; }
    }
    public void AddExp(uint exp)
    {
        _freeExp += exp;
        CalculateLevel();
    }

    public void CalculateLevel()
    {
    }
    private void SetupPrimaryAttributes()
    {
        for (int cnt = 0; cnt < _primaryAttributes.Length; cnt++)
        {
            _primaryAttributes[cnt] = new Attribute();
            _primaryAttributes[cnt].Name = ((AttributeName)cnt).ToString();
        }
    }
    private void SetupVitals()
    {
        for (int cnt = 0; cnt < _vital.Length; cnt++)
        {
            _vital[cnt] = new Vital();
        }
        SetupVitalModifiers();
    }
    private void SetupSkills()
    {
        for (int cnt = 0; cnt < _skill.Length; cnt++)
        {
            _skill[cnt] = new Skill();
        }
        SetupSkillModifiers();
    }
    private void SetupInteractionSkill()
    {
        for (int cnt = 0; cnt < _inter.Length; cnt++)
        {
            _inter[cnt] = new InteractionSkills();
        }
        SetupInteraction();
    }

    public Attribute GetPrimaryAttribute(int index)
    {
        return _primaryAttributes[index];
    }
    public Vital GetVital (int index)
    {
        return _vital[index];
    }
    public Skill GetSkill(int index)
    {
        return _skill[index];
    }
    private void SetupVitalModifiers()
    {
        //Health
        GetVital((int)VitalName.Health).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Constitution),.5f));
        //Mana
        GetVital((int)VitalName.Mana).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.WillPower), 1f));
        //Stamina
        GetVital((int)VitalName.Stamina).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Constitution), 1f));
    }
    private void SetupSkillModifiers()
    {
        //Melee Offence
        GetSkill((int)SkillName.Melee_Offence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Might), .33f));
        GetSkill((int)SkillName.Melee_Offence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Agility), .33f));
        //Melee Defence
        GetSkill((int)SkillName.Melee_Defence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Speed), .33f));
        GetSkill((int)SkillName.Melee_Defence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Constitution), .33f));
        //Magic Offence
        GetSkill((int)SkillName.Magic_Offence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Concentration), .33f));
        GetSkill((int)SkillName.Magic_Defence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.WillPower), .33f));
        //Magic Defence
        GetSkill((int)SkillName.Magic_Defence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Concentration), .33f));
        GetSkill((int)SkillName.Magic_Defence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.WillPower), .33f));
        //Ranged Offence
        GetSkill((int)SkillName.Range_Offence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Speed), .33f));
        GetSkill((int)SkillName.Range_Offence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Concentration), .33f));
        //Ranged Defence
        GetSkill((int)SkillName.Range_Defence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Speed), .33f));
        GetSkill((int)SkillName.Range_Defence).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Agility), .33f));
    }
    private void SetupInteraction()
    {
        GetSkill((int)InteractionName.Cry).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Might), .33f));
        GetSkill((int)InteractionName.Laugh).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Intellect), .33f));

        GetSkill((int)InteractionName.Stare).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Concentration), .33f));
        GetSkill((int)InteractionName.Fart).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Speed), .33f));

        GetSkill((int)InteractionName.Scream).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Might), .33f));
        GetSkill((int)InteractionName.Brabble).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Intellect), .33f));

        GetSkill((int)InteractionName.Talk).AddModifier(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Intellect), .33f));
    }
    public void StatUpdate()
    {
        for (int cnt = 0; cnt < _vital.Length; cnt++)
        {
            _vital[cnt].Update();
        }
        for (int cnt = 0; cnt < _skill.Length; cnt++)
        {
            _skill[cnt].Update();
        }
    }
}
