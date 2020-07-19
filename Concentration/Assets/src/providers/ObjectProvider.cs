using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ObjectProvider  {


    public static GameObject ProvidePlayer()
    {
        var allPlayerObjects = GameObject.FindGameObjectsWithTag(Constants.Tags.PLAYER);

        if(allPlayerObjects.Length > 1)
        {
            throw new System.ArgumentException("Cannot have more than 1 player objects, found " + allPlayerObjects.Length.ToString());
        }

        return allPlayerObjects[0];
    }

}
