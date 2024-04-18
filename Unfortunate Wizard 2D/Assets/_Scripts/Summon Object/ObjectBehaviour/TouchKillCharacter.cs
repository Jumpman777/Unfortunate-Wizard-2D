using UnityEngine;

public class TouchKillCharacter : TouchKill
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            EventManager.onKillPlayer.Invoke();
        }
        else if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
    }
}