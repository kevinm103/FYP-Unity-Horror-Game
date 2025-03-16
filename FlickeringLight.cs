using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    public Light flickeringLight;  // Assign light 
    public float minIntensity = 0.5f;
    public float maxIntensity = 2.0f;
    public float flickerSpeed = 0.1f;

    private float timer = 0f;

    void Start()
    {
        if (flickeringLight == null)
        {
            flickeringLight = GetComponent<Light>();
        }
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            flickeringLight.intensity = Random.Range(minIntensity, maxIntensity);
            timer = flickerSpeed;
        }
    }
}
