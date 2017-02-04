using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;



public class glossaryBuddy : MonoBehaviour {

	public bool glossaryScreenOpen;
	public bool CarbonSlide;
	public bool CO2Slide;
	public bool CO3Slide;
	public bool GraphiteSlide;
	public Canvas GlossaryCanvas;
	public Image carbon;
	public Image CO2;
	public Image CO3;
	public Image Graphite;
	public Button Carbonbutton;
	public Button CO2button;
	public Button CO3button;
	public Button Graphitebutton;

	// Use this for initialization
	void Start () {
		CarbonSlide = true;
		CO2Slide = false;
		CO3Slide = false;
		GraphiteSlide = false;
	}
	
	// Update is called once per frame
	void Update () {
		carbon.enabled = CarbonSlide;
		Carbonbutton.interactable = !CarbonSlide;
		CO2.enabled = CO2Slide;
		CO2button.interactable = !CO2Slide;
		CO3.enabled = CO3Slide;
		CO3button.interactable = !CO3Slide;
		Graphite.enabled = GraphiteSlide;
		Graphitebutton.interactable = !GraphiteSlide;
	}

	public void ToGlossary()
	{

		if (!glossaryScreenOpen) {
			glossaryScreenOpen = true;
			GlossaryCanvas.enabled = glossaryScreenOpen;
		} 
	}

	public void CarbonPage() {
		CarbonSlide = true;

		CO2Slide = false;
		CO3Slide = false;
		GraphiteSlide = false;
	}

	public void CO2Page() {
		CO2Slide = true;

		CarbonSlide = false;
		CO3Slide = false;
		GraphiteSlide = false;
	}

	public void CO3Page() {
		CO3Slide = true;

		CO2Slide = false;
		CarbonSlide = false;
		GraphiteSlide = false;
	}

	public void GraphitePage() {
		GraphiteSlide = true;

		CO2Slide = false;
		CO3Slide = false;
		CarbonSlide = false;
	}

	public void close() {
		if (glossaryScreenOpen) {
			glossaryScreenOpen = false;
			GlossaryCanvas.enabled = glossaryScreenOpen;
		}
	}
}
