using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ButtomScript : MonoBehaviour
{
    // Initialize Variables
    public Sprite newleft;
    public Sprite newright;
 

    public void ChangeImageL(Image left_update)
    {
        left_update.sprite = newleft;
    }

    public void ChangeImageR(Image right_update)
    {
        right_update.sprite = newright;
    }
}
