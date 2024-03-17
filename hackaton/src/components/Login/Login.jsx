import React, { useEffect, useState } from 'react';
import { FaRegEye } from "react-icons/fa";
import { FaRegEyeSlash } from "react-icons/fa";
import Navbar from '../Navbar/Navbar';

import "./Login.css"

const Login = ({switchToRegister}) => {
  const [showPassword, setShowPassword] = useState(false);

  const togglePasswordVisibility = () => {
    setShowPassword(!showPassword);
  };

  function setCookie(value) {
    const expirationDate = new Date();

    expirationDate.setTime(expirationDate.getTime() + 12 * 60 * 60 * 1000);

    const expires = "expires=" + expirationDate.toUTCString();

    document.cookie =
      "loggedUser=" + value + ";" + expires + ";SameSite=None; Path=/; Secure";
  }


  async function logIn(){
    const userName = document.getElementById("userName").value;
    const password = document.getElementById("password").value;

    const data =  {
      username: userName,
      password: password
    }

    const request = {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json' 
    },
      body: JSON.stringify(data)
    }

    const response = await fetch('https://localhost:7264/api/User/authenticate', request);

    const data1 = await response.json();

    if(data1.message === "Login Success."){
      setCookie(userName);

      window.location.href = "/";
    }
  }

  return (
    <>
    <div className="login-container">
      <div className="login-form">
      <label id="title">Log in</label>
      <hr />
      <label htmlFor='Username'>
            Username: <br/><input id="userName" type='text' name='username' placeholder="Enter your username" required/>
        </label>
        <br/>
        <label htmlFor="Password">
            Password: <br/><input id="password"  type={showPassword ? 'text' : 'password'} name="password" placeholder="Enter your password" required></input>
        </label>
        {showPassword ? <FaRegEye style={{marginLeft: "5px"}} onClick={togglePasswordVisibility} /> : <FaRegEyeSlash style={{marginLeft: "5px"}} onClick={togglePasswordVisibility} />}
        <br/>
        <button type="submit" className="btn" style={{backgroundColor: '#b5c99a'}} onClick={logIn}>Log in</button>
        <hr />
        <label id='login'> Don't have an account - <label id="registerButton" onClick={switchToRegister}>Sign up</label></label>
      </div>
    </div>
    </>
  )
}

export default Login
