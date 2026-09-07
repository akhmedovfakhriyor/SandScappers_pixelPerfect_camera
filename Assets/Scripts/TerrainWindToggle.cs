using UnityEngine;

public class TerrainWindController : MonoBehaviour
{
    public Terrain terrain;
    public GameObject windObject;
    public float normalBending = 0.3f;

    public void SetWind(bool isOn)
    {
        Debug.Log("Toggle: " + isOn);

        if (windObject != null)
            windObject.SetActive(isOn);

        if (terrain != null)
            terrain.terrainData.wavingGrassStrength = isOn ? normalBending : 0f;
    }
}
