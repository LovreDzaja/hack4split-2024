import React, { useEffect } from 'react';
import {useState} from 'react'

const Map = () => {
  const myLating = {
    lat: 43.508133,
    lng: 16.440913
  }

return (
    <>
      <iframe
          width="600"
          height="450"
          frameBorder="0"
          style={{ border: 0 }}
          src={`https://www.google.com/maps/embed/v1/view?key=AIzaSyBvVrm4ixaEMqLtPCp7LW_Byha_jI3eXgA&center=${myLating.lat},${myLating.lng}&zoom=13`}
          allowFullScreen
        ></iframe>
    </>
  )
}

export default Map