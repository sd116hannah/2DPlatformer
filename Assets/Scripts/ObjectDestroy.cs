using UnityEngine;

public class ObjectDestroy : MonoBehaviour
{
    public float objectDuration = 5f;

    void Start()
    {
        Destroy(gameObject, objectDuration);
    }
}
