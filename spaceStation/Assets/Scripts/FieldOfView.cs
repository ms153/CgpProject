using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
public class FieldOfView : MonoBehaviour
{
	public float viewRadius;
	[Range(0, 360)]
	public float viewAngle;

	public LayerMask targetMask;
	public LayerMask obstacleMask;

	[HideInInspector]
	public List<Transform> visibleTargets = new List<Transform>();

	public NavMeshAgent Enemy;     
	public Transform Player;

	public float wanderRadius;
	public float wanderTimer;
	public float hearingRadius;
	public float speed;

	private bool Spotted = false;
	private bool Heard = false;
	private float timer;

	public bool AI_Enable = true;

	void Start()
	{
		Enemy = GetComponent<NavMeshAgent>();
		StartCoroutine("FindTargetsWithDelay", .2f);
	}

	private void Update()
	{
		if (AI_Enable == true)
		{
			//*----Can Player Be Heard----*

			Enemy.speed = speed;
			float dist = Vector3.Distance(Player.transform.position, transform.position);

			if (dist < hearingRadius)
			{
				Heard = true;
			}
			else
			{
				Heard = false;
			}

			//*----If Player Heard Or Seen----*

			//----Follow Player----

			if ((Spotted == true || Heard == true) & AI_Enable == true)
			{
				Enemy.SetDestination(Player.position);
			}

			//----Random Wander Around NavMesh----

			else if ((Spotted == false & Heard == false) & AI_Enable == true)
			{
				timer += Time.deltaTime;

				//Vector3 cur_Pos = transform.position;

				if (timer >= wanderTimer) 
				{
					Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
					
					Enemy.SetDestination(newPos);
					timer = 0;
				}
			}
		}
        else
        {
			Enemy.speed = 0;
        }
	}
		//*----Start Wait Before Begining Search----*

		IEnumerator FindTargetsWithDelay(float delay)
		{
			//while (true)
			while(true)
			{
				yield return new WaitForSeconds(delay);
				FindVisibleTargets();
			}
		}

		//*----Core Searching AI----*

		void FindVisibleTargets()
		{
			visibleTargets.Clear();

			//----Return All Objects In Sphere----

			Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);

			for (int i = 0; i < targetsInViewRadius.Length; i++)
			{
				Transform target = targetsInViewRadius[i].transform;
				Vector3 dirToTarget = (target.position - transform.position).normalized;

				//----Find Objects In Sphere & FOV----

				if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
				{
					float dstToTarget = Vector3.Distance(transform.position, target.position);

					//----Only Return If Not Blocked By Obstacle----
					if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))
					{
						visibleTargets.Add(target);
						Spotted = true;
					}
					else
					{
						Spotted = false;
					}
				}
			}
		}

		//*----Convert Angles To Normal (East --> 0 Deg)----*
		public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
		{
			if (!angleIsGlobal)
			{
				angleInDegrees += transform.eulerAngles.y;
			}
			return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
		}

		//*----Pick Random World Point And Find Nearest Point On NavMesh----*
		public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
		{
			Vector3 randDirection = Random.insideUnitSphere * dist;

			randDirection += origin;

			NavMeshHit navHit;

			NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

			return navHit.position;
		}

		//*----On Enemy Hit----*
		private void OnCollisionEnter(Collision collision)
		{
			if (collision.collider.tag == "Player")
			{
				Debug.Log("Player Caught");     //REPLACE WITH GAMEOVER	
			}
		}
	
	}
