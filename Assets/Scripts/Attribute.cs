/// <summary>
/// Attribute.cs
/// Nov 7, 2018
/// Joaquim Obispo
/// 
/// This is the class for all of the character attributes in-game.
/// </summary>
public class Attribute : BStat{
    new public const int STARTING_EXP_COST = 50;    //this is the starting cost for all of our attributes

    private string _name;                           //this is the name of the attribute
    /// <summary>
    /// Initializes a new instance of the <see cref="Attribute"/> class.
    /// </summary>
    public Attribute()
    {
        _name = "";
        ExpToLevel = STARTING_EXP_COST;
        LevelModifier = 1.05f;
    }
    /// <summary>
    /// Gets of sets the _name.
    /// </summary>
    /// <value>
    /// The _name
    /// </value>
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
}
/// <summary>
/// This is a list of all the attributes that we will have in-game for our characters
/// </summary>
public enum AttributeName{
    Might,
    Constitution,
    Intellect,
    Concentration,
    WillPower,
    Dexterity,
    Agility,
    Speed,
    UnlockedPotential,
    Potential
}
