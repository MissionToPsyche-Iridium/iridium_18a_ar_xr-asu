using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SpacecraftPart : MonoBehaviour
{
    public string name;
    public GameObject part;
    public GameObject panel;

    private void Start()
    {
        hidePanel();
    }

    void OnGUI()
    {
        if (Selection.activeGameObject == part)
        {
            showPanel();
        }
        else
        {
            hidePanel();
        }
    }

    public void showPanel()
    {
        panel.SetActive(true);
    }

    public void hidePanel()
    {
        panel.SetActive(false);
    }
}
