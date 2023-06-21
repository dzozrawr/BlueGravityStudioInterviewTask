using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ClothingBoothTrigger : MonoBehaviour
{
    public ClothingBooth boothCanvas = null;

    public Canvas actionPromptCanvas = null;
    public CinemachineVirtualCamera clothingBoothVCam = null;

    private bool isInTrigger = false;

    private GameController gameController = null;


    private void Start()
    {
        gameController = GameController.Instance;
    }

    private void Update()
    {
        if (isInTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                boothCanvas.Show(!boothCanvas.IsShown());
                actionPromptCanvas.enabled = false;
                if (boothCanvas.IsShown())
                {
                    CameraController.Instance.transitionToCMVirtualCamera(clothingBoothVCam);
                }
                else
                {
                    CameraController.Instance.transitionToCMVirtualCamera(gameController.defaultPlayerFollowCamera);
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isInTrigger = true;
        actionPromptCanvas.enabled = true;
        //also show the promt: press E to enter shop
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isInTrigger = false;

        boothCanvas.Show(false);
        actionPromptCanvas.enabled = false;

        CameraController.Instance.transitionToCMVirtualCamera(gameController.defaultPlayerFollowCamera);
    }
}
