﻿using UnityEngine;
using System.Collections;

public class Minigame_WhackAMole_Hole : MonoBehaviour 
{
	public bool taken;
	public bool lost;
	private Minigame_WhackAMole_Mole m;
	public float score;

	private int sortingOrder;

	public GameObject molePrefab;
		
	public AudioClip squish;
	public AudioSource audio;

	public void newMole()
	{
		GameObject o = GameObject.Instantiate(molePrefab);
		o.transform.parent = transform;
		o.transform.localPosition =
			new Vector3(0,-1.2f,0);
		m = o.GetComponent<Minigame_WhackAMole_Mole>();
		m.hole = this;
		m.Init();
		taken = true;
		o.GetComponent<SpriteRenderer>().sortingOrder +=
			sortingOrder;
	}

	public void Clicked()
	{
		GameObject.Destroy(m.gameObject);
		taken = false;
		score ++;
		
		audio.PlayOneShot(squish);
	}

	public void Lost()
	{
		lost = true;
	}

	public void Sort(int i)
	{
		sortingOrder = i;
		SortingOrders(this.gameObject, i);
	}

	private void SortingOrders(GameObject o, int s)
	{
		for (int i = 0; i < o.transform.childCount; i++)
		{
			SpriteRenderer r = 
				o.transform.GetChild(i).GetComponent<SpriteRenderer>();
			if (r != null)
			{
				r.sortingOrder += s;
			}
		}
	}
}