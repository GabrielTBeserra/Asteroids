using UnityEngine;
using UnityEngine.UI;

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
    private GameObject enemy;

    [SerializeField]
    private double spawnAsteroidInterval;

    public static int gameEnimies = 0;
    private float lastSpawnedAmmoTime;
    private float lastSpawnedAsteroidTime;
    private float timeAmmoCounter;
    private float timeAsteroidCounter;

    [SerializeField]
    private Text ammos;

    private void Start()
    {
        ammos.text = "";
        timeAmmoCounter = 0;
        timeAsteroidCounter = 0;
        Camera mainCamera = Camera.main;
        leftLimit = mainCamera.ScreenToWorldPoint(new Vector3(0, 1, 0));
        rightLimit = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        lastSpawnedAmmoTime = timeAmmoCounter;
        lastSpawnedAsteroidTime = timeAsteroidCounter;


        SpawnEnemy();
    }

    void FixedUpdate()
    {
        ammos.text = $"Quantidade de municao: {ShipController.ammoCount}";
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

    void SpawnEnemy()
    {
        float xMin = GameManager.leftLimit.x;
        float xMax = GameManager.rightLimit.x;

        float yMin = GameManager.leftLimit.y;
        float yMax = GameManager.rightLimit.y;

        Vector2 posicaoInicial = new Vector2(xMin, Random.Range(yMin, yMax));
        Quaternion rotacaoInicial = new Quaternion();
        Instantiate(enemy, posicaoInicial, rotacaoInicial);
    }

}
