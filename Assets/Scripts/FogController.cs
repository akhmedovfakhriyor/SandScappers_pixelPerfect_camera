using UnityEngine;

public class FogController : MonoBehaviour
{
    public void SetFog(bool isOn)
    {
        Debug.Log("Fog: " + isOn);
        RenderSettings.fog = isOn;
    }
}
