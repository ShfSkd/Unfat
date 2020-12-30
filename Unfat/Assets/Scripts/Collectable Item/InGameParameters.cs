using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameParameters : MonoBehaviour
{
	[SerializeField] Button inGameDebbugButton;
	[SerializeField] Button closeButton;
	[SerializeField] Image inGameDebbugImage = null;



    [SerializeField] Text xSpeedText;
    [SerializeField] Slider xSpeedSlider;
    [SerializeField] Slider zSpeedSlider;
    [SerializeField] Text zSpeedText;

    [SerializeField] Text zMaxSpeedText;
    [SerializeField] Slider zMaxSpeedSlider;

    [Header("Camera Values")]
	CameraMovement cam;
    [SerializeField] Slider camPosX;
    [SerializeField] Text camPosX_Text;
    [SerializeField] Slider camPosY;
    [SerializeField] Text camPosY_Text;
    [SerializeField] Slider camPosZ;
    [SerializeField] Text camPosZ_Text;

    PlayerController controller;

	private void Start()
	{
		cam=FindObjectOfType<CameraMovement>();

		controller = FindObjectOfType<PlayerController>();

		inGameDebbugImage.gameObject.SetActive(false);
		closeButton.gameObject.SetActive(false);
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

    public void MaxZSpeed(float maxZ)
	{
		if (controller != null)
		{
            controller._sensitivity = maxZ;
		}
		if (zMaxSpeedSlider != null)
		{
            zMaxSpeedSlider.value = maxZ;
		}
		if (zMaxSpeedText != null)
		{
            zMaxSpeedText.text = maxZ.ToString();
		}
	}
    public void CameraValues(Vector3 camera)
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
	}

	public void Close()
	{
		inGameDebbugImage.gameObject.SetActive(false);
		closeButton.gameObject.SetActive(false);

		Time.timeScale = 1f;
	}


}
