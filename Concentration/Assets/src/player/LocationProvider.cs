using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LocationProvider  {


    // Move these to configuration //
    static float PlayerPositionOffsetMultiplier = 1.5f;

    public static List<Vector3> ProvideLocations(int numberOfLocations, GameObject player)
    {
        var centreOfCamera = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        var cameraSizeVector = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
        var horizontalSizeOfCamera = cameraSizeVector.x * 2.0f;
        var verticalSizeOfCamera = cameraSizeVector.y * 2.0f;

        var distanceBetweenLocations = horizontalSizeOfCamera / player.transform.localScale.y / 2.0f;

        var listOfLocations = new List<Vector3>();
        for(int i = 0; i < numberOfLocations; i++)
        {
            var newLocationToAdd = new Vector3();
        }
        return null;
    }

    public static Vector3 Test(Transform originalTransform)
    {
        var centreOfCamera = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        var cameraSizeVector = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
        var horizontalSizeOfCamera = cameraSizeVector.x * 2.0f;
        var verticalSizeOfCamera = cameraSizeVector.y * 2.0f;

        var bottomLeftOfScreen = new Vector3(centreOfCamera.x + originalTransform.localScale.x * PlayerPositionOffsetMultiplier, centreOfCamera.y + originalTransform.localScale.y * PlayerPositionOffsetMultiplier, centreOfCamera.z);

        var bottomOfScreenY = 0;
        var vec = new Vector3(0, bottomOfScreenY, centreOfCamera.z);
        vec = bottomLeftOfScreen;
        return UnchangedZ(vec, originalTransform);
    }

    private static Vector3 UnchangedZ(Vector3 newLocation, Transform transform)
    {
        return new Vector3(newLocation.x, newLocation.y, transform.position.z);
    }
}
