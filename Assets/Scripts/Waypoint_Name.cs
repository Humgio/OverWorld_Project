using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint_Name : MonoBehaviour {
    public Transform[] wayPoints;
    private PlayerCharacter _toon;
    public string[] names;
    private string playerName = null;
    public int n;
    public float targetTime = 2.0f;
    public float targetTime2 = 2.0f;
    private int currentPos = 0;
    private int tempPos;
    private int nextPos = 1;
    public float speed;
    private float WPraduis = 1;
    public bool nameResponse = false;
    public void Start()
    {
        
    }
    public void Update()
    {

        //When the player responds to a name the person will go to his crib to do somthing
        if (nameResponse != true)
        {
            if (Vector3.Distance(wayPoints[currentPos].transform.position, transform.position) < WPraduis)
            {
                targetTime -= Time.deltaTime;
                if (targetTime <= 0.0f)
                {
                    UpdateWaypoint();
                }
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, wayPoints[currentPos].transform.position, Time.deltaTime * speed);
        GetNameForPlayer();
        return;
    }
    void UpdateWaypoint()
    {
        tempPos = Random.Range(1, wayPoints.Length);
        if (tempPos != currentPos)
        {
            currentPos = tempPos;
        }
        else
        {
            if (currentPos >= names.Length)
            {
                currentPos--;
            }else
            currentPos++;
        }
        targetTime = 2.0f;
    }
    public void GetNameForPlayer()
    {
        targetTime2 -= Time.deltaTime;
        if (targetTime2 <= 0.0f && nameResponse == false)
        {
            n++;
            if (n >= names.Length)
            {
                n = 0;
            }
            print(names[n]);
            targetTime2 = 2.0f;
        }
        else if (nameResponse == true)
        {
            currentPos = 6;
            if (Vector3.Distance(wayPoints[currentPos].transform.position, transform.position) < WPraduis & playerName == null)
            {
                //Give that character its name
                playerName = names[n];
                print("Your name is: " + playerName);
                //Give the player interaction options to respond
            }
        }
        if (playerName == null && nameResponse == true)
        {
            playerName = names[n];
            PlayerPrefs.SetString("Player Name", playerName);
        }
    }
}
