using UnityEngine;

public class ShieldController : MonoBehaviour
{
    public GameObject Shield;
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.activeSelf==true && other.gameObject.CompareTag("BarrierBlock") && other.gameObject.activeSelf!=false)
        {
            other.gameObject.SetActive(false);
            Shield.SetActive(false);
        }
    }
}
