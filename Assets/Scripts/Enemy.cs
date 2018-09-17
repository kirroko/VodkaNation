using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    Spaceship spaceship;
    public int hp = 1;
	public GameObject fuel;
    public GameObject powerUP;

    public int point = 100;

    IEnumerator Start()
    {
        spaceship = GetComponent<Spaceship>();

        //Movement
        Move(transform.up * -1);

        
        if(spaceship.CanShot == false)
        {
            yield break;
        }


        while (true)
        {
            for ( int i = 0; i < transform.childCount; i ++)
            {
                Transform shotPosition = transform.GetChild(i);

                spaceship.Shot(shotPosition);
            }

            yield return new WaitForSeconds(spaceship.shotDelay);
        }

        
    }
    public void Move (Vector2 direction)
    {
        GetComponent<Rigidbody2D>().velocity = direction * spaceship.speed;
    }
 
    void OnTriggerEnter2D (Collider2D c)
    {
        string LayerName = LayerMask.LayerToName(c.gameObject.layer);

        // if not bullet that is from the player, return nothing
        if (LayerName != "Bullet(Player)") return;

        Transform playerBullet = c.transform.parent;

        Bullet bullet = playerBullet.GetComponent<Bullet>();

        hp = hp - bullet.power;

        // delete collided object
        Destroy(c.gameObject);

        if(hp == 0)
        {
            FindObjectOfType<Score>().AddPoint(point);

            spaceship.Explosion();

            Destroy(gameObject);

            Instantiate(fuel,transform.position,transform.rotation);


            
        }
        else
        {
            spaceship.GetAnimator().SetTrigger("Damage");
        }
    }
}
