using UnityEngine;

public class RainController : MonoBehaviour
{
    public GameObject rainParticles; // your rain particle system

    public void SetRain(bool isOn)
    {
        Debug.Log("Rain: " + isOn);

        if (rainParticles != null)
            rainParticles.SetActive(isOn);
    }
}
