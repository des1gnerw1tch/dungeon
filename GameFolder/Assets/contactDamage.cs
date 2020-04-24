using UnityEngine;

public class contactDamage : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerHealth player;
    public int damage;
    void Start()
    {
      player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D coll)  {
      if (coll.gameObject.CompareTag("Player")) {
      player.TakeDamage(damage);
      }
    }
}
