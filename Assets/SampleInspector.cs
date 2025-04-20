#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Sample)), CanEditMultipleObjects]
public class SampleInspector : CustomOnInspectorGUIBase<Sample>
{
    protected override bool   LayoutTop => false;
    protected override string Title     => "Sample GUI";

    protected override bool OnInspectorGUI(Sample target)
    {
        if (GUILayout.Button("BUTTON"))
        {
            Debug.Log("Button clicked");
            return true;
        }

        return false;
    }
}
#endif // UNITY_EDITOR