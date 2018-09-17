using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Rigidbody2D))]
public class Spaceship : MonoBehaviour
{
    
    public float speed;

    public float shotDelay;

    public GameObject bullet;

    public GameObject explosion;

    public GameObject rockets; // ability 1

    public GameObject laser; // ability 2

    public GameObject[] powerUps;

    private Animator animator;

    public bool CanShot;

    public float nextFire;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void PowerUpChance()
    {
        float precentageChance; // Which power up
        precentageChance = Mathf.Clamp(powerUps.Length, 1, powerUps.Length);


    }
    public void Explosion()
    {
        Instantiate(explosion, transform.position, transform.rotation);
    }

    public void Shot(Transform origin)
    {
        Instantiate(bullet, origin.position, origin.rotation);
    }
    public void rocketChaser(Transform origin)
    {
        Instantiate(rockets, origin.position, origin.rotation);
    }
    public void rocketChaserTarget(Transform target)
    {
        transform.LookAt(target.position);
    }
    public void EnemyShot(Transform origin)
    {
        Instantiate(bullet, origin.position, origin.rotation);
    }
    public Animator GetAnimator()
    {
        return animator;
    }

    /*public void PowerUp(Transform origin)
    {
        Instantiate()
    }*/
    // protected abstract void Move(Vector2 direction);
}
