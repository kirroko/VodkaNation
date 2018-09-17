using UnityEngine;
using System.Collections;

public class BulletDestroyer : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D c)
    {
        string LayerName = LayerMask.LayerToName(c.gameObject.layer);

        // if not bullet that is from the player, return nothing
        if (LayerName != "Bullet(Player)") return;

        Transform playerBullet = c.transform.parent;

        Bullet bullet = playerBullet.GetComponent<Bullet>();

        // delete collided object
        Destroy(c.gameObject);
    }
}
