using UnityEngine;
using System.Collections;
using System;

public class EnchantItem: Item{
    private int[] enchMod;
    private BStat[] stat;

    private Hashtable buffs;

    public EnchantItem()
    {
        buffs = new Hashtable();
    }
    public void BuffItem(Hashtable ht)
    {
        buffs = ht;
    }
    //CHECK THIS ONE!
    public void AddBuff(BaseCharacter stat, int mod)
    {
        try
        {
            buffs.Add(stat.Name,mod);
        }
        catch (Exception e)
        {
            Debug.LogWarning(e.ToString());
        }

    }
    public void RemoveBuff(BaseCharacter stat)
    {
        buffs.Remove(stat.Name);
    }
    public int BuffCount()
    {
        return buffs.Count;
    }
    public Hashtable GetBuffs()
    {
        return buffs;
    }
}
