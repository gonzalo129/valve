using UnityEngine;
using UnityEngine.Perception.Randomization.Randomizers;
public class ValveLightingAndMaterialRandomizer : Randomizer
{
    public GameObject valveParent;  // Assign your valve parent GameObject here in Inspector
    public Light directionalLight;  // Assign your scene’s directional light here
    public Material[] materialOptions; // Assign alternate materials here
    public Color minColor = Color.white;
    public Color maxColor = Color.gray;
    public Vector2 lightYawRange = new Vector2(-180f, 180f);
    public Vector2 lightPitchRange = new Vector2(10f, 80f);
    public float minIntensity = 0.5f;
    public float maxIntensity = 1.5f;
    protected override void OnIterationStart()
    {
        Debug.Log($"Children of valveParent '{valveParent.name}':");
        foreach (Transform child in valveParent.transform)
        { Debug.Log($" - {child.name}"); }
        if (directionalLight != null)
        {
            float intensity = Random.Range(minIntensity, maxIntensity);
            directionalLight.intensity = intensity;
            float yaw = Random.Range(lightYawRange.x, lightYawRange.y);
            float pitch = Random.Range(lightPitchRange.x, lightPitchRange.y);
            directionalLight.transform.rotation = Quaternion.Euler(pitch, yaw, 0f);
            directionalLight.color = Random.ColorHSV(0f, 1f, 0.5f, 1f, 0.7f, 1f);
        }
        if (valveParent != null && materialOptions.Length > 0)
        {
            // Find the child “Default” GameObject inside valveParent
            Transform defaultChild = valveParent.transform.Find("Default");
            if (defaultChild != null)
            {
                Renderer renderer = defaultChild.GetComponent<Renderer>();
                if (renderer != null)
                {
                    // Pick a random material from options
                    Material selectedMaterial = new Material(materialOptions[Random.Range(0, materialOptions.Length)]);
                    // Randomize color within range (if the shader supports _BaseColor)
                    Color randomColor = Color.Lerp(minColor, maxColor, Random.value);
                    if (selectedMaterial.HasProperty("_BaseColor"))
                        selectedMaterial.SetColor("_BaseColor", randomColor);
                    // Assign the new material instance to the renderer
                    renderer.material = selectedMaterial;
                }
                else
                {
                    Debug.LogWarning("Renderer component not found on ‘Default’ child.");
                }
            }
            else
            {
                Debug.LogWarning("‘Default’ child GameObject not found under valveParent.");
            }
        }
        else
        {
            Debug.LogWarning("Valve parent or material options not assigned.");
        }
    }
}



































