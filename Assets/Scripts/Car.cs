using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Car : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float speedGainPerSecond = 0.2f;
    [SerializeField] float turnSpeed = 200f;
    private float steerValue;
    //private Gyroscope gyroscope;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Verificar se o giroscópio é suportado no dispositivo
        /*if (SystemInfo.supportsGyroscope)
        {
            gyroscope = Input.gyro;
            gyroscope.enabled = true;
            Debug.Log("Giroscópio ativado com sucesso!");
        }
        else
        {
            Debug.LogWarning("Este dispositivo não suporta giroscópio.");
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        speed += speedGainPerSecond * Time.deltaTime;
        transform.Rotate(0f, steerValue * turnSpeed * Time.deltaTime, 0f);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        //Captando movimentos do gyroscope
        /*if (gyroscope != null && gyroscope.enabled)
        {
            Steer(gyroscope.attitude.y);
            Debug.Log("X:" + gyroscope.rotationRateUnbiased.x + " Y:" + gyroscope.rotationRateUnbiased.y + " Z:" + gyroscope.rotationRateUnbiased.z);
            Debug.Log("X:" + gyroscope.rotationRate.x + " Y:" + gyroscope.rotationRate.y + " Z:" + gyroscope.rotationRate.z);
            Debug.Log("X:" + gyroscope.attitude.x + " Y:" + gyroscope.attitude.y + " Z:" + gyroscope.attitude.z);
        }*/
    }

    public void Steer(float value)
    {
        steerValue = value;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
