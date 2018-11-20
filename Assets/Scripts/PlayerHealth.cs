using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    public int maxHp = 100;
    public int curHp = 100;

    public float healthBarLenght;

    private void Start()
    {
        healthBarLenght = Screen.width / 2;
    }
    private void OnGUI()
    {
        GUI.Box(new Rect(10, 10, Screen.width / 2 / (maxHp / curHp), 20), curHp + "/" + maxHp);
    }
    public void AddjustCurHp(int add)
    {
        curHp += add;
        if (curHp < 0)
        {
            curHp = 0;
        }
        if (curHp > maxHp)
        {
            curHp = maxHp;
        }
        if (maxHp < 1)
        {
            maxHp = 1;
        }

        healthBarLenght = (Screen.width / 2) * (curHp / (float)maxHp);
    }
}
