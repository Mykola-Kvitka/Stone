using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawn : MonoBehaviour
{

    [SerializeField]
    private List<Sprite> asteroidSprites;

    [SerializeField]
    private GameObject prefabAsteroid;


    //private const int SpawnBorderSize = 100;
    //private int minSpawnX;
    //private int maxSpawnX;
    //private int minSpawnY;
    //private int maxSpawnY;
    // Start is called before the first frame update
    void Start()
    {
        // save spawn boundaries for efficiency
        //minSpawnX = SpawnBorderSize;
        //maxSpawnX = Screen.width - SpawnBorderSize;
        //minSpawnY = SpawnBorderSize;
        //maxSpawnY = Screen.height - SpawnBorderSize;
        for (int i = 0; i< 4; i++)
       SpawnAsteroid(i);

    }

    private void SpawnAsteroid(int i)
    {
        // generate random location and create new teddy bear
        Vector3 location = new Vector3(0,0,0);
        GameObject teddyBear = Instantiate(prefabAsteroid) as GameObject;

        Asteroid asteroid = teddyBear.GetComponent<Asteroid>();
        
        switch (i)
        {
            case 0:
                location = new Vector3(-15,
                                       0,
                                       0);
                asteroid.direction1 = Asteroid.Direction.Right;
                break;
            case 1:
                location = new Vector3(15,
                                      0,
                                       0);
                asteroid.direction1 = Asteroid.Direction.Left;
                break;
            case 2:
                location = new Vector3(0,
                                      5,
                                       0);
                asteroid.direction1 = Asteroid.Direction.Down;
                break;
            case 3:
                location = new Vector3(0,
                                        -5,
                                         0);
                asteroid.direction1 = Asteroid.Direction.Up;
                break;
        }
      
        
        teddyBear.transform.position = location;

        
        // set random sprite for new teddy bear
        SpriteRenderer spriteRenderer = teddyBear.GetComponent<SpriteRenderer>();
        int spriteNumber = Random.Range(0, asteroidSprites.Count);
        spriteRenderer.sprite = asteroidSprites[spriteNumber];
    }
}
