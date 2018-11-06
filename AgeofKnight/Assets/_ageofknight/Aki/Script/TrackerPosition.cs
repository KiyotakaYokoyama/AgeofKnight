using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackerPosition : MonoBehaviour {
	private bool isUpdated = false;
    [SerializeField]public GameObject tracker;
    private Vector3 trackerPos;
	private Vector3 pos;

    public GameObject target;
    public GameObject bodyIKTarget1;

    void Start()
    {
        isUpdated = false;
        trackerPos = tracker.transform.position;
		pos = tracker.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void LateUpdate()
    {
		pos.x = tracker.transform.position.x;
		tracker.transform.position = pos;
        /*isUpdated = false;
        target.transform.position = trackerPos;

        Vector3 rValue = new Vector3(0.0f, 180.0f, 0.0f);

        // カメラ位置変化量の適用
        Vector3 diff = tracker.transform.position - trackerPos;
        diff = new Vector3(diff.x, diff.y, -diff.z);
        if (bodyIKTarget1)
        {
            bodyIKTarget1.transform.position += diff;
            trackerPos = tracker.transform.position;
            //bodyIKTarget1.transform.rotation = tracker.transform.rotation;
        }*/
    }
}