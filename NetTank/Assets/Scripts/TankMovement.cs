using UnityEngine;
using System.Collections;

public class TankMovement : MonoBehaviour 
{
	public float speed = 10f;
	public float rotationsSpeed = 10f;
	public GameObject bulletPrefab;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position += Input.GetAxis("Vertical") * transform.forward * 
			speed * Time.deltaTime;
	
		float rotation  = Input.GetAxis("Horizontal") * 
			rotationsSpeed * Time.deltaTime;

		transform.Rotate(Vector3.up,rotation);

		if(Input.GetButtonUp("Fire1"))
		{
			//Fire Weapon
			GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, transform.position, transform.rotation);
		}
	}
}
