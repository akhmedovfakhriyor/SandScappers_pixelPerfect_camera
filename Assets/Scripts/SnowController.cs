using UnityEngine;

public class SnowController : MonoBehaviour
{
    public GameObject snowParticles; // your snow particle system

    public void SetSnow(bool isOn)
    {
        Debug.Log("Snow: " + isOn);

        if (snowParticles != null)
            snowParticles.SetActive(isOn);
    }
}
