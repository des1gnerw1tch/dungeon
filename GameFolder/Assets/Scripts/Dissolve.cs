using UnityEngine;

public class Dissolve : MonoBehaviour
{
    Material material;
    public bool isDissolving;
    public float fade = 1;

    // Start is called before the first frame update
    void Start()
    {
      material = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {

      if (isDissolving) {
        fade -= Time.deltaTime;

        if (fade < 0f)  {
          fade = 0f;
          isDissolving = false;
          Destroy(gameObject);
        }
      }

      //set the property
      material.SetFloat("_Fade", fade);
    }
}
