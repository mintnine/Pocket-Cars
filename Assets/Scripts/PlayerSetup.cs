﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour {

	[SerializeField]
	private Behaviour[] componentsToDisable;

	void Start(){
		if (!isLocalPlayer) {
			for (int i = 0; i < componentsToDisable.Length; i++) {
				componentsToDisable [i].enabled = false;

			}
		} else {
			Camera.main.gameObject.SetActive (false);
		}
	}


}
