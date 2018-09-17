using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FuelMovement : MonoBehaviour
{
    public int speed = 3;

	public List <Transform> Player;
	public Transform SelectedTarget;

    //public void Target(Transform target)
    //{
    //    transform.LookAt(target.position);
    //}
    
    void Start()
    {
        //GetComponent<Rigidbody2D>().velocity = transform.up.normalized * speed;
        //Destroy(gameObject, lifeTime);
		SelectedTarget = null;
		Player = new List<Transform>();
		AddPlayerToList();
    }

	public void AddPlayerToList()
	{
		GameObject[] ItemsInList = GameObject.FindGameObjectsWithTag("Player");
		foreach(GameObject _Player in ItemsInList)
		{
			AddTarget(_Player.transform);
		}
	}

	public void AddTarget(Transform player)
	{
		Player.Add(player);
	}
	public void DistanceToTarget()
	{
		Player.Sort(delegate( Transform t1, Transform t2){ 
			return Vector3.Distance(t1.transform.position,transform.position).CompareTo(Vector3.Distance(t2.transform.position,transform.position)); 
		});

	}

	public void TargetedPlayer() 
	{
		if(SelectedTarget == null)
		{
			DistanceToTarget();
			SelectedTarget = Player[0];
		}
	}


    void Update()
    {
		TargetedPlayer();
		//float dist = Vector3.Distance(SelectedTarget.transform.position,transform.position);
		transform.position = Vector3.MoveTowards(transform.position, SelectedTarget.position, speed * Time.deltaTime);
        
    }
}
