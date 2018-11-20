/// <summary>
/// BStat.cs
/// Joaquim Obispo
/// Nov 7, 2018
/// 
/// This is the base class for a stats in game.
/// </summary>
/// 
public class BStat
{
    public const int STARTING_EXP_COST = 100;   //publicly accesable value for all base stats to start at

    private int _baseValue;                     //the base value of this stat
    private int _enchValue;                     //the amount of enchant to this stat
    private int _expToLevel;                    //the total amount of experience needed to raise this skill
    private float _levelModifier;               //the modifier applied ot the experience needed to raise the skill
/// <summary>
/// Initializes a new instance of the <see cref="BStat"/> class.
/// </summary>
    public BStat()
    {
        _baseValue = 0;
        _enchValue = 0;
        _expToLevel = STARTING_EXP_COST;
        _levelModifier = 1.1f;

        return;
    }
    #region Basic Setters and Getters
    /// <summary>
    /// Gets or sets the _baseValue
    /// </summary>
    /// <value>
    /// The _baseValue
    /// </value>
    public int BaseValue
    {
        get { return _baseValue; }
        set { _baseValue = value; }
    }
    /// <summary>
    /// Gets or sets the _enchValue
    /// </summary>
    /// <value>
    /// The _enchValue
    /// </value>
    public int EnchValue
    {
        get { return _enchValue; }
        set { _enchValue = value; }
    }
    /// <summary>
    /// Gets or sets the _expToLevel
    /// </summary>
    /// <value>
    /// The _expToLevel value
    /// </value>
    public int ExpToLevel
    {
        get { return _expToLevel; }
        set { _expToLevel = value; }
    }
    /// <summary>
    /// Gets or sets the _levelModifier
    /// </summary>
    /// <value>
    /// The _levelModifier value
    /// </value>
    public float LevelModifier
    {
        get { return _levelModifier; }
        set { _levelModifier = value; }
    }
    #endregion
    /// <summary>
    /// Calculates the _expToLevel
    /// </summary>
    /// <value>
    /// The _expToLevel value
    /// </value>
    private int CalculateExpToLevel()
    {
        return (int)(_expToLevel * _levelModifier);
    }
    /// <summary>
    /// Assign the new value to _expToLevel and then increase the _baseValue by one.
    /// </summary>
    public void LevelUp()
    {
        _expToLevel = CalculateExpToLevel();
        _baseValue++;
    }
    /// <summary>
    /// Recalculate the adjusted base value and return it
    /// </summary>
    /// <value>
    /// The AdjustedBaseValue
    /// </value>
    public int AdjustedBaseValue
    {
        get { return _baseValue + _enchValue; }
    }
}
