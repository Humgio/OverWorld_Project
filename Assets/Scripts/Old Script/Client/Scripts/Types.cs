using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Types
{
    public static PlayerRec myPlayer = new PlayerRec();
    public static PlayerRec[] players = new PlayerRec[Constants.MAX_PLAYERS - 1];
    public struct PlayerRec
    {
        public GameObject playerPref;
        public int connectionID;
        public int health;

        public vector3 position;
        public vector3 collider;
        public Quaternion rotation;
    }
    public struct vector3
    {
        public float x;
        public float y;
        public float z;

        public vector3(float _x, float _y, float _z)
        {
            x = _x;
            y = _y;
            z = _z;
        }
    }
    public struct Quaternion
    {
        public float x;
        public float y;
        public float z;
        public float w;

        public Quaternion(float _x, float _y, float _z, float _w)
        {
            x = _x;
            y = _y;
            z = _z;
            w = _w;
        }
    }
}
