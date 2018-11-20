/// <summary>
/// ModifiedStat.cs
/// Nov 7, 2018
/// Joaquim Obispo
/// 
/// This is the base class for all stats that will be modifiable by attributes
/// </summary>

using System.Collections.Generic;               //Generic was added so we can use the List<>

public class ModifiedStat : BStat {
    private List<ModifyingAttribute> _mods;
    private int _modValue;

    /// <summary>
    /// Initializes a new instance fo the <see cref="ModifiedStat"/> class.
    /// </summary>
    public ModifiedStat()
    {
        _mods = new List<ModifyingAttribute>();
        _modValue = 0;
    }
    /// <summary>
    /// Add a ModifyingAttribute to our list of mods for this ModifiedStat
    /// </summary>
    /// <param name="mod">
    /// Mod.
    /// </param>
    public void AddModifier( ModifyingAttribute mod)
    {
        _mods.Add(mod);
    }
    /// <summary>
    /// Reset _modValue to 0.
    /// Check to see if we have at least one ModifyingAttribute in our list of mods.
    /// If we do then interate through the list nd add the AdjustedBaseValue * ratio to our modValue.
    /// </summary>
    private void CalculateModValue()
    {
        _modValue = 0;

        if (_mods.Count > 0)
        {
            foreach(ModifyingAttribute att in _mods)
                _modValue += (int)(att.attribute.AdjustedBaseValue * att.ratio);
        }
    }
    /// <summary>
    /// This function is overriding the AdjustedBaseValue in the BStat class.
    /// Calculate the AdjustedBaseValue from the BaseValue + BuffValue + _modValue
    /// </summary>
    /// <value>
    /// The adjusted base value.
    /// </value>
    public new int AdjustedBaseValue
    {
        get { return BaseValue + EnchValue + _modValue; }
    }
    /// <summary>
    /// Update this instance.
    /// </summary>
    public void Update()
    {
        CalculateModValue();
    }

    public string GetModifyingAttributesString()
    {
        string temp = "";

        UnityEngine.Debug.Log(_mods.Count);

        for (int i = 0; i < _mods.Count; i++)
        {
            temp += _mods[i].attribute.Name;
            temp += "_";
            temp += _mods[i].ratio;

            if (i < _mods.Count - 1)
            {
                temp += "|";
            }


        }
        UnityEngine.Debug.Log(temp);
        return temp;
    }
}

/// <summary>
/// A structure that will hold an Attribute and a ratio that will be added as a modifying attribute to our ModifiedStats
/// </summary>
public struct ModifyingAttribute
{
    public Attribute attribute;         //the attrubute to eb used as a modifier
    public float ratio;                 //the precent of the attributes AdjustedBaseValue that will be applied to the ModifiedStat.
    /// <summary>
    /// Initializes a new instance of the <see cref="ModifyingAttribute"/> struct.
    /// </summary>
    /// <param name="att">
    /// Att. the attribute to be used
    /// </param>
    /// <param name="rat">
    /// Rat. the ratio to use
    /// </param>
    public ModifyingAttribute(Attribute att, float rat)
    {
        attribute = att;
        ratio = rat;
    }
}