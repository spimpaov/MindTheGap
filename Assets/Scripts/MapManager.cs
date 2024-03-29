﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class MapManager : MonoBehaviour {

    public GameObject map_window;
	public GameObject info_window;
    public GameObject station_prefab;
    public GameObject connection_prefab;
    public List<GameObject> routeMap = new List<GameObject>();
    public int ending_trigger_index = 10;
	//public List<StationData> stations;

    private bool map_window_active = false;
	private bool info_window_active = false;
    private TurnManager tm;

    void Start() {
        setInfoTextDefault();
        tm = FindObjectOfType<TurnManager>();
    }

    void setInfoTextDefault() {
        info_window.GetComponentInChildren<TextMeshProUGUI>().text = "<b>estaçao</b>:\n<b>perfil</b>:";
    }

    public void _openCloseMap() {
        bool aux;
		if (!map_window_active) {
            aux = true;
			info_window.SetActive (true);
        } else {
            aux = false;
			info_window.SetActive (false);
			info_window_active = false;
            setInfoTextDefault();
        }
		map_window_active = aux;
        map_window.SetActive(aux);
    }

    public void attMap(int index) {
        // print("index #" + index + " on routeMap is a " + routeMap[index]);
        if (index > 0) {
            routeMap[index - 1].transform.GetChild(0).gameObject.SetActive(false);
        }

        routeMap[index].transform.GetChild(0).gameObject.SetActive(true);
        //print("==> " + routeMap[index].transform.GetChild(0).gameObject.name);
        if (index == ending_trigger_index) {
            // print("index: " + index);
            Ending end = FindObjectOfType<Ending>();
            StartCoroutine(end.triggerEnd());
        } else if (index == 2) { //segunda estação 
            tm.initial_time_between_turns = 65;
        } else if (index == 4) { //terceira estação 
            tm.initial_time_between_turns = 60;
        } else if (index == 6) { //quarta estação
            tm.initial_time_between_turns = 45;
        } else if (index == 10) { //sexta estação
            tm.initial_time_between_turns = 30;
        }
         //}   tm.initial_time_between_turns = 5;

    }

	public void _showStationInfo(GameObject go) {
		// print ("info_window: " + info_window);
		if (!info_window_active) {
			info_window.SetActive (true);
			info_window_active = true;
		}
		StationData st = go.GetComponent<Station> ().sd;
		setInfoText (st);
	}

	void setInfoText(StationData st) {
		//StationData data = info_window.GetComponentInChildren<Station> ().sd;
		string infoText = "<b>estaçao</b>: <color=#7A7A7A>" + st.name + "</color>";
		infoText += "\n<b>perfil</b>: <color=#7A7A7A>";
		string perfis = "";
		for (int i = 0; i < st.perfis.Count; i++) {
			perfis += st.perfis[i];
			if (i < st.perfis.Count - 1) {
				perfis += ", ";
			}
		}
		infoText += perfis.ToLower();
		infoText += "</color>";
		info_window.GetComponentInChildren<TextMeshProUGUI> ().text = infoText;
	}

}