using UnityEngine;
using System.Collections;

public class TrackBuilder : MonoBehaviour
{

    [SerializeField]private GameObject[] easyTracks;
    [SerializeField]private Transform trackSpawnerPos;
	private int min, max;
    public static TrackBuilder trackBuilder;
    private float waitTime;
    private GameObject track;
	private GetScore getScore;

    private void Start () 
    {
        trackBuilder = this;
        waitTime = 2.0f;
		min = 0;
		max = 3;
        Track();
    }

    private void Track()
    {
		track = Instantiate (easyTracks [Random.Range(min,max)], trackSpawnerPos.position, Quaternion.identity) as GameObject;
        Destroy(track.gameObject, 8f);
        Vector3 temp = trackSpawnerPos.position;
        temp.y = 0;
        temp.x = 0;
        temp.z += 40;
        trackSpawnerPos.position = temp;
		/*
		if (PlayerPrefs.GetInt ("curScore") >= 2000)
		{
			min = 4;
			max = ?;
		}
		if (PlayerPrefs.GetInt ("curScore") >= 5000)
		{
			min = 8;
			/max = ?;
		}
		*/
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTime);
        Track();
    }
}