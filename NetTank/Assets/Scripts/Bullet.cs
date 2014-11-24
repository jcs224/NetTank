using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour 
{
	public float speed = 10f;

	// Use this for initialization
	void Start () 
	{
		Destroy(gameObject, 3f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position += speed * transform.forward * Time.deltaTime;
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.tag == "Crate")
		{
			Debug.Log("Hit");
			Destroy(gameObject);
		}
	}
}
