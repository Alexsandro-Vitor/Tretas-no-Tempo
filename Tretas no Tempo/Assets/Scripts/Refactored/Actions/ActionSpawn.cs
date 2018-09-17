using System.Collections.Generic;
using UnityEngine;

/// <summary>Spawning action</summary>
public class ActionSpawn : AbstractAction {
	[Header("Spawning")]
	[Tooltip("O que irá aparecer")][SerializeField] private GameObject spawn;
	[Tooltip("Os pontos onde o spawn pode aparecer")][SerializeField] private Transform spawnPoints;

	[Header("Restricted area")]
	[Tooltip("Centro da área que não pode ser usada para spawn")][SerializeField] Transform forbiddenPoint;
	[Tooltip("Raio da área que não pode ser usada para spawn")][SerializeField] float forbiddenRange;

	/// <summary>Will spawn the spawn GameObject on one of the spawnPoints child transform's positions.</summary>
	public override void Activate() {
		List<Transform> allowed = new List<Transform>();
		foreach (Transform point in spawnPoints) {
			if (Vector3.Distance(forbiddenPoint.position, point.position) > forbiddenRange)
				allowed.Add(point);
		}
		if (allowed.Count > 0)
			GameObject.Instantiate(spawn, allowed[Random.Range(0, allowed.Count)]);
		else Debug.Log("Não há spawn points disponíveis");
	}
}