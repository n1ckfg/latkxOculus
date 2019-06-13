﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(GvrTrackedController))]
public class Oculus_NewController : MonoBehaviour {

    public bool triggerPressed = false;
    public bool padPressed = false;
    public bool gripped = false;
    public bool menuPressed = false;
    public bool triggerDown = false;
    public bool padDown = false;
    public bool gripDown = false;
    public bool menuDown = false;
    public bool triggerUp = false;
    public bool padUp = false;
    public bool gripUp = false;
    public bool menuUp = false;

    public bool padDirUp = false;
    public bool padDirDown = false;
    public bool padDirLeft = false;
    public bool padDirRight = false;
    public bool padDirCenter = false;

    public Vector2 touchpad = new Vector2(0f, 0f);

    [HideInInspector] public Vector3 startPos = Vector3.zero;
    [HideInInspector] public Vector3 endPos = Vector3.zero;
    [HideInInspector] public float triggerVal;

    private OVRInput.Controller ctl;

    private float touchPadLimit = 0.6f; // 0.7f;

    private void Awake() {
        ctl = GetComponent<OVRInput.Controller>();
		OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, ctl);
	}

    private void Update() {
        resetButtons();
		//checkTriggerVal();
		//checkPadDir();

		if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, ctl)) {
            triggerPressed = true;
            triggerDown = true;
            startPos = transform.position;
        } else if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger, ctl)) {
            triggerPressed = false;
            triggerUp = true;
            endPos = transform.position;
        }

		/*
        if (OVRInput.Get(OVRInput.Button.Down, ctl)) {
            padPressed = true;
            padDown = true;
        } else if (OVRInput.Get(OVRInput.Button.Up, ctl)) {
            padPressed = false;
            padUp = true;
        }

        if (OVRInput.Get(OVRInput.Button.Down, ctl)) {
            gripped = true;
            gripDown = true;
        } else if (OVRInput.Get(OVRInput.Button.Up, ctl)) {
            gripped = false;
            gripUp = true;
        }

        if (OVRInput.Get(OVRInput.Button.Down, ctl)) {
            menuPressed = true;
            menuDown = true;
        } else if (OVRInput.Get(OVRInput.Button.Up, ctl)) {
            menuPressed = false;
            menuUp = true;
        }
    */

	}

	private void resetButtons() {
        triggerDown = false;
        padDown = false;
        gripDown = false;
        menuDown = false;
        triggerUp = false;
        padUp = false;
        gripUp = false;
        menuUp = false;

        padDirUp = false;
        padDirDown = false;
        padDirLeft = false;
        padDirRight = false;
        padDirCenter = true;
    }

    //private void checkTriggerVal() {
        //triggerVal = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger).x;
    //}

    /*
    private void checkPadDir() {
        touchpad = ctl.ControllerInputDevice.TouchPos; //device.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0);

        if (touchpad.y > touchPadLimit) {
            padDirUp = true;
            padDirDown = false;
            padDirCenter = false;
        } else if (touchpad.y < -touchPadLimit) {
            padDirUp = false;
            padDirDown = true;
            padDirCenter = false;
        }

        if (touchpad.x > touchPadLimit) {
            padDirLeft = true;
            padDirRight = false;
            padDirCenter = false;
        } else if (touchpad.x < -touchPadLimit) {
            padDirLeft = false;
            padDirRight = true;
            padDirCenter = false;
        }
    }
	*/

    /*
    float defaultVibrationVal = 2f;

    public void vibrateController() {
        int ms = (int)defaultVibrationVal * 1000;
        device.TriggerHapticPulse((ushort)ms, Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad);
    }

    public void vibrateController(float val) {
        int ms = (int)val * 1000;
        device.TriggerHapticPulse((ushort)ms, Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad);
    }
    */

}
