using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AnimationController : MonoBehaviour
{
    public Animator cameraAnimator;   // Assign Main Camera Animator
    public Animator canvasAnimator;   // Assign Canvas Animator
    public Animator droneAnimator;    // Assign Drone Animator
    public Animator droneDestroyAnimator;    // Assign Drone Destroy Animator
    public Animator enemyDroneAnimator;    // Assign Enemy Drone Animator
    public GameObject allowButton;    // Assign "Allow" Button
    public GameObject captureButton;  // Assign "Capture" Button
    public GameObject destroyedButton;  // Assign "DestroyedButton" Button
    public GameObject finalScreen;  // Assign "FinalScreen" Button
    public GameObject allowedText;  // Assign "AllowedText"
    public GameObject capturedText;  // Assign "CapturedText"
    public GameObject destroyedText;  // Assign "DestroyedText"
    public GameObject firePrefab;  // Assign "firePrefab"

    void Start()
    {
        // Start the coroutine to control the animation flow
        StartCoroutine(AnimationSequence());
    }

    IEnumerator AnimationSequence()
    {
        yield return new WaitForSeconds(4f); // Wait for 4 seconds

        // Trigger "Target" animation on Canvas and "CameraFind" animation on Camera
        canvasAnimator.SetTrigger("Target");
        cameraAnimator.SetTrigger("CameraFind");

        yield return new WaitForSeconds(2.5f); // Wait for 2:30 seconds AFTER "Target" starts

        // Show the "Allow" and "Capture" buttons
        allowButton.SetActive(true);
        captureButton.SetActive(true);
        destroyedButton.SetActive(true);
    }

    public void OnAllowClicked()
    {
        // Trigger CameraGoBack + CloseTrigger (Canvas)
        // cameraAnimator.SetTrigger("CameraGoBack");
        canvasAnimator.SetTrigger("CloseTrigger");

        // Hide buttons after clicking
        allowButton.SetActive(false);
        captureButton.SetActive(false);
        destroyedButton.SetActive(false);

        finalScreen.SetActive(true);
        allowedText.SetActive(true);
    }

    public void OnCaptureClicked()
    {
        StartCoroutine(CaptureSequence());
    }

    IEnumerator CaptureSequence()
    {
        // Trigger CameraFollowDrone + CloseTrigger (Canvas) + FlyDrone (Drone)
        cameraAnimator.SetTrigger("CameraFollowDrone");
        canvasAnimator.SetTrigger("CloseTrigger");
        droneAnimator.SetTrigger("FlyDrone");

        // Hide buttons after clicking
        allowButton.SetActive(false);
        captureButton.SetActive(false);
        destroyedButton.SetActive(false);

        yield return new WaitForSeconds(8.2f); // Wait for 8.2 seconds AFTER capture

        finalScreen.SetActive(true);
        capturedText.SetActive(true);
    }

    public void OnDestroyClicked()
    {
        StartCoroutine(DestroySequence());
    }

    IEnumerator DestroySequence()
    {
        // Trigger CameraFollowDrone + CloseTrigger (Canvas) + FlyDrone (Drone)
        cameraAnimator.SetTrigger("CameraFollowDrone");
        canvasAnimator.SetTrigger("CloseTrigger");
        droneDestroyAnimator.SetTrigger("FlyDrone");

        // Hide buttons after clicking
        allowButton.SetActive(false);
        captureButton.SetActive(false);
        destroyedButton.SetActive(false);

        yield return new WaitForSeconds(6.12f); // Wait for 6.2 seconds AFTER capture

        firePrefab.SetActive(true);
        droneDestroyAnimator.SetTrigger("Destroy");

        yield return new WaitForSeconds(3f); // Wait for 2.2 seconds AFTER capture

        firePrefab.SetActive(false);
        finalScreen.SetActive(true);
        capturedText.SetActive(true);
    }
}
