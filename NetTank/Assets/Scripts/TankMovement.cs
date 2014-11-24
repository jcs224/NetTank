using UnityEngine;
using System.Collections;

public class TankMovement : MonoBehaviour 
{
	public float speed = 10f;
	public float rotationsSpeed = 10f;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(networkView.isMine)
		{

			transform.position += Input.GetAxis("Vertical") * transform.forward * 
				speed * Time.deltaTime;
		
			float rotation  = Input.GetAxis("Horizontal") * 
				rotationsSpeed * Time.deltaTime;

			transform.Rotate(Vector3.up,rotation);


			if(Input.GetAxis("Fire1") > 0.5f)
			{
				//Fire Weapon
			}

		}
	}
}
