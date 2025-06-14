# Unity_CustomOnInspectorGUIBase

A base class for easily implementing customized Inspectors via OnInspectorGUI.

## Importing

You can use Package Manager or import it directly.

```
https://github.com/XJINE/Unity_CustomOnInspectorGUIBase.git?path=Assets/Packages/CustomOnInspectorGUIBase
```

## How to Use

Override following class and implement `OnInspectorGUI` method.

```csharp
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
```