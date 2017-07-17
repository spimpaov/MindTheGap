﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Passenger : MonoBehaviour {
    
    private PassengerData.PassengerType p_type;
    private Color color;

    private int curr_tile_id;

    public int generatePassenger(List<PassengerData> passenger_types, int tile_id)
    {
        gameObject.name = "Passenger " + tile_id;
        curr_tile_id = tile_id;
        int chosen = Random.Range(0, passenger_types.Capacity);
        p_type = passenger_types[chosen].type;
        color = passenger_types[chosen].color;
        GetComponent<Image>().color = color;
        return chosen;
    }
    
}
