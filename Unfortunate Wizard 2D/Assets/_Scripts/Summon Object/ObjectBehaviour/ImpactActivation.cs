using System.Collections;
using UnityEngine;

public class ImpactActivation : ObjectBehaviour
{
    [SerializeField, Tooltip("Has to be nested in the GameObject with this script.")] 
    private GameObject objectToActivate;

    private void Awake()
    {
        objectToActivate.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        objectToActivate.SetActive(true);
        StartCoroutine(DeactivateAfterTime());
    }

    IEnumerator DeactivateAfterTime()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}