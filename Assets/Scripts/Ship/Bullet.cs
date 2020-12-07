using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private const float lifeTime = 2;
  
    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }
  
    public void ApplyForse(Vector2 vector)
    {
        const float magnitude = 7f;
        GetComponent<Rigidbody2D>().AddForce(
             vector * magnitude,
            ForceMode2D.Impulse);
    }

}
