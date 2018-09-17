using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BossCore : MonoBehaviour {

    public int hp = 1;
    public GameObject explosion;

    public void Explosion()
    {
        Instantiate(explosion, transform.position, transform.rotation);
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
            Explosion();
            
        }

    }
}
