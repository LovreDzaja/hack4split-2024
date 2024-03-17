import React, { useState, useEffect } from 'react';
import { BrowserRouter, Route, Routes } from "react-router-dom";

import Navbar from './components/Navbar/Navbar';
import Register from './components/Register/Register';
import Login from './components/Login/Login';
import Card from './components/Card/Card';
import Ratings from './components/Ratings/Ratings';

import "./App.css"
import MyRatings from './components/MyRatings/MyRatings';


function App() {

  useEffect(() => {
    onRender();
  }, []);

  const [data1, setData1] = useState([]);
  
  async function onRender(){
    const response1 = await fetch('https://localhost:7264/api/Simple/get-event');

    const jsonData1 = await response1.json();
    
    setData1(jsonData1);

    console.log(jsonData1);
  }

  return (
    <div>
      <BrowserRouter>
        <Navbar />
        <Routes>
          <Route exact path="/" element={<div id="main-container">{data1.map((data1, index) => (
                                                    <Card key={index} data={data1} />
                                                    ))}</div>} />
          <Route path="/login" element={<Login />} />
          <Route path="/register" element={<Register />} />
          <Route path="/ratings" element={<div id="main-container" style={{padding: "50px 50px"}}>{data1.map((data1, index) => (
                                                    <Ratings key={index} data={data1} />
                                                    ))}</div>} />
          <Route path="/myratings" element={<MyRatings />} />                                         
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
