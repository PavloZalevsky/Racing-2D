using UnityEngine;
using System.Collections;

public class SettingsScript : MonoBehaviour {

    [Header("Pleyer")]
    public int SpeedPleyer;
    public int NitroSpeedPleyer;
    public float NitroTimePleyer;

    [Header("enemy Zombie")]
    public int SpeedZombie;
    public int NitroSpeedZombie;
    public float NitroTimeZombie;

    [Header("enemy Girl")]
    public int SpeedGirl;
    public int NitroSpeedGirl;
    public float NitroTimeGirl;

    private EnemyCarScript girlCar;
    private EnemyCarScript zombieCar;
    private PleyerCarScript playerCar;

    void Awake()
    {

        playerCar = GameObject.Find("CarPlayer").GetComponentInChildren<PleyerCarScript>();
        zombieCar = GameObject.Find("EnemycarZombie").GetComponentInChildren<EnemyCarScript>();
        girlCar = GameObject.Find("EnemycarGirl").GetComponentInChildren<EnemyCarScript>();

        playerCar.Speed = SpeedPleyer;
        playerCar.NitroSpeed = NitroSpeedPleyer;
        playerCar.NitroTime = NitroTimePleyer;

        zombieCar.Speed = SpeedZombie;
        zombieCar.NitroSpeed = NitroSpeedZombie;
        zombieCar.NitroTime = NitroTimeZombie;

        girlCar.Speed = SpeedGirl;
        girlCar.NitroSpeed = NitroSpeedGirl;
        girlCar.NitroTime = NitroTimeGirl;

        Physics2D.IgnoreLayerCollision(9, 10); // ігнори між машинками
        Physics2D.IgnoreLayerCollision(9, 9);
    }

}
