#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

public abstract class CustomOnInspectorGUIBase<T> : Editor where T : Object
{
    // NOTE:
    // Override following parameters if you want to change the layout.

    protected virtual bool   LayoutTop => true;
    protected virtual string Title     => "Custom GUI";

    public override void OnInspectorGUI()
    {
        if (!LayoutTop)
        {
            base.OnInspectorGUI();
        }

        GUILayout.BeginVertical(GUI.skin.box);

        GUILayout.Label(Title, EditorStyles.boldLabel);

        if (OnInspectorGUI(target as T))
        {
            EditorUtility.SetDirty(target);
        }

        GUILayout.EndVertical();

        if (LayoutTop)
        {
            base.OnInspectorGUI();
        }
    }

    // NOTE:
    // return true if the target is updated.
    protected abstract bool OnInspectorGUI(T target);
}

#endif // UNITY_EDITOR