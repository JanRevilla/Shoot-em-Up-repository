
using UnityEngine;

public class SensePlatform : MonoBehaviour
{
    private void OnTriggerExit2D (Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), other.GetComponent<Collider2D>(), false);
        }
    }
}
