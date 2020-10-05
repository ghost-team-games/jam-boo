using UnityEngine;

public class HauntIcon : MonoBehaviour
{
    [SerializeField]
    Sprite hauntIcon;

    [SerializeField]
    Sprite hauntDisabledIcon;

    SpriteRenderer icon;

    private void Awake()
    {
        icon = GetComponent<SpriteRenderer>();
        icon.enabled = false;
    }

    public void ShowHauntEnabledIcon()
    {
        icon.enabled = true;
        icon.sprite = hauntIcon;
    }

    public void ShowHauntDisabledIcon()
    {
        icon.enabled = true;
        icon.sprite = hauntDisabledIcon;
    }

    public void HideIcon()
    {
        icon.enabled = false;

    }
}
