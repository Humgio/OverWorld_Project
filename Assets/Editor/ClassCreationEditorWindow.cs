using UnityEditor;

public class ClassCreationEditorWindow : EditorWindow {
    [MenuItem ("Create new Race / Races")]
    public static void ShowClassCreationWindow()
    {
        var window = GetWindow<ClassCreationEditorWindow>();
    }

    public void OnGUI()
    {
        //Custom GUI
    }
}
