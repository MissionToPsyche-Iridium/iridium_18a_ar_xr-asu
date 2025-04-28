using UnityEngine;

public class SpacecraftPart : MonoBehaviour
{
    public GameObject panel;

    public void showPanel()
    {
        if (panel != null)
            panel.SetActive(true);
    }

    public void hidePanel()
    {
        if (panel != null)
            panel.SetActive(false);
    }

    public void TogglePanel()
    {
        if (panel != null)
        {
            Debug.Log($"{name} toggled panel: {panel.name}");
            panel.SetActive(!panel.activeSelf);
        }
        else
        {
            Debug.LogWarning($"{name} has no panel assigned.");
        }
    }


    public GameObject getPart()
    {
        return this.gameObject;
    }
}