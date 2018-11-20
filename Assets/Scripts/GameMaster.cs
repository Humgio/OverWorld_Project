using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {
    public GameObject gameSettings;
    public GameObject playerCharacter;
    public GameObject playerSpawnPoint;
    public Camera mainCamera;

    public float zOffset;
    public float yOffset;
    public float xRotOffset;


    private GameObject _pc;
    private PlayerCharacter _pcScript;

    private Vector3 _playerSpawnPointPos;           //this is the plave in 3D space where I want my player to spawn.

	// Use this for initialization
	void Start () {
        _playerSpawnPointPos = new Vector3(-2.4f,-0.5f,1.25f);       // the default position for our Player Spawn Point.
        GameObject go = GameObject.Find("GameSettings.PLAYER_SPAWN_POINT");
        if (go == null)
        {
            Debug.LogWarning("Can not find Player Spawn Point");

            go = new GameObject(GameSettings.PLAYER_SPAWN_POINT);
            Debug.Log("Created Player Spawn Point");

            go.transform.position = _playerSpawnPointPos;
            Debug.Log("Moved Player Spawn Point");
        }
        _pc = Instantiate(playerCharacter, go.transform.position, Quaternion.identity) as GameObject;
        _pc.name = "pc";

        _pcScript = _pc.GetComponent<PlayerCharacter>();

        zOffset = -2.5f;
        yOffset = 2.5f;
        xRotOffset = 22.5f;

        mainCamera.transform.SetParent(_pc.transform);
        //mainCamera.transform.position = new Vector3(_pc.transform.position.x, _pc.transform.position.y + yOffset, _pc.transform.position.z + zOffset);
        //mainCamera.transform.Rotate(xRotOffset, 0, 0);

        LoadCharacter();

    }

    public void LoadCharacter()
    {
        GameObject gs = GameObject.Find("GameSettings");
        if (gs == null)
        {
            GameObject gs1 = Instantiate(gameSettings, Vector3.zero, Quaternion.identity) as GameObject;
            gs1.name = "GameSettings";
        }
        GameSettings gsScript = GameObject.Find("GameSettings").GetComponent<GameSettings>();
        //Loading CharacterData
        gsScript.LoadCharacterData();
    }
}
