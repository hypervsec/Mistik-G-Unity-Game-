using UnityEngine;

public class CarEnterExitFinal : MonoBehaviour
{
    [Header("Points")]
    public Transform seatPoint;
    public Transform exitPoint;

    [Header("Player")]
    public GameObject player;
    public MonoBehaviour playerMove;
    public MonoBehaviour playerLook;
    public Camera playerCamera;

    [Header("Car")]
    public Camera carCamera;
    public SimpleCarMove carMove;

    bool inRange = false;
    bool driving = false;

    void Start()
    {
        carCamera.enabled = false;
    }

    void Update()
    {
        // E ile İNME → her zaman çalışır
        if (driving && Input.GetKeyDown(KeyCode.E))
        {
            ExitCar();
            return;
        }

        // E ile BİNME → sadece trigger içindeyken
        if (inRange && !driving && Input.GetKeyDown(KeyCode.E))
        {
            EnterCar();
        }
    }

    void EnterCar()
    {
        driving = true;

        playerMove.enabled = false;
        playerLook.enabled = false;

        player.transform.SetParent(seatPoint);
        player.transform.localPosition = Vector3.zero;
        player.transform.localRotation = Quaternion.identity;

        playerCamera.enabled = false;
        carCamera.enabled = true;

        carMove.enabled = true;
    }

    void ExitCar()
    {
        driving = false;

        carMove.enabled = false;

        player.transform.SetParent(null);
        player.transform.position = exitPoint.position;

        carCamera.enabled = false;
        playerCamera.enabled = true;

        playerMove.enabled = true;
        playerLook.enabled = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
            inRange = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
            inRange = false;
    }
}
