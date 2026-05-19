using UnityEngine;

public class Tree : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Water"))
        {
            Destroy(gameObject);
        }
    }
}
