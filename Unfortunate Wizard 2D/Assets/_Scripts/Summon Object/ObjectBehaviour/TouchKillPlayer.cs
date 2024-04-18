using UnityEngine;

/// <summary>
/// Enemies have this so that they can't kill themselves
/// </summary>
public class TouchKillPlayer : TouchKill
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            EventManager.onKillPlayer.Invoke();
        }
    }
}