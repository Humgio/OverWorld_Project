using System.Collections;
using UnityEngine;


public class AdjustScript : MonoBehaviour {

    private void OnGUI()
    {
        if (GUI.Button(new Rect(10, 140, 100, 30), "Health up"))
        {
            Character.health += 10;
        }
        if (GUI.Button(new Rect(10, 180, 100, 30), "Health down"))
        {
            Character.health -= 10;
        }
        if (GUI.Button(new Rect(10, 220, 100, 30), "Stamina up"))
        {
            Character.stamina += 10;
        }
        if (GUI.Button(new Rect(10, 260, 100, 30), "Stamina down"))
        {
            Character.stamina -= 10;
        }
        if (GUI.Button(new Rect(10, 300, 100, 30), "Mana up"))
        {
            Character.mana += 10;
        }
        if (GUI.Button(new Rect(10, 340, 100, 30), "Mana down"))
        {
            Character.mana -= 10;
        }
        if (GUI.Button(new Rect(10, 380, 100, 30), "Experience up"))
        {
            Character.experience += 10;
        }
        if (GUI.Button(new Rect(10, 420, 100, 30), "Experience down"))
        {
            Character.experience -= 10;
        }
        if (GUI.Button(new Rect(10, 470, 100, 30), "Save"))
        {
            GameControl.control.Save();
        }
        if (GUI.Button(new Rect(10, 500, 100, 30), "Load"))
        {
            GameControl.control.Load();
        }
    }
}
