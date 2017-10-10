using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapAddress : MonoBehaviour
{
    public GoogleMap map;
    private InputField _input;

	// Use this for initialization
	void Start ()
	{
	    _input = GetComponent<InputField>();

	    Refresh();	    
	}

    public void Refresh()
    {
        if (map != null && _input != null)
        {
            if (map.markers == null || map.markers.Length == 0)
            {
                map.markers = new GoogleMapMarker[1];
                map.markers[0] = new GoogleMapMarker();
                map.markers[0].color = GoogleMapColor.red;
                map.markers[0].size = GoogleMapMarker.GoogleMapMarkerSize.Mid;
                map.markers[0].label = _input.text;
            }


            if (map.markers[0].locations == null || map.markers[0].locations.Length == 0)
            {
                map.markers[0].locations = new GoogleMapLocation[1];
                map.markers[0].locations[0] = new GoogleMapLocation();
            }
                
            map.markers[0].locations[0].address = _input.text;            
        }
    }
}
