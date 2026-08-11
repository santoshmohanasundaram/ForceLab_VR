using UnityEngine;
using System.Collections;

public class force11 : MonoBehaviour
{
    public AudioSource audiof;
    private Vector3 initialPosition;
    private Rigidbody rb;
    private bool isInteracting = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogWarning("No Rigidbody found on the object!");
        }
        initialPosition = transform.position;
    }

    public void TiltInteract()
    {
        if (!isInteracting)
        {
            isInteracting = true;
            rb.AddForce(Vector3.back * 55f, ForceMode.Force);
            AudioManager.instance.PlayAudio(audiof); // Use AudioManager
            StartCoroutine(ResetObject());
        }
    }

    IEnumerator ResetObject()
    {
        yield return new WaitForSeconds(10f);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.position = initialPosition;
        transform.rotation = Quaternion.identity;

        yield return new WaitForSeconds(1f);
        isInteracting = false;
    }
}
