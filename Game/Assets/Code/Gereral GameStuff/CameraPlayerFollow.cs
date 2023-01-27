using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayerFollow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] internal float followSpeed = 2f;
    [SerializeField] internal float y_Offset = 1f;
    [SerializeField] internal float z_CamValue = -10f;

    [SerializeField] internal Transform target;
    [SerializeField] internal static float fadeDuration;
    [SerializeField] internal int ZOOM;






    public void setComponent()
    {
        target = GameObject.Find(CONSTANTS.COLLISION_TAG_PLAYER).GetComponent<Transform>();
    }
    public void set()
    {
        setComponent();
        fadeDuration = 4.8f;
        ZOOM = 10;
    }
    // Update is called once per frame

    public void Awake()
    {

    }
    public void Start()
    {
        set();
        Camera.main.orthographicSize = ZOOM;
    }
    public void Update()
    {
        Vector3 playerPosition = new Vector3(target.position.x, target.position.y + y_Offset, z_CamValue);
        transform.position = Vector3.Slerp(transform.position, playerPosition, followSpeed * Time.deltaTime);
    }





}






