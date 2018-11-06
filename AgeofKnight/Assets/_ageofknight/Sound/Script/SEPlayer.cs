using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SEPlayer : MonoBehaviour {

	
	[SerializeField] AudioClip ArrowShot;
	[SerializeField] AudioClip ArrowFallDown;
	[SerializeField] AudioClip ArrowWater1;
	[SerializeField] AudioClip ArrowWater2;
	[SerializeField] AudioClip HitStone;
	[SerializeField] AudioClip HitConcrete;
	[SerializeField] AudioClip HitGood1;
	[SerializeField] AudioClip HitGood2;
	[SerializeField] AudioClip HitGood2_2;
	[SerializeField] AudioClip Wood1;
	[SerializeField] AudioClip Wood2;
	private AudioSource audio = new AudioSource( );

	private void Start()
	{
		audio = gameObject.GetComponent<AudioSource>( );
	}

	private void OnCollisionEnter(Collision collision)
	{
		switch(collision.gameObject.tag) {
			case "water"   : audio.clip = ArrowWater1;    ;break; //噴水
			case "wood"    : audio.clip = Wood1;          ;break; //木
			case "good"    : audio.clip = HitGood1;       ;break; //的
			case "floor"   : audio.clip = ArrowFallDown;  ;break; //床
			case "stone"   : audio.clip = HitStone;       ;break; //石
			case "concrete": audio.clip = HitConcrete;    ;break; //コンクリ
			case "arrow"   : audio.clip = Wood2;          ;break; //弓矢
			default        :							  ;break;
		}
		audio.Play( );
	}

	public void shot( ) {
		audio.clip = ArrowShot;
		audio.Play( );
	}
}
