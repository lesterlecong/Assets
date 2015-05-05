using UnityEngine;
using System.Collections;

public class PowerManager : MonoBehaviour {

	public LightningCreator[] lightnings;
	

	public void switchPower(string powertype){
		for (int index = 0; index < lightnings.Length; index++) {
			if(lightnings[index].tag == powertype){
				lightnings[index].gameObject.SetActive(!lightnings[index].gameObject.activeInHierarchy);
				Debug.Log("Switch: " + lightnings[index].tag + " to:" + lightnings[index].gameObject.activeInHierarchy);
				break;
			}
		}
	}
}
