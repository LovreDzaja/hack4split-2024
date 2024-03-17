import React, { useState } from 'react';

import { FaRegEye } from "react-icons/fa";
import { FaRegEyeSlash } from "react-icons/fa";

import "./Register.css";

const Register = ({switchToLogin}) => {
  const [showPassword, setShowPassword] = useState(false);

  const togglePasswordVisibility = () => {
    setShowPassword(!showPassword);
  };

  function setCookie(value) {
    const expirationDate = new Date();

    expirationDate.setTime(expirationDate.getTime() + 12 * 60 * 60 * 1000);

    const expires = "expires=" + expirationDate.toUTCString();

    document.cookie =
      "loggedUser=" + value + ";" + expires + ";SameSite=None; Path=/";
  }


  async function register(){
    const userName = document.getElementById("username").value;
    const email = document.getElementById("email").value;
    const password = document.getElementById("password").value;

    const data =  {
      username: userName,
      email: email,
      password: password
    }

    const request = {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json' 
    },
      body: JSON.stringify(data)
    }

    const response = await fetch('https://localhost:7264/api/User/register', request);

    const data1 = await response.json();

    if(data1.message === "User Registered!"){
      setCookie(userName);
    }
  }

  return (
    <>
    <div className="login-container">
      <div className="login-form">
      <label id="title">Register</label>
      <hr />
      <label htmlFor='text'>
            Username: <br/><input id="username" type='text' name='username' placeholder="Enter your username" required/>
        </label>
        <label htmlFor='email'>
            Email: <br/><input id="email" type='email' name='email' placeholder="Enter your email" required/>
        </label>
        <br/>
        <label htmlFor="Password">
            Password: <br/><input id="password" type={showPassword ? 'text' : 'password'} name="password" placeholder="Enter your password" required></input>
        </label>
        {showPassword ? <FaRegEye style={{marginLeft: "5px"}} onClick={togglePasswordVisibility} /> : <FaRegEyeSlash style={{marginLeft: "5px"}} onClick={togglePasswordVisibility} />}
        <br/>
        <button type="submit" className="btn" style={{backgroundColor: '#b5c99a'}} onClick={register}>Sign up</button>
        <hr />
        <label id='login'> Already have an account - <label id="loginButton" onClick={switchToLogin}>Login</label></label>
      </div>
    </div>
    </>
  )
}

export default Register
