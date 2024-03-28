using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropdown : MonoBehaviour
{

    public static bool isPistoRighHand = true;

       public void handDropdown(int index)
    {Debug.Log(index);
        if (index == 0)
        {
            isPistoRighHand = true;
        }
        else if(index == 1)
        {
            isPistoRighHand = false;
        }

    }
}
