using UnityEngine;
using System.Collections;

public class fov_human : MonoBehaviour {


	public Camera mainCam;
	public Transform mainCamTransform;
	public float horizontalFOV = 58;
	public float downFov = 67;
	public float UpFov = 53;



	private float cameraEngle;


	private float FinalFov;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		cameraEngle = mainCamTransform.localEulerAngles.x;

		if (cameraEngle > 0.035f && cameraEngle < 90.0f ) 
		{
			FinalFov = Mathf.Lerp (horizontalFOV, downFov, cameraEngle / 90.0f);
			
		}

		if (cameraEngle > 269.0f && cameraEngle < 359.995f ) 
		{
			FinalFov = Mathf.Lerp ( UpFov,horizontalFOV, cameraEngle / 360.0f);

		}

		mainCam.fieldOfView = FinalFov;

	
	}
}
