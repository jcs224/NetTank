using UnityEngine;
using System.Collections;

public class TankMovement : MonoBehaviour 
{
	public float thrust = 100f;
	public float rotationSpeed = 200f;

	public GameObject bulletPrefab;
	public Transform bulletFirePosition;

	
	void Start () 
	{
	
	}


    void Update()
    {
        if (networkView.isMine)
        {
            float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;

            transform.Rotate(Vector3.up, rotation);

            if (Input.GetButtonUp("Fire1"))
            {
                //Fire Weapon
                //GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, bulletFirePosition.position, transform.rotation);
                Network.Instantiate(bulletPrefab, bulletFirePosition.position, transform.rotation,0);
            }
        }
    }



	void FixedUpdate()
	{
		if (networkView.isMine)
		{
			rigidbody.AddForce( (transform.forward * thrust) * Input.GetAxis("Vertical") );
		}
	}
}






