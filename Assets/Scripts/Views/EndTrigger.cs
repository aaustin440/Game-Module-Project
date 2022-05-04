
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public playerScript playerScript2;

    public void OnTriggerEnter()
    {
        playerScript2.GameWon();
    }
}
