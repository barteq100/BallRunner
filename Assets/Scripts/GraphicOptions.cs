using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphicOptions : MonoBehaviour
{
    public Toggle FullScreenToggle;
    public Toggle VSyncToggle;
    // Start is called before the first frame update
    void Start()
    {
        FullScreenToggle.isOn = Screen.fullScreen;
        VSyncToggle.isOn = QualitySettings.vSyncCount > 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ApplyGraphics()
    {
        Screen.fullScreen = FullScreenToggle.isOn;
        if (VSyncToggle.isOn)
        {
            QualitySettings.vSyncCount = 1;
        } else
        {
            QualitySettings.vSyncCount = 0;
        }
    }
}
