using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentController : MonoBehaviour
{
    public GameObject snowTerrain;
    public GameObject offRoadTerrain;
    public GameObject cityTerrain;
    public GameObject showroomTerrain;
    public Material nightSky;
    public Material daySky;
    public Light sunLight;

    public GameObject car;
    private Transform carPosition;

    public void Start()
    {
        RenderSettings.skybox = daySky;
        sunLight.color = Color.white;
        carPosition = car.GetComponent<Transform>();
    }
    public void Snow()
    {
        snowTerrain.gameObject.SetActive(true);
        offRoadTerrain.gameObject.SetActive(false);
        cityTerrain.gameObject.SetActive(false);
        showroomTerrain.gameObject.SetActive(false);
        ResetCarTransform();
    }
    public void Offroad()
    {
        snowTerrain.gameObject.SetActive(false);
        offRoadTerrain.gameObject.SetActive(true);
        cityTerrain.gameObject.SetActive(false);
        showroomTerrain.gameObject.SetActive(false);
        ResetCarTransform();
    }
    public void City()
    {
        snowTerrain.gameObject.SetActive(false);
        offRoadTerrain.gameObject.SetActive(false);
        cityTerrain.gameObject.SetActive(true);
        showroomTerrain.gameObject.SetActive(false);
        ResetCarTransform();
    }
    public void Showroom()
    {
        snowTerrain.gameObject.SetActive(false);
        offRoadTerrain.gameObject.SetActive(false);
        cityTerrain.gameObject.SetActive(false);
        showroomTerrain.gameObject.SetActive(true);
        ResetCarTransform();
    }

    public void Day()
    {
        //Make day
        sunLight.color = Color.white;
        //Change Skybox to day
        RenderSettings.skybox = daySky;
    }

    public void Night()
    {
        //Make night
        sunLight.color = Color.blue;
        //Change SkyBox to night
        RenderSettings.skybox = nightSky;
    }

    public void ResetCarTransform()
    {
        /*car.transform.position = carPosition.position;
        car.transform.rotation = carPosition.rotation;*/
        car.transform.position = new Vector3(2.525f, 173.9451f, 11.34f);
        car.transform.eulerAngles = new Vector3(0f, 180f, 0f);
    }
}
