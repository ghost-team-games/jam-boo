using UnityEngine;

public class HauntIcon : MonoBehaviour
{
    //[SerializeField]
    //Sprite hauntIcon;

   // [SerializeField]
   // Sprite hauntDisabledIcon;

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
        //icon = GetComponent<SpriteRenderer>();
        //icon.enabled = false;

        cursorMode = CursorMode.Auto;
        cursorPoint = Vector2.zero;
        HideIcon();

    }

    public void ShowHauntEnabledIcon()
    {
        //icon.enabled = true;
        //icon.sprite = hauntIcon;

        Cursor.SetCursor(hauntCursor, cursorPoint, cursorMode);
    }

    public void ShowHauntDisabledIcon()
    {
        //icon.enabled = true;
        //icon.sprite = hauntDisabledIcon;

        Cursor.SetCursor(noHauntCursor, cursorPoint, cursorMode);
    }

    public void HideIcon()
    {
        //icon.enabled = false;

        Cursor.SetCursor(normalCursor, cursorPoint, cursorMode);

    }
}
