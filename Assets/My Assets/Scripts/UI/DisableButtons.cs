using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisableButtons : MonoBehaviour 
{
    public Button NormalButton;
    public Button EndlessButton;

	public void DisableAllButtons()
    {
        NormalButton.interactable = false;
        EndlessButton.interactable = false;
    }
}
