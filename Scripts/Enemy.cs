using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
	// Spaceshipコンポーネント
	Spaceship spaceship;
	IEnumerator Start()
	{

		// Spaceshipコンポーネントを取得
		spaceship = GetComponent<Spaceship>();

		// ローカル座標のY軸のマイナス方向に移動する
		Move(transform.up * -1);
		if (!spaceship.canShot) yield break;

		while (true)
		{

			// 子要素を全て取得する
			for (int i = 0; i < transform.childCount; i++)
			{
				spaceship.Shot(transform.GetChild(i));
			}

			yield return new WaitForSeconds(spaceship.shotDelay);
		}
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (LayerMask.LayerToName(collision.gameObject.layer) == "Bullet(Player)")
		{
			Destroy(collision.gameObject);
			spaceship.Explosion();
			Destroy(this.gameObject);
		}
	}
	void Move(Vector2 dir)
	{
		GetComponent<Rigidbody2D>().velocity = dir * spaceship.speed;
	}
}