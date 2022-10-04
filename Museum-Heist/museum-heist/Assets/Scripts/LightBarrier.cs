using UnityEngine;

public class LightBarrier : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        other.gameObject.GetComponent<ThiefAgent>().OnLightBarrierTriggered();
    }
}
