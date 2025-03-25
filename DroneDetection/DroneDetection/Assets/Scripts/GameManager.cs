using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshPro enemyDroneLabel; // Assign in Inspector

    void Start()
    {
        string droneId = GetDroneIdFromURL();
        if (!string.IsNullOrEmpty(droneId))
        {
            DisplayDroneId(droneId);
        }
    }

    private string GetDroneIdFromURL()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        string url = Application.absoluteURL;
        if (string.IsNullOrEmpty(url)) return null;

        Uri uri = new Uri(url);
        string query = uri.Query;
        var queryParams = System.Web.HttpUtility.ParseQueryString(query);
        return queryParams["droneId"];
#else
        return "TestDrone123"; // Fallback for testing in Unity Editor
#endif
    }

    private void DisplayDroneId(string droneId)
    {
        Debug.Log("Received Drone ID: " + droneId);

        if (enemyDroneLabel != null)
        {
            enemyDroneLabel.text = "Enemy: " + droneId;
        }
        else
        {
            Debug.LogWarning("Enemy Drone Label not assigned!");
        }
    }
}
