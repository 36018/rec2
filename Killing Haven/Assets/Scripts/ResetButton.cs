using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ResetButton : MonoBehaviour
{
    public void ButtonClick()
    {
        List<GameReset> objects = new List<GameReset>(Resources.FindObjectsOfTypeAll<MonoBehaviour>().OfType<GameReset>());
        foreach (var _object in objects)
        {
            _object.ResetGame();
        }
        GameObject.Find("Spawner").GetComponent<Spawner>().Restart();
    }
}
