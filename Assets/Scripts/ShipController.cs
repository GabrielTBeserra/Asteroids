using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField]
    private int speed;

    [SerializeField]
    public float rotationSpeed;

    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private Transform firespotTransform;

    private int life;
    Rigidbody2D rgb2;

    private int ammoCount;
    void Start()
    {
        rgb2 = GetComponent<Rigidbody2D>();
        life = 3;
        ammoCount = 10;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Quantidade de municao: " + ammoCount);
            if(ammoCount > 0)
            {
                Instantiate(bulletPrefab, firespotTransform.position, firespotTransform.rotation);
                ammoCount--;
            }
            
        }
    }

    void FixedUpdate()
    {
        CheckCamLimits();

        float h = rotationSpeed * Input.GetAxisRaw("Horizontal");
        float v = rotationSpeed * Input.GetAxisRaw("Vertical");

        //transform.Rotate(-Vector3.forward * h * rotationSpeed);

        rgb2.AddTorque(-h * rotationSpeed);
        rgb2.AddRelativeForce(Vector3.up * v * speed);




    }

    void CheckCamLimits()
    {
        Vector3 pos = transform.position;

        if (transform.position.x > GameManager.rightLimit.x)
        {
            pos.x = GameManager.leftLimit.x;
        }
        else if (transform.position.x < GameManager.leftLimit.x)
        {
            pos.x = GameManager.rightLimit.x;
        }
        else if (transform.position.y > GameManager.rightLimit.y)
        {
            pos.y = GameManager.leftLimit.y;
        }
        else if (transform.position.y < GameManager.leftLimit.y)
        {
            pos.y = GameManager.rightLimit.y;
        }

        transform.position = pos;
    }


    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.CompareTag("Ammo"))
        {

            if (ammoCount >= 5)
            {
                ammoCount = 10;
            }
            else
            {
                ammoCount += 5;
            }
            
            
            Destroy(col.gameObject);
        }
        else
        {
            life--;
            if (life == 0)
            {
                Respawn();
                life = 3;
            }
                
        }

    }

    void Respawn()
    {
        gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, Camera.main.nearClipPlane));
        gameObject.transform.rotation = new Quaternion();
        rgb2.angularVelocity = 0;
        rgb2.velocity = new Vector2();
    }
}
