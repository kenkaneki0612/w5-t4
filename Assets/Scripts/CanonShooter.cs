using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanonShooter : MonoBehaviour
{
    [SerializeField] private GameObject canonBall;
    [SerializeField] private Transform shotPoint;
    [SerializeField] private Slider powerBar;

    public float sensitivity;
    private float shotPower;
    public int ballCount;

    private void Start()
    {
        ballCount = 10;
    }
    // Update is called once per frame
    void Update()
    {
        ChargePowerBar();
        ReleaseCharge();
    }

    void ChargePowerBar()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0))
        {
            powerBar.value += Time.deltaTime * sensitivity;
        }
    }

    void ReleaseCharge()
    {
        if (ballCount > 0)
        {
            if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.Mouse0))
            {
                GameObject newCanonBall = Instantiate(canonBall, shotPoint.position, shotPoint.rotation);
                ballCount--;
                newCanonBall.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, powerBar.value), ForceMode.Impulse);
                powerBar.value = 0; 
            }
        }
    }

    public int GetBallLeft()
    {
        return ballCount;
    }
}
