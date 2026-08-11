using UnityEngine;
using System.Collections;

public class FreeFall : MonoBehaviour
{
    public AudioSource audioSource;
    private Vector3 initialPosition;
    private Rigidbody rb;
    private bool isInteracting = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }
        rb.useGravity = false;
        initialPosition = transform.position;
    }

    public void TiltInteract()
    {
        if (!isInteracting)
        {
            isInteracting = true;
            rb.useGravity = true;
            AudioManager.instance.PlayAudio(audioSource); // Use AudioManager
            StartCoroutine(ResetObject());
        }
    }

    IEnumerator ResetObject()
    {
        yield return new WaitForSeconds(10f);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.useGravity = false;
        rb.position = initialPosition;
        transform.rotation = Quaternion.identity;

        yield return new WaitForSeconds(1f);
        isInteracting = false;
    }
}
