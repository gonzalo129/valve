using UnityEngine;
using UnityEngine.Perception.Randomization.Randomizers;
public class ValveRotationRandomizer : Randomizer
{
    public GameObject valve;
    public Vector3 minRotation = Vector3.zero;
    public Vector3 maxRotation = new Vector3(0f, 360f, 0f);
    protected override void OnIterationStart()
    {
        if (valve != null)
        {
            float yRotation = Random.Range(minRotation.y, maxRotation.y);
            float x = Random.Range(minRotation.x, maxRotation.x);
            float y = Random.Range(minRotation.y, maxRotation.y);
            float z = Random.Range(minRotation.z, maxRotation.z);
            valve.transform.localRotation = Quaternion.Euler(x, y, z);
        }
    }
}