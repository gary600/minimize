using UnityEngine;
using System.Collections;
	
public class GrowShrink : MonoBehaviour {
	public bool isLarge = false;
	void Update() {
		if (Input.GetKeyDown("q")) {
			if (isLarge == true) {
				transform.localScale = new Vector3(1F,1F,1F);
				isLarge = false;
				print ("Scaled to small");
			}
			else {
				transform.localScale = new Vector3(60F,60F,60F);
				isLarge = true;
				print ("Scaled to large");
			}
		}
	}
}