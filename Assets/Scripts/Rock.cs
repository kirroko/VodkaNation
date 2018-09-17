using UnityEngine;
using System.Collections;

public class Rock : MonoBehaviour
{
    public GameObject miniRock_0;

    Spaceship spaceship;
    public int hp = 1;
    public bool createOnDestroy = false;

    IEnumerator Start()
    {
        spaceship = GetComponent<Spaceship>();

        //Movement
        Move(transform.up * -1);


        if (spaceship.CanShot == false)
        {
            yield break;
        }


        while (true)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform shotPosition = transform.GetChild(i);

                spaceship.Shot(shotPosition);
            }

            yield return new WaitForSeconds(spaceship.shotDelay);
        }


    }
    void Update()
    {
        float translation = Time.deltaTime * 10;
        transform.Rotate(Time.deltaTime, 0, 1);
    }
    public void Move(Vector2 direction)
    {
        GetComponent<Rigidbody2D>().velocity = direction * spaceship.speed;
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        string LayerName = LayerMask.LayerToName(c.gameObject.layer);

        // if not bullet that is from the player, return nothing
        if (LayerName != "Bullet(Player)") return;

        Transform playerBullet = c.transform.parent;

        Bullet bullet = playerBullet.GetComponent<Bullet>();

        hp = hp - bullet.power;

        // delete collided object
        Destroy(c.gameObject);

        if (hp == 0)
        {
            spaceship.Explosion();
            Destroy(gameObject);
            if (createOnDestroy == true)
            {
                Instantiate(miniRock_0, transform.position, Quaternion.identity);
            }
        }
        else
        {
            spaceship.GetAnimator().SetTrigger("Damage");
        }
    }
}
