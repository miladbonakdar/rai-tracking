import React, { useState, useEffect } from 'react';
import mapboxgl from 'mapbox-gl';
import MapGL, { Marker, Source, Layer, GeolocateControl, NavigationControl, LanguageControl  } from '@urbica/react-map-gl';
import 'mapbox-gl/dist/mapbox-gl.css';
import { MDBIcon} from 'mdbreact';


const MAPBOX_ACCESS_TOKEN =
	'pk.eyJ1IjoiaGFkaWVza2FuZGFyaSIsImEiOiJjam9uMDdmMDkxNnY2M29wYzZxNzc3MzVwIn0.q4V2ENmVFJmGegA-ylUDdg';
	mapboxgl.setRTLTextPlugin(
		'https://api.mapbox.com/mapbox-gl-js/plugins/mapbox-gl-rtl-text/v0.2.3/mapbox-gl-rtl-text.js',
		null,
		true // Lazy load the plugin
	  );
export default function MapCont(props) {
	const [ viewport, setViewport ] = useState({
		latitude: props.editItem ? props.editItem.location.latitude :  35.70064694792973,
	    longitude: props.editItem ? props.editItem.location.longitude :  35.70064694792973,
		zoom: 10
  });
  const onDragEnd = (lngLat) => {
    setViewport({
      ...viewport,
      latitude: lngLat.lngLat.lat,
      longitude: lngLat.lngLat.lng
    });
  };
	const [ selectedLayer, setSelectedLayer ] = useState(null);

	const layerClicked = (e) => {
		setSelectedLayer(e.features[0].properties);
	};


	// https://raw.githubusercontent.com/yassermzh/iran-map/master/maps/tehran_iran_admin.geojson
	return (
		<div>
			<MapGL
				style={{ width: '100%', height: '50vh' }}
				accessToken={MAPBOX_ACCESS_TOKEN}
				latitude={viewport.latitude}
				longitude={viewport.longitude}
				zoom={viewport.zoom}
				onViewportChange={(viewport) => {setViewport(viewport)}}
				onClick={onDragEnd}
					>
				<Source
					id="maine"
					type="geojson"
					data="https://raw.githubusercontent.com/yassermzh/iran-map/master/maps/tehran_iran_admin.geojson"
				/>
				<Layer
					id="maine"
					type="fill"
					source="maine"
					paint={{
						'fill-color': '#088',
						'fill-opacity': 0.1
					}}
					onClick={layerClicked}
				/>
				<Source
					id="lineS"
					type="geojson"
					data="https://raw.githubusercontent.com/yassermzh/iran-map/master/maps/tehran_iran_admin.geojson"
				/>
				<Layer
					id="lineS"
					type="line"
					source="lineS"
					paint={{
						'line-color': '#e8b',
						'line-width': 1
					}}
        
        />


<Marker longitude={viewport.longitude} latitude={viewport.latitude}>
        <div onClick={(event) => {
			event.persist();
			event.nativeEvent.stopImmediatePropagation();
			event.stopPropagation();
        }}>
              <MDBIcon size="2x" icon="map-marker-alt"/>

        </div>
      </Marker>
	  <LanguageControl defaultLanguage="mul"/>
      <GeolocateControl
      position="top-left"
      onError={()=>{console.log("error")}} onGeolocate={() =>{console.log("geolocate")}} showUserLocation={true}
	  />
      <NavigationControl showCompass showZoom position='top-right' />
			</MapGL>
      		 <button onClick={() => {props.setSelectedLocation(viewport)}}>تایید محل</button>
      
			
		</div>
	);
}

