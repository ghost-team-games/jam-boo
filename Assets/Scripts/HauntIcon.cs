using UnityEditor;
using UnityEngine;

public class HauntIcon : MonoBehaviour
{
    [SerializeField]
    Texture2D hauntCursor;

    [SerializeField]
    Texture2D noHauntCursor;

    [SerializeField]
    Texture2D normalCursor;

    SpriteRenderer icon;

    private CursorMode cursorMode;
    private Vector2 cursorPoint;

    private void Awake()
    {
        cursorMode = CursorMode.Auto;
        cursorPoint = Vector2.zero;
        HideIcon();

    }

    public void ShowHauntEnabledIcon()
    {
        Cursor.SetCursor(hauntCursor, cursorPoint, cursorMode);
    }

    public void ShowHauntDisabledIcon()
    {
        Cursor.SetCursor(noHauntCursor, cursorPoint, cursorMode);
    }

    public void HideIcon()
    {
        Cursor.SetCursor(normalCursor, cursorPoint, cursorMode);

    }
}
