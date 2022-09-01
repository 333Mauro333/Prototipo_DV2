using System.Collections.Generic;

using UnityEngine;


public class LinePath : MonoBehaviour
{
    [SerializeField] LineRenderer lr = null;
    [SerializeField] ReflectorScript lightEmisor = null;



    void Start()
	{
        lr.SetPosition(0, lightEmisor.transform.position);

        ResetLinePath();
	}



    public void EnableLight()
	{
        lr.enabled = true;
	}
    public void DisableLight()
	{
        lr.enabled = false;
    }

    public void ResetLinePath()
	{
        ReflectorScript localReflector = lightEmisor;

		for (int i = 1; i < lr.positionCount; i++)
		{
            lr.SetPosition(i, localReflector.GetReflectorInCross().transform.position);

            localReflector = localReflector.GetReflectorInCross();
        }
	}
}
