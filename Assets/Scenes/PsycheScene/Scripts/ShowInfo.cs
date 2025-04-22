using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class ShowInfo : MonoBehaviour
{
    public SpacecraftPart magnetometer;
    public SpacecraftPart multispectral;
    public SpacecraftPart grns;
    public SpacecraftPart doppler;
    public SpacecraftPart dsoc;
    public SpacecraftPart propulsion;
    public SpacecraftPart solar;

    // Start is called before the first frame update
    void Start()
    {
        magnetometer.hidePanel();
        multispectral.hidePanel();
        grns.hidePanel();
        doppler.hidePanel();
        dsoc.hidePanel();
        solar.hidePanel();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;

            if (Physics.Raycast(ray,out hit))
            {
                GameObject selected = hit.collider.gameObject;

                if (selected == magnetometer.getPart())
                {
                    magnetometer.showPanel();
                }
                if (selected == multispectral.getPart())
                {
                    multispectral.showPanel();
                }
                if (selected == grns.getPart())
                {
                    grns.showPanel();
                }
                if (selected == doppler.getPart()) { doppler.showPanel(); }
                if (selected == dsoc.getPart()) { dsoc.showPanel(); }
                if (selected == solar.getPart()) { solar.showPanel(); }
            }

        }*/

        if (EventSystem.current.currentSelectedGameObject != null)
        {
            GameObject currSelected = EventSystem.current.currentSelectedGameObject;
            if (currSelected == magnetometer.getPart()) { magnetometer.showPanel();
                Debug.Log("Selected Object: magnetometer");
            }
            else { magnetometer.hidePanel(); }
            if (currSelected == multispectral.getPart()) { multispectral.showPanel(); Debug.Log("Selected Object: magnetometer"); }
            else { multispectral.hidePanel(); }
            if (currSelected == grns.getPart()) { grns.showPanel(); Debug.Log("Selected Object: grns"); }
            else { grns.hidePanel(); }
            if (currSelected == doppler.getPart()) { doppler.showPanel(); Debug.Log("Selected Object: dopplet"); }
            else { doppler.hidePanel(); }
            if (currSelected == dsoc.getPart()) { dsoc.showPanel(); Debug.Log("Selected Object: dsoc"); }
            else { dsoc.hidePanel(); }
            if (currSelected == solar.getPart()) { solar.showPanel(); Debug.Log("Selected Object: solar"); }
            else { solar.hidePanel(); }
        }
    }

    private void OnMouseDown()
    {
        if (gameObject == magnetometer.getPart()) { magnetometer.showPanel(); Debug.Log("Selected Object: magnetometer"); }
        else { magnetometer.hidePanel(); }
        if (gameObject == multispectral.getPart()) { multispectral.showPanel(); Debug.Log("Selected Object: magnetometer"); }
        else { multispectral.hidePanel(); }
        if (gameObject == grns.getPart()) { grns.showPanel(); Debug.Log("Selected Object: grns"); }
        else { grns.hidePanel(); }
        if (gameObject == doppler.getPart()) { doppler.showPanel(); Debug.Log("Selected Object: doppler"); }
        else { doppler.hidePanel(); }
        if (gameObject == dsoc.getPart()) { dsoc.showPanel(); Debug.Log("Selected Object: dsoc"); }
        else { dsoc.hidePanel(); }
        if (gameObject == solar.getPart()) { solar.showPanel(); Debug.Log("Selected Object: solar"); }
        else { solar.hidePanel(); }
    }
}
