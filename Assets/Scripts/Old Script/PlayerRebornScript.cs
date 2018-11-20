using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRebornScript : MonoBehaviour {
    public string characterRace;
    public string playerName;
    public GameObject[] characterModel;
    public GameObject player;
    public Color[] charColor;
    public GameObject character;
    public Material setColor;
    private float speed;
    // Use this for initialization

    private void Awake()
    {
        SetCharacterRace(Random.Range(0,4));
    }
    void Start () {
        print(characterRace);
	}
    void SetCharacterRace(int race)
    {
        switch (race)
        {
            case 0:
                Character.race = "Human";
                Character.health = 100;
                Character.stamina = 100;
                Character.mana = 10;
                Character.speed = 0.5f;
                Character.jumpForce = 5f;
                Character.experience = 100;
                setColor.color = charColor[0];
                break;
            case 1:
                Character.race = "Orc";
                Character.health = 150;
                Character.stamina = 50;
                Character.mana = 2;
                Character.speed = 0.5f;
                Character.jumpForce = 2f;
                Character.experience = 100;
                setColor.color = charColor[1];
                break;
            case 2:
                Character.race = "Goblin";
                Character.health = 50;
                Character.stamina = 50;
                Character.mana = 50;
                Character.speed = 0.5f;
                Character.jumpForce = 5f;
                Character.experience = 100;
                setColor.color = charColor[2];
                break;
            case 3:
                Character.race = "Spider";
                Character.health = 80;
                Character.stamina = 150;
                Character.mana = 5;
                Character.speed = 0.5f;
                Character.jumpForce = 10f;
                Character.experience = 100;
                setColor.color = charColor[3];
                break;
        }
        character.name = playerName;
        characterRace = Character.race;
        character = Instantiate(characterModel[race], player.transform.position, Quaternion.identity);
        character.GetComponentInChildren<Renderer>().material.color = charColor[race];
        character.transform.parent = player.transform;
    }
}
