using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : MonoBehaviour
{
	public GameObject[] waves;
	int currentWave;
	Manager manager;
	// Use this for initialization
	IEnumerator Start()
	{
		if (waves.Length == 0)
		{
			yield break;
		}
		manager = FindObjectOfType<Manager>();
		while (true)
		{
			while (manager.IsPlaying() == false)
			{
				yield return new WaitForEndOfFrame();
			}

			GameObject wave = (GameObject)Instantiate(waves[currentWave], transform.position, Quaternion.identity);
			wave.transform.parent = transform;

			while (wave.transform.childCount != 0)
			{
				//次のフレームまで待機
				yield return new WaitForEndOfFrame();
			}

			Destroy(wave);
			currentWave++;

			if (waves.Length <= currentWave)
			{
				currentWave = 0;
			}
		}
	}

	// Update is called once per frame
	void Update()
	{

	}
}
