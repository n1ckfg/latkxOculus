// https://docs.unity3d.com/Manual/OculusControllers.html
// https://developer.oculus.com/documentation/unity/latest/concepts/unity-ovrinput/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oculus_NewController : MonoBehaviour {

	// primary = left
	public enum CtlMode { LEFT, RIGHT };
	public CtlMode ctlMode = CtlMode.LEFT;

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

    public bool extra1Pressed = false;
    public bool extra1Down = false;
    public bool extra1Up = false;

    public bool padDirUp = false;
    public bool padDirDown = false;
    public bool padDirLeft = false;
    public bool padDirRight = false;
    public bool padDirCenter = false;

    public Vector2 touchpad = new Vector2(0f, 0f);

    [HideInInspector] public Vector3 startPos = Vector3.zero;
    [HideInInspector] public Vector3 endPos = Vector3.zero;
    [HideInInspector] public float triggerVal;
    
    private float touchPadLimit = 0.6f; // 0.7f;

    private void Update() {
        resetButtons();
		checkTriggerVal();
		checkPadDir();

		if (ctlMode == CtlMode.LEFT) { 
            // trigger
			if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)) {
	            triggerPressed = true;
	            triggerDown = true;
	            startPos = transform.position;
	        } else if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger)) {
	            triggerPressed = false;
	            triggerUp = true;
	            endPos = transform.position;
	        }

            // grip
			if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger)) {
				gripped = true;
				gripDown = true;
			} else if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger)) {
				gripped = false;
				gripUp = true;
			}

            // X button
	        if (OVRInput.GetDown(OVRInput.Button.Three)) {
	            padPressed = true;
	            padDown = true;
	        } else if (OVRInput.GetUp(OVRInput.Button.Three)) {
	            padPressed = false;
	            padUp = true;
	        }

            // Y button
	        if (OVRInput.GetDown(OVRInput.Button.Four)) {
	            menuPressed = true;
	            menuDown = true;
	        } else if (OVRInput.GetUp(OVRInput.Button.Four)) {
				menuPressed = false;
				menuUp = true;
			}

            // thumbstick press
            if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstick)) {
                extra1Pressed = true;
                extra1Down = true;
            } else if (OVRInput.GetUp(OVRInput.Button.PrimaryThumbstick)) {
                extra1Pressed = false;
                extra1Up = true;
            }
		} else {
            // trigger
			if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger)) {
				triggerPressed = true;
				triggerDown = true;
				startPos = transform.position;
			} else if (OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger)) {
				triggerPressed = false;
				triggerUp = true;
				endPos = transform.position;
			}

            // grip
			if (OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger)) {
				gripped = true;
				gripDown = true;
			} else if (OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger)) {
				gripped = false;
				gripUp = true;
			}

            // A button
			if (OVRInput.GetDown(OVRInput.Button.One)) {
				padPressed = true;
				padDown = true;
			} else if (OVRInput.GetUp(OVRInput.Button.One)) {
				padPressed = false;
				padUp = true;
			}

            // B button
			if (OVRInput.GetDown(OVRInput.Button.Two)) {
				menuPressed = true;
				menuDown = true;
			} else if (OVRInput.GetUp(OVRInput.Button.Two)) {
				menuPressed = false;
				menuUp = true;
			}

            // thumbstick press
            if (OVRInput.GetDown(OVRInput.Button.SecondaryThumbstick)) {
                extra1Pressed = true;
                extra1Down = true;
            } else if (OVRInput.GetUp(OVRInput.Button.SecondaryThumbstick)) {
                extra1Pressed = false;
                extra1Up = true;
            }
		}
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

        extra1Down = false;
        extra1Up = false;

        padDirUp = false;
        padDirDown = false;
        padDirLeft = false;
        padDirRight = false;
        padDirCenter = true;
    }

    private void checkTriggerVal() {
        if (ctlMode == CtlMode.LEFT) {
            triggerVal = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger);
        } else {
            triggerVal = OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger);
        }
    }

    private void checkPadDir() {
        if (ctlMode == CtlMode.LEFT) {
            touchpad = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        } else {
            touchpad = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
        }

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
