using UnityEngine;
using System.Collections;

public class Bugs : MonoBehaviour
{
    //1) player bullet loses all velocity when player is killed & error message pops up (Recreated twice)
    //2) player's consecutive bullets not equal distance
    //NOT-A-BUG) when 2 directional buttons are pressed at the same time, player does not move (but only for arrow keys?, is this computer problem?)
    //FIXED) player bullets appear for split second at where it was deactivated
    //FIXED) Boss instantly explodes after going out of alive state
    //FIXED) boss can be defeated in spawning mode
}
