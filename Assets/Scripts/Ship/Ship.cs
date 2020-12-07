using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A ship
/// </summary>
public class Ship : MonoBehaviour
{


    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private GameObject audioManager;
    [SerializeField]
    private HUD HUD;
    // thrust and rotation support
    private Rigidbody2D rb2D;
    private Vector2 thrustDirection = new Vector2(1, 0);
    private const float ThrustForce = 5;
    private const float RotateDegreesPerSecond = 180;

  

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        // saved for efficiency
        rb2D = GetComponent<Rigidbody2D>();


    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        // check for rotation input
        float rotationInput = Input.GetAxis("Rotate");
        if (rotationInput != 0)
        {

            // calculate rotation amount and apply rotation
            float rotationAmount = RotateDegreesPerSecond * Time.deltaTime;
            if (rotationInput < 0)
            {
                rotationAmount *= -1;
            }
            transform.Rotate(Vector3.forward, rotationAmount);

            // change thrust direction to match ship rotation
            float zRotation = (transform.eulerAngles.z-90) * Mathf.Deg2Rad;
            thrustDirection.x = Mathf.Cos(zRotation);
            thrustDirection.y = Mathf.Sin(zRotation);
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {

            Fire();
        }
    }

    /// <summary>
    /// FixedUpdate is called 50 times per second
    /// </summary>
    void FixedUpdate()
    {
        // thrust as appropriate
        if (Input.GetAxis("Thrust") != 0)
        {
            transform.Translate(Vector2.down * ThrustForce * Time.fixedDeltaTime);
            //rb2D.AddForce(ThrustForce * thrustDirection,
            //    ForceMode2D.Force);
        }
    }
    private void Fire()
    {
        GameObject bulletPre = Instantiate(bulletPrefab) as GameObject;
        Bullet bullet = bulletPre.GetComponent<Bullet>();
        
        
        
        bullet.transform.position = transform.position;
        bullet.ApplyForse(thrustDirection);
        AudioManager.Play(AudioClipName.PlayerShot);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
          HUD.Stop();
            Destroy(gameObject);
            
            AudioManager.Play(AudioClipName.PlayerDeath);  
        }
    }
}
