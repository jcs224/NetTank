using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour 
{
	public float speed = 10f;
    public float lifetime = 3f;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position += speed * transform.forward * Time.deltaTime;

        if (networkView.isMine)
        {
            lifetime -= Time.deltaTime;
            if(lifetime <= 0f)
                Network.Destroy(this.gameObject);
        }
	}


	void OnTriggerEnter(Collider col)
	{
        if (networkView.isMine)
        {
            if (col.tag == "Crate")
            {
                Debug.Log("Hit");
                //Destroy(gameObject);
            }

            Network.Destroy(this.gameObject);
        }
	}
}
