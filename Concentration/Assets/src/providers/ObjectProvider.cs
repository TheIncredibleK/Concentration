using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ObjectProvider  {


    public static GameObject ProvidePlayer()
    {
        return ProvideSingleGameObjectWithTag(Constants.Tags.PLAYER);
    }

    public static PrefabProvider ProvidePrefabProvider()
    {
        return ProvideSingleGameObjectWithTag(Constants.Tags.PLAYER).GetComponent<PrefabProvider>();
    }


    private static GameObject ProvideSingleGameObjectWithTag(string tag)
    {
        var allObjects = GameObject.FindGameObjectsWithTag(tag);

        if (allObjects.Length > 1)
        {
            throw new System.ArgumentException("Cannot have more than 1 object with tag" + tag +", found " + allObjects.Length.ToString());
        }

        return allObjects[0];
    }

}
