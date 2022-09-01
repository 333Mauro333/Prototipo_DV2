using System.Collections.Generic;

using UnityEngine;


public class ReflectorScript : MonoBehaviour
{
    [SerializeField] bool isOn = false;
    [SerializeField] List<ReflectorScript> otherReflectors = new List<ReflectorScript>();
    [SerializeField] int index = 0;
    [SerializeField] ReflectorScript reflectorInCross = null;

    [Header("References")]
    [SerializeField] LinePath lp = null;



    void Awake()
    {
        transform.LookAt(otherReflectors[index].transform);
        reflectorInCross = otherReflectors[index];
    }

	void OnMouseDown()
	{
        SetNextReflector();
	}


    public ReflectorScript GetReflectorInCross()
	{
        return reflectorInCross;
	}

    void SetNextReflector()
	{
        SetNextIndex();

        reflectorInCross = otherReflectors[index];
        transform.LookAt(reflectorInCross.transform);

        lp.ResetLinePath();
    }
    void SetNextIndex()
	{
        index++;

        if (index >= otherReflectors.Count)
        {
            index = 0;
        }
    }
}
