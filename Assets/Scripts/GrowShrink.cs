using UnityEngine;
using System.Collections;
using System.Threading;
	
public class GrowShrink : MonoBehaviour {
	public bool isLarge = true;
	//Do the growing/shrinking
	void doGrowShrink(bool sizeIsLarge) {
		if (sizeIsLarge == true) {
			if (transform.localScale.x < 80F) {
				transform.localScale += new Vector3(1F,1F,1F);
			}
			else {
			}
		}
		if (sizeIsLarge == false) {
			if (transform.localScale.x > 1F) {
				transform.localScale -= new Vector3(1F,1F,1F);
			}
			else {
			}
		}
	}
	//Check for Q and if so, toggle isLarge
	void FixedUpdate() {
		if (Input.GetKeyDown("q")) {
			print("Changing size");
			isLarge = !isLarge;
		}
		doGrowShrink(isLarge);
	}
}