using UnityEngine;

public class NewBoc : MonoBehaviour
{
    private BoxCollider _childBoxCollider;

    void Start()
    {
        _childBoxCollider = GetComponentInChildren<BoxCollider>();

        if (_childBoxCollider == null)
        {
            Debug.LogError("No BoxCollider found as a child of this object.");
        }
    }

    void Update()
    {
        if (_childBoxCollider != null)
        {
            _childBoxCollider.transform.position = transform.position;
        }
    }
}
