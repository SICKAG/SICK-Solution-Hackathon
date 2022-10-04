using UnityEngine;

public class Artifact : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        //Destroy(gameObject);
        gameObject.SetActive(false);
        other.gameObject.GetComponent<ThiefAgent>().OnArtifactCollected();
    }
}
