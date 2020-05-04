using UnityEngine;

public class Dissolve : MonoBehaviour
{
    Material material;
    public Material dissolveMat;
    private bool isDissolving;
    private float fade = 1;
    private float dissolveSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
      /*initializes material*/
      material = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
      //fades over time
      if (isDissolving) {
        fade -= Time.deltaTime * dissolveSpeed;

        if (fade < 0f)  {
          fade = 0f;
          isDissolving = false;
          Destroy(gameObject);
        }
      }

      //sets the property
      material.SetFloat("_Fade", fade);
    }
    public void play(float dissolveSpeed)  {
      this.dissolveSpeed = dissolveSpeed;
      isDissolving = true;
      /*setting sprite material to the dissolve material*/
      GetComponent<SpriteRenderer>().material = dissolveMat;

      material = GetComponent<SpriteRenderer>().material;
    }
}
