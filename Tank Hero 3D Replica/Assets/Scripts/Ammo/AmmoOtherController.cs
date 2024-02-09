using UnityEngine;

public class AmmoOtherController : MonoBehaviour
{
    private GameDataManager GameDataManager;

    private void Start()
    {
        GameDataManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameDataManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BarrierBlock")&&other.gameObject.activeSelf!=false)
        {
            other.GetComponent<BarrierBlockController>().ReduceHealth(GameDataManager.GameData.AmmoDamageValue);
            gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Wall"))
        {
            gameObject.SetActive(false);
        }
    }
}
