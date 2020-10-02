using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Limite de X e Y do lado esquerdo da camera
    public static Vector2 leftLimit;
    // Limite de X e Y do lado direito da camera
    public static Vector2 rightLimit;

    [SerializeField]
    GameObject[] asteroids;

    [SerializeField]
    GameObject ammo;

    [SerializeField]
    private double spawnAmmoInterval;

    [SerializeField]
    private GameObject enemy;

    [SerializeField]
    private double spawnAsteroidInterval;

    [SerializeField]
    private double spawnEnemyInterval;


    public static int gameEnemies = 0;
    public static int gameAsteroids = 0;
    private float lastSpawnedAmmoTime;
    private float lastSpawnedAsteroidTime;
    private float lastSpawnedEnemyTime;
    private float timeAmmoCounter;
    private float timeAsteroidCounter;
    private float timeEnemyCounter;

   

    private void Start()
    {
        timeAmmoCounter = 0;
        timeAsteroidCounter = 0;
        timeEnemyCounter = 0;
        Camera mainCamera = Camera.main;
        leftLimit = mainCamera.ScreenToWorldPoint(new Vector3(0, 1, 0));
        rightLimit = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        lastSpawnedAmmoTime = timeAmmoCounter;
        lastSpawnedAsteroidTime = timeAsteroidCounter;
        lastSpawnedEnemyTime = timeEnemyCounter;
    }

    void FixedUpdate()
    {
        timeAmmoCounter += Time.deltaTime;
        timeAsteroidCounter += Time.deltaTime;
        timeEnemyCounter += Time.deltaTime;


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

        if ((lastSpawnedEnemyTime + spawnEnemyInterval) < timeEnemyCounter)
        {
            SpawnEnemy();
            timeEnemyCounter = 0;
        }
    }

    void SpawnAsteroid()
    {
        if (gameAsteroids < 5)
        {
            Instantiate(
                asteroids[Random.Range(0, asteroids.Length)],
                new Vector2(Random.Range(leftLimit.x, rightLimit.x),
                Random.Range(leftLimit.y, rightLimit.y)),
                new Quaternion());

            gameAsteroids++;
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

    void SpawnEnemy()
    {
        if (gameEnemies < 2)
        {
            gameEnemies++;
            float xMin = GameManager.leftLimit.x;
            float xMax = GameManager.rightLimit.x;

            float yMin = GameManager.leftLimit.y;
            float yMax = GameManager.rightLimit.y;

            Vector2 posicaoInicial = new Vector2(xMin, Random.Range(yMin, yMax));
            Quaternion rotacaoInicial = new Quaternion();
            Instantiate(enemy, posicaoInicial, rotacaoInicial);
        }
    }
}
