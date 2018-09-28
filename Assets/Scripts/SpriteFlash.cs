using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlash : MonoBehaviour {

	public float flashSpeed;

	Material mat;

	bool isFlashing = false;

	private void Awake() {
		mat = GetComponent<SpriteRenderer>().material;
	}

	private void Update() {
		if(Input.GetKeyDown(KeyCode.Space))
			Flash();
	}

	private void Flash(){
		StartCoroutine(DoFlash());
	}

	IEnumerator DoFlash(){
		isFlashing = false;
		yield return new WaitForEndOfFrame();
		isFlashing = true;
		float flash = 1f;
		while (isFlashing && flash >=0)
		{
			flash -= Time.deltaTime * flashSpeed;
			mat.SetFloat("_FlashAmount", flash);
			yield return null;
		}
		isFlashing = false;
	}
}
