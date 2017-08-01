using UnityEngine;

public class Bullet : MonoBehaviour
{
	public int speed = 10;
	public float lifeTime=5.0f;
	void Start ()
	{
		GetComponent<Rigidbody2D>().velocity = transform.up.normalized * speed;
		Destroy(gameObject, lifeTime);
	}
	
}