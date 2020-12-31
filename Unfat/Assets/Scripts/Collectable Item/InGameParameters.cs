using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameParameters : MonoBehaviour
{
	[Header("In Game UI")]
	[SerializeField] Button inGameDebbugButton;
	[SerializeField] Button closeButton;
	[SerializeField] Image inGameDebbugImage = null;


	[Header("Player Movement")]
    [SerializeField] Text xSpeedText;
    [SerializeField] Slider xSpeedSlider;
    [SerializeField] Slider clampDeltaSlider;
    [SerializeField] Text clampDeltaText;
    [SerializeField] Text zSpeedText;
    [SerializeField] Slider zSpeedSlider;

    [Header("Camera Values")]
    [SerializeField] Slider camPosX;
    [SerializeField] Text camPosX_Text;
    [SerializeField] Slider camPosY;
    [SerializeField] Text camPosY_Text;
    [SerializeField] Slider camPosZ;
    [SerializeField] Text camPosZ_Text;

	CameraMovement cam;
    PlayerController controller;

	private void Start()
	{
		cam=FindObjectOfType<CameraMovement>();

		controller = FindObjectOfType<PlayerController>();

		inGameDebbugImage.gameObject.SetActive(false);
		closeButton.gameObject.SetActive(false);

		camPosZ.value = cam.offset.z;
		camPosY.value = cam.offset.y;
		camPosX.value = cam.offset.x;
	}
	public void OpenDebugUI()
	{
		if (inGameDebbugButton)
		{
			
			inGameDebbugImage.gameObject.SetActive(true);
			closeButton.gameObject.SetActive(true);
			Time.timeScale = 0f;

		}
	}

    public void Speed(float maxZ)
	{
		if (controller != null)
		{
            controller._sensitivity = maxZ;
		}
		if (zSpeedSlider != null)
		{
            zSpeedSlider.value = maxZ;
		}
		if (zSpeedText != null)
		{
            zSpeedText.text = maxZ.ToString();
		}
	}
	public void ClampData(float clamp)
	{
		if (controller != null)
		{
			controller._clampDelta = clamp;
		}
		if (clampDeltaSlider != null)
		{
			clampDeltaSlider.value = clamp;
		}
		if (clampDeltaText != null)
		{
			clampDeltaText.text = clamp.ToString();
		}
	}
	

   /* public void CameraValues(Vector3 camera)
	{
		if (cam != null)
		{
            cam._cameraVelocity.x = camera.x;
            cam._cameraVelocity.y = camera.y;
            cam._cameraVelocity.z = camera.z;

		}
		if (camPosX != null)
		{
            camPosX.value = camera.x;
		}
		if (camPosX_Text != null)
		{
			camPosX_Text.text = camera.x.ToString();
		}
		if (camPosY != null)
		{
            camPosY.value = camera.y;
		}
		if (camPosY_Text != null)
		{
			camPosY_Text.text = camera.y.ToString();
		}
		if (camPosZ != null)
		{
			camPosZ.value = camera.z;
		}
		if (camPosZ_Text != null)
		{
			camPosZ_Text.text = camera.z.ToString();
		}
	}*/
   public void CamX(float x)
	{
		if (cam != null)
		{
			cam.offset.x = x;
		}
		if (camPosX != null)
		{
			camPosX.value = x;
		}
		if (camPosX_Text != null)
		{
			camPosX_Text.text = x.ToString();
		}
	}
	public void CamY(float y)
	{
		if (cam != null)
		{
			cam.offset.y = y;
		}
		if (camPosY != null)
		{
			camPosY.value = y;
		}
		if (camPosY_Text != null)
		{
			camPosY_Text.text = y.ToString();
		}
	}
	public void CamZ(float z)
	{
		if (cam != null)
		{
			cam.offset.z = z;
		}
		if (camPosZ != null)
		{
			camPosZ.value = z;
		}
		if (camPosZ_Text != null)
		{
			camPosZ_Text.text = z.ToString();
		}
	}



	public void Close()
	{
		inGameDebbugImage.gameObject.SetActive(false);
		closeButton.gameObject.SetActive(false);

		Time.timeScale = 1f;
	}


}
