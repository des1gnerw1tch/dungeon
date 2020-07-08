using UnityEngine;

public class Tint : MonoBehaviour
{
    private Material material;
    private Color materialTintColor;
    private float tintFadeSpeed;

    void Awake()
    {
      //default color is transparent
      materialTintColor = new Color(1, 0, 0, 0);
      material = GetComponent<SpriteRenderer>().material;
      tintFadeSpeed = 6f;
    }

    // Update is called once per frame
    void Update()
    {
      if (materialTintColor.a > 0)  {
        materialTintColor.a = Mathf.Clamp01(materialTintColor.a - tintFadeSpeed * Time.deltaTime);
        material.SetColor("_Tint", materialTintColor);
      }
    }

    //unused / ?
    public void SetMaterial(Material material)  {
      this.material = material;
    }
    //this is what sets the tint, call this to tint stuff
    public void SetTintColor(Color color) {
      materialTintColor = color;
      material.SetColor("_Tint", materialTintColor);
    }
    //sets speed
    public void SetTintFadeSpeed(float tintFadeSpeed) {
      this.tintFadeSpeed = tintFadeSpeed;
    }
}
