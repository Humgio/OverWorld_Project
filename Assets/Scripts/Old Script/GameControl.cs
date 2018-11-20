using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.IO;

public class GameControl : MonoBehaviour {

    public static GameControl control;
    public string race;
    public float health;
    public float stamina;
    public float mana;
    public float experience;
    public float speed;

    void Awake () {
        if(control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }else if (control != this)
        {
            Destroy(gameObject);
        }
        Load();
	}

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 30), "Race: " + Character.race);
        GUI.Label(new Rect(10, 40, 100, 30), "Health: " + Character.health);
        GUI.Label(new Rect(10, 70, 100, 30), "Stamina: " + Character.stamina);
        GUI.Label(new Rect(10, 100, 100, 30), "Mana: " + Character.mana);
        GUI.Label(new Rect(250, 10, 150, 30), "Experience: " + Character.experience);
    }
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerData data = new PlayerData();

        data.race = race;
        data.health = health;
        data.stamina = stamina;
        data.mana = mana;
        data.experience = experience;
        data.speed = speed;

        bf.Serialize(file, data);
        file.Close();
    }
    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();


            race = data.race;
            health = data.health;
            stamina = data.stamina;
            mana = data.mana;
            experience = data.experience;
            speed = data.speed;
        }
    }
}

[Serializable]
class PlayerData
{
    public string race;
    public float health;
    public float stamina;
    public float mana;
    public float experience;
    public float speed;
}