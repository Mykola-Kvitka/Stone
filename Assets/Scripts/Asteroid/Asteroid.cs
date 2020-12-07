using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
   
    public enum Direction
    {
        Left,
        Right,
        Up,
        Down
    }
    public Direction direction1;
    void Start()
    {
        
        Initialise();

    }

    private  void Initialise()
    {

        const float MinImpulseForce = 3f;
        const float MaxImpulseForce = 5f;

        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
        float degre = 0;
        switch (direction1)
        {
            case Direction.Down:
                degre = 255;
                break;
            case Direction.Left:
                degre = 165;
                break;
            case Direction.Right:
                degre = 345;  
                break;
            case Direction.Up:
                degre = 75;
                break;
        }
        if (degre >= 360)
        { degre -= 360; }
        
            float angle = (degre + Random.Range(0, 30)) * Mathf.Deg2Rad;

            Vector2 direction = new Vector2(
                Mathf.Cos(angle), Mathf.Sin(angle));
            GetComponent<Rigidbody2D>().AddForce(
                 direction * magnitude,
                ForceMode2D.Impulse);
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        { 
          
          
            Vector3 localS = transform.localScale;
            localS.x /= 2;
            localS.y /= 2;
            if (localS.x >= 0.5)
            {
                Spawn(gameObject, localS);
                Spawn(gameObject, localS);
            }
            AudioManager.Play(AudioClipName.AsteroidHit);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
    private void Spawn(GameObject prefabAsteroid, Vector3 location)
    {
      

       
        GameObject Aster = Instantiate(prefabAsteroid) as GameObject;
        Aster.transform.localScale = location;
        Aster.transform.position = prefabAsteroid.transform.position;

    }
}
