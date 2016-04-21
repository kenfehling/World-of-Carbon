using UnityEngine;
using System.Collections;

public class Molecule : MonoBehaviour {

	public float standardEnthalpyChange;
	public string formula;


	// Sets up a molecule with a designated name
	public Molecule(string formula, float stadardEnthalpyChange){
		this.formula = formula;
		this.standardEnthalpyChange = standardEnthalpyChange;
	}
}