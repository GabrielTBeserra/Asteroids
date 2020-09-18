using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Vector2 leftLimit;
    public static Vector2 rightLimit;

    [SerializeField]
    GameObject[] enimies;

    [SerializeField]
    GameObject ammo;

    [SerializeField]
    private double spawnAmmoInterval;

    [SerializeField]
    private double spawnAsteroidInterval;

    public static int gameEnimies = 0;
    private float lastSpawnedAmmoTime;
    private float lastSpawnedAsteroidTime;
    private float timeAmmoCounter;
    private float timeAsteroidCounter;

    private void Start()
    {
        timeAmmoCounter = 0;
        timeAsteroidCounter = 0;
        Camera mainCamera = Camera.main;
        leftLimit = mainCamera.ScreenToWorldPoint(new Vector3(0, 1, 0));
        rightLimit = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        lastSpawnedAmmoTime = timeAmmoCounter;
        lastSpawnedAsteroidTime = timeAsteroidCounter;        
    }

    void FixedUpdate()
    {

        timeAmmoCounter += Time.deltaTime;
        timeAsteroidCounter += Time.deltaTime;


        if ((lastSpawnedAmmoTime + spawnAmmoInterval) < timeAmmoCounter)
        {
            SpawnAmmo();
            timeAmmoCounter = 0;
        }

        if ((lastSpawnedAsteroidTime + spawnAsteroidInterval) < timeAsteroidCounter)
        {
            SpawnAsteroid();
            timeAsteroidCounter = 0;
        }
    }

    void SpawnAsteroid()
    {
        if (gameEnimies < 10)
        {
            Instantiate(
                enimies[Random.Range(0, enimies.Length)],
                new Vector2(Random.Range(leftLimit.x, rightLimit.x),
                Random.Range(leftLimit.y, rightLimit.y)),
                new Quaternion());

            gameEnimies++;
        }
    }

    void SpawnAmmo()
    {
        Instantiate(
                ammo,
                new Vector2(Random.Range(leftLimit.x, rightLimit.x),
                Random.Range(leftLimit.y, rightLimit.y)),
                new Quaternion());
    }
}
