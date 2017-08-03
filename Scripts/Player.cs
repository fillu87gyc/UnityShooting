using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	// Spaceshipコンポーネント
	Spaceship spaceship;

	IEnumerator Start()
	{
		// Spaceshipコンポーネントを取得
		spaceship = GetComponent<Spaceship>();

		while (true)
		{

			// 弾をプレイヤーと同じ位置/角度で作成
			spaceship.Shot(transform);

			GetComponent<AudioSource>().Play();

			// 0.05秒待つ
			yield return new WaitForSeconds(spaceship.shotDelay);
		}
	}

	void Update()
	{
		// 右・左
		float x = Input.GetAxisRaw("Horizontal");

		// 上・下
		float y = Input.GetAxisRaw("Vertical");

		// 移動する向きを求める
		Vector2 direction = new Vector2(x, y).normalized;

		// 移動
		Move(direction);
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		string LayerName = LayerMask.LayerToName(collision.gameObject.layer);
		if (LayerName == "Bullet(Enemy)")
			Destroy(collision.gameObject);

		if (LayerName == "Bullet(Enemy)" || LayerName == "Enemy") {
			spaceship.Explosion();
			Destroy(this.gameObject);
		}
	}
	void Move(Vector2 dir)
	{
		Vector2 Min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
		Vector2 Max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
		Vector2 pos = transform.position;

		pos += dir * spaceship.speed * Time.deltaTime;

		pos.x = Mathf.Clamp(pos.x, Min.x, Max.x);
		pos.y = Mathf.Clamp(pos.y, Min.x, Max.y);

		transform.position = pos;
		return;
	}
}