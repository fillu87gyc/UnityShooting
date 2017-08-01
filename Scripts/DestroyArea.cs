using UnityEngine;

public class DestroyArea : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		Destroy(collision.gameObject);
	}
}