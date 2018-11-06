using UnityEngine;
using System.Collections;

public class TrackerRotate : MonoBehaviour {
    private bool isUpdated = false;
    [SerializeField]public GameObject tracker;
    private Vector3 trackerPos;
    private Quaternion trackerRot;

    public GameObject target;
    public GameObject bodyIKTarget1;

    void Start()
    {
        isUpdated = false;
        trackerPos = tracker.transform.position;
        trackerRot = tracker.transform.rotation;

		//target.transform.rotation = new Quaternion( tracker.transform.rotation.x, tracker.transform.rotation.y, tracker.transform.rotation.z, tracker.transform.rotation.w );
    }

    // Update is called once per frame
    void Update()
    {
    }

    void LateUpdate()
    {
        isUpdated = false;

        //target.transform.rotation = tracker.transform.rotation;
        target.transform.rotation = new Quaternion( 0, tracker.transform.rotation.y, 0, tracker.transform.rotation.w );
        //target.transform.rotation = new Quaternion( tracker.transform.rotation.x, tracker.transform.rotation.y, tracker.transform.rotation.z, tracker.transform.rotation.w );

        Vector3 rValue = new Vector3(0.0f, 180.0f, 0.0f);
        //target.transform.Rotate(rValue, Space.World);

        // カメラ位置変化量の適用
        Vector3 diff = tracker.transform.position - trackerPos;
        diff = new Vector3(diff.x, diff.y, -diff.z);
        if (bodyIKTarget1)
        {
            bodyIKTarget1.transform.position += diff;
            //trackerPos = tracker.transform.position;
            bodyIKTarget1.transform.rotation = tracker.transform.rotation;
        }
    }
}