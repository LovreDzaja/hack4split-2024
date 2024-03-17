import React, { useState } from 'react';
import { Link } from 'react-router-dom';

import slika from '../../images/xplorer3.png';
import { IoLogOut } from "react-icons/io5";
import { GiHamburgerMenu } from "react-icons/gi";


import "./Navbar.css";

const Navbar = ({ switchToLogin, switchToRegister }) => {

  const [isOpen, setIsOpen] = useState(false);


    const getCookie = (name) => {
      const cookieName = name + "=";
      const decodedCookie = decodeURIComponent(document.cookie);
      const cookieArray = decodedCookie.split(';');
      for (let i = 0; i < cookieArray.length; i++) {
        let cookie = cookieArray[i];
        while (cookie.charAt(0) === ' ') {
          cookie = cookie.substring(1);
        }
        if (cookie.indexOf(cookieName) === 0) {
          return cookie.substring(cookieName.length, cookie.length);
        }
      }
      return "";
    };

    const removeCookie = () => {
      document.cookie = "loggedUser=; expires=Thu, 01 Jan 1970 00:00:00 UTC; SameSite=None; Path=/; Secure";

      window.location.href = "/login";
    };

    const toggleDropdown = () => {
      setIsOpen(!isOpen);
    };

    const username = getCookie("loggedUser");

  return (
    <nav className="navbar navbar-expand-lg sticky-top d-flex justify-content-around" style={{ backgroundColor: "#87986A", height: "70px", paddingLeft: "10px"}}>
      <div className="container-fluid">
        
        <div className="navbar-brand" id="hamburger-meni" onClick={toggleDropdown}>
          <GiHamburgerMenu size={24} />
        </div>

        <div className="navbar-brand">
          <Link to="/" style={{ color: "white", textDecoration: "none" }} className="link">Home</Link>
          <Link to="/ratings" style={{color: "white", textDecoration: "none", marginLeft: "20px"}}> Ratings </Link>
          {username ? (<Link to="/myratings" className="link" style={{ color: "white", textDecoration: "none", marginLeft: "20px"}}>Add Ratings</Link>)
            : (false)}
        </div>
        <div className="navbar-brand">
          <img src={slika} id="logo" alt="Logo" className="logo" />
        </div>
        {username ? (
          <div className="navbar-brand" onClick={()=>removeCookie()}>
            <span className="link" >Welcome, {username} </span> <IoLogOut className="logo" style={{marginRight: "5px", color: "white"}} size={24}/>
          </div>
        ) : (
          <div className="navbar-brand">
            <Link className="mr-1 link" onClick={switchToLogin} to="/login">Log in</Link>
            <span className="link"> / </span>
            <Link className="ml-1 link" onClick={switchToRegister} to="/register">Sign up</Link>
          </div>
        )}
      </div>
    </nav>
  )
}

export default Navbar;
