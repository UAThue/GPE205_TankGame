using UnityEngine;

public class NoiseMaker : MonoBehaviour
{
    public float noiseVolume;
    public float noiseDecayPerSecond;

    public void MakeNoise ( float amountOfNoiseMade )
    {
        noiseVolume = Mathf.Max(amountOfNoiseMade, noiseVolume);
    }


    // Update is called once per frame
    public void Update()
    {
        noiseVolume -= noiseDecayPerSecond * Time.deltaTime;
        if (noiseVolume < 0)
        {
            noiseVolume = 0;
        }
    }
}
