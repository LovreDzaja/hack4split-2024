import React from 'react';
import { Link } from 'react-router-dom';

import Map from '../Map/Map'

import { FaPhoneAlt } from "react-icons/fa";
import { FaCalendarAlt } from "react-icons/fa";

const Card = ({data}) => {
  return (
    <div className="card" style={{
      width: "20rem", overflow: "hidden", boxShadow: "5px 5px 10px 5px rgba(0, 0, 0, 0.1)", display: 'inline-flex', marginTop: "3%", marginRight: "7%"
      }}>
        <img src={data.image_url} alt="Zip-line" className="card-img-top" style={{height: "150px"}}/>
        <div className="card-body">
            <h5 className="card-title" style={{fontWeight: 'bold', display: "flex", justifyContent: 'center'}}>{data.name}</h5>
            <p className="card-text" style={{ fontFamily: 'Times New Roman, Times, serif', fontStyle: 'italic'}}>{data.description}</p>            
            <hr />
            <FaPhoneAlt style={{marginRight: "5px"}}/>
            <label> Phone: {data.contact}</label>
            <br />
            <FaCalendarAlt style={{marginRight: "5px"}}/>
            <label style={{marginTop: "5px"}}> Working hours: {data.working_hours}</label>
        </div>
    </div>
  )
}

export default Card
