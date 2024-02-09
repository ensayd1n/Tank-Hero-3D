using UnityEngine;

public class TankComponentController : MonoBehaviour
{
    [Header("Tank Components")]
    public GameObject[] TankTurrets;
    public GameObject[] TankSideTurrets;
    public GameObject[] Drons;
    public GameObject Shield;

    [HideInInspector] public int TankTurretLevel = 0;
    [HideInInspector] public int TankSideTurretLevel = 0;
    [HideInInspector] public int TankDroneLevel = 0;
}
