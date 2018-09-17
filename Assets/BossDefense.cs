using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BossDefense : MonoBehaviour {

    public int hp = 1;
    public GameObject explosion;
    public GameObject defense;
    public bool canHit = false;
    public SpriteRenderer renderer;
    public bool core = false;
    public GameObject fuel;
    public int fuelcount;

    public void Update()
    {
        if (fuelcount == 25)
        {
            Instantiate(fuel, transform.position, transform.rotation);
            fuelcount = 0;
        }
    }
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

        if (defense.activeSelf == false)
        {
            canHit = true;
        }
        if (canHit == true)
        {
            hp = hp - bullet.power;
            fuelcount++;
            StartCoroutine(Blink(0.2f));
        }

        // delete collided object
        Destroy(c.gameObject);

        if (hp == 0)
        {
            Explosion();
            gameObject.SetActive(false);
            FindObjectOfType<Score>().AddPoint(500);
            if (core == true)
            {
                FindObjectOfType<Manager>().endGame = true;
                FindObjectOfType<Score>().AddPoint(1000);
            }
            

        }
    }
    private IEnumerator Blink(float waitTime)
    {
        renderer.enabled = false;
        yield return new WaitForSeconds(0.1f);
        renderer.enabled = true;
        yield return new WaitForSeconds(0.1f);
    }
}
