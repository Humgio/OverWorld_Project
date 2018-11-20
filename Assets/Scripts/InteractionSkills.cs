public class InteractionSkills {
    private bool _known;

    public InteractionSkills()
    {
        _known = false;
    }

    public bool Known
    {
        get { return _known; }
        set { _known = value; }
    }
}
public enum InteractionName
{
    Cry,
    Laugh,
    Stare,
    Fart,
    Scream,
    Brabble,
    Talk
}
