using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    private string _name;
    private int _value;
    private int _curDur;
    private int _maxDur;

    public Item()
    {
        _name = "Input Name here";
        _value = 0;
        _maxDur = 10;
        _curDur = _maxDur;
    }

    public Item(string name, int value, int maxDur,int curDur)
    {
        _name = name;
        _value = value;
        _maxDur = maxDur;
        _curDur = curDur;
    }
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    public int Value
    {
        get { return _value; }
        set { _value = value; }
    }
    public int maxDur
    {
        get { return _maxDur; }
        set { _maxDur = value; }
    }
    public int curDur
    {
        get { return _curDur; }
        set { _curDur = value; }
    }
}
