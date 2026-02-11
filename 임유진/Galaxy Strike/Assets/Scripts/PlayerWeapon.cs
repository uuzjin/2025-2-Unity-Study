using UnityEngine;
using UnityEngine.InputSystem; 

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] GameObject[] lasers;
    [SerializeField] RectTransform crosshair;
    [SerializeField] Transform targetPoint;
    [SerializeField] float targetDistance = 100;
 
    bool isFiring = false;

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        ProcessFiring();
        MoveCrosshair();
        MoveTargetPoint();
        AimLasers();
    }

    public void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }

    void ProcessFiring()
    {
        foreach(GameObject laser in lasers)
        { 
            // ParticleSystem.EmissionModule emmissionModule
            var emmissionModule = laser.GetComponent<ParticleSystem>().emission;
            emmissionModule.enabled = isFiring;
        }
    }

    void MoveCrosshair()
    {
        crosshair.position = Mouse.current.position.ReadValue();
    }

    void MoveTargetPoint()
    {
        if (Mouse.current == null) return;

        Vector2 mousePos = Mouse.current.position.ReadValue();
        Vector3 screenPos = new Vector3(mousePos.x, mousePos.y, targetDistance);
        targetPoint.position = Camera.main.ScreenToWorldPoint(screenPos);
    }

    void AimLasers()
    {
        foreach (GameObject laser in lasers)
        {
            Vector3 fireDirection = targetPoint.position - this.transform.position; // 목표 위치 - 레이저 위치 
            Quaternion rotationToTarget = Quaternion.LookRotation(fireDirection); // 레이저를 위 벡터에 맞추도록 회전 계산 
            laser.transform.rotation = rotationToTarget;
        }
    }
}
