using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemValue: MonoBehaviour
{
    public enum ItemType
    {
        Weapon,
        Armor,
        Potions,
        Food
    }
    public ItemType itemType;
    public string wepName;
    public float weaponDmg;
    public float elementDmg;
    public float duration;
    public float wieght;
    public int duplicates;
    public string curOwnerName;
    public string prevOwnerName;
    public List<string> prevOwnersList;
    private void Awake()
    {
        prevOwnerName = prevOwnersList[prevOwnersList.Count-1];
    }
    public void setOwner(string name)
    {
        print(name);
        if (curOwnerName != name)
        {
            if (prevOwnersList[prevOwnersList.Count -1 ] != curOwnerName)
            {
                prevOwnersList.Add(curOwnerName);
            }
            curOwnerName = name;
        }
        prevOwnerName = prevOwnersList[prevOwnersList.Count];
        this.gameObject.SetActive(false);
    }
}
