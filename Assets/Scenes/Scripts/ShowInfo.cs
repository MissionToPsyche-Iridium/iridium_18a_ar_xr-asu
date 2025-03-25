using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInfo : MonoBehaviour
{
    public SpacecraftPart magnetometerPanel;
    public SpacecraftPart multispectralPanel;
    public SpacecraftPart grnsPanel;
    public SpacecraftPart dopplerPanel;
    public SpacecraftPart dsocPanel;
    public SpacecraftPart solarPanel;

    // Start is called before the first frame update
    void Start()
    {
        magnetometerPanel.name = "magnetometer";
        multispectralPanel.name = "multispectral";
        grnsPanel.name = "grns";
        dopplerPanel.name = "doppler";
        dsocPanel.name = "dsoc";
        solarPanel.name = "solar";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
