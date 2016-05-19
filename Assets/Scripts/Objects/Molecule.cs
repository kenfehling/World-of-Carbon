using UnityEngine;
using System.Collections;

public class Molecule : MonoBehaviour {

	// To be set by designer in object inspector of molecule prefabs
	public float standardEnthalpyChange;
	public string formula;

	void OnCollisionEnter2D (Collision2D obj) {
		var molecule = obj.gameObject.GetComponent<Molecule> ();
		if(molecule != null)
		{
			var reaction = GameManager.reactionTable.GetReaction (this.formula, molecule.formula);
			if (reaction != null) {
				foreach (string s in reaction.products)
					Debug.Log ("Create " + s);
			}
		}
	}
}