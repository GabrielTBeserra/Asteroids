using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rgb;

    private Vector2[] ac = new Vector2[] { Vector2.right, Vector2.up, Vector2.down , Vector2.left };

    private float addForceTime;
    private float lastTime;
    private float interval = 0;

    void Start()
    {
        addForceTime = 1;
        lastTime = 0;
        rgb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CheckCamLimits();    
    }


    void FixedUpdate()
    {

        addForceTime += Time.deltaTime;


        //if ((lastTime + interval) < addForceTime)
        //{
            addForceTime = 0;


            int a = Random.Range(0, ac.Length);

            rgb.AddForce(ac[a] * 10);
        
        
        //}

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
}
