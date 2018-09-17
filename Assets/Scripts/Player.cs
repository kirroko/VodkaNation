using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    Spaceship spaceship;
    FuelBar fuelBar;
    private bool died;
    //public float Speed = 5;
    //public float nextFire = 0.0f;
    //public float shotDelay = 0.5f;
    // public GameObject Bullet;

    GameObject[] DesFuel;

    IEnumerator FireLaser()
    {
        while (Input.GetKey(KeyCode.Space))
        {
            spaceship.Shot(transform);

            // GetComponent<AudioSource>().Play();

            yield return new WaitForSeconds(spaceship.shotDelay);
        }
    }

    void Awake()
    {
        spaceship = GetComponent<Spaceship>();
        fuelBar = GetComponent<FuelBar>();
    }

	void Update ()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        
        Vector2 Direction = new Vector2(x, y).normalized;
        bool input = Input.GetKey(KeyCode.Space);
        // Shooting
        if (input && Time.time > spaceship.nextFire)
        {
            spaceship.nextFire = Time.time + spaceship.shotDelay;
            StopCoroutine("FireLaser");
            StartCoroutine("FireLaser");
        }

        // Clamp + movement
        Move(Direction);
        
        if(Input.GetKey(KeyCode.Alpha1))
        {
            GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
            Destroy(enemy);
        }   
        // DLC
        /*if(Input.GetKeyDown(KeyCode.Alpha1)) // Rocket Chaser ability
        {
            spaceship.rocketChaser(transform);
        }

        if(Input.GetKeyDown(KeyCode.Alpha2)) // Laser ability
        {

        }

        if(Input.GetKeyDown(KeyCode.LeftShift)) // Booster
        {

        }

        if(Input.GetKeyDown(KeyCode.Q)) // ulit P.S requires one more statement that check whatever players has Light Cores to use.
        {

        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log(LayerMask.NameToLayer("Enemy"));
        }*/
	}

    void Move(Vector2 direction)
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        Vector2 pos = transform.position;

        pos += direction * spaceship.speed * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        transform.position = pos;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        string LayerName = LayerMask.LayerToName(other.gameObject.layer);

        // Remove bullet
        if (LayerName == "Bullet(Enemy)")
        {
            Destroy(other.gameObject);
        }

        if (LayerName == "Bullet(Enemy)" || LayerName == "Enemy")
        {
            FindObjectOfType<Manager>().GameOver();

            fuelBar.fuel = 1;

            spaceship.Explosion();

            Destroy(gameObject);

            DestroyAll("Fuel");

        }

        if (LayerName == "Fuel")
        {
            fuelBar.fuel += 10;
            Destroy(other.gameObject);
        }
    }

    void DestroyAll(string tag)
    {
        GameObject[] fuels = GameObject.FindGameObjectsWithTag(tag);
        for (int i = 0; i < fuels.Length; i++)
        {
            Destroy(fuels[i]);
        }
    }
}
