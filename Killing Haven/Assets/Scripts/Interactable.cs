using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    //message displayes to player when looking at an interactable
    public string promptMessage;

    // Start is called before the first frame update
    public void BaseInteract()
    {
        Interact();
    }

    protected virtual void Interact()
    {
        //we wont have any code written in this function
        //this is a template function to be overridden by our subclasses
    }
}
