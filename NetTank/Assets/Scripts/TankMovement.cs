using UnityEngine;
using System.Collections;

public class TankMovement : MonoBehaviour 
{
	public float thrust = 100f;
	public float rotationSpeed = 200f;

	public GameObject bulletPrefab;
	public Transform bulletFirePosition;

    private Damagable damage;
         
	
	void Start () 
	{
        damage = GetComponent<Damagable>();
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
                //Network.Instantiate(bulletPrefab, bulletFirePosition.position, transform.rotation, 0);

                //Allocate a new network id and create the new bullet with this id
                networkView.RPC("CreateBullet", RPCMode.All, Network.AllocateViewID());
            }


            if (damage.isDead())
            {
                Network.Destroy(gameObject);
            }


        }
    }

    [RPC]
    private void CreateBullet(NetworkViewID id)
    {
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, bulletFirePosition.position, transform.rotation);
        bulletGo.networkView.viewID = id;
    }


	void FixedUpdate()
	{
		if (networkView.isMine)
		{
			//rigidbody.AddForce( (transform.forward * thrust) * Input.GetAxis("Vertical") );
            rigidbody.velocity = transform.forward * thrust * Input.GetAxis("Vertical");
		}
	}

    void OnTriggerEnter(Collider col)
    {
        if (networkView.isMine)
        {
            if (col.tag == "Bullet")
            {
                damage.hurt(1);
            }
        }
    }
}






