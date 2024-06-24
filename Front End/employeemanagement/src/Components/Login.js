import React from 'react';
import './Login.css'
import { Link } from 'react-router-dom';
import { useNavigate } from "react-router-dom";
import { useState } from "react";

function Login() {
  const navigate = useNavigate();
    const [user,setUser] = useState({
        "UserId": 0,
        "Password":" ",
        "Role": "",
        "Token": ""
    });

    var login = ()=>{
      fetch("http://localhost:5006/api/Employee/Login",{
        "method":"POST",
        headers:{
            "accept": "text/plain",
            "Content-Type": 'application/json'
        },
        "body":JSON.stringify({...user,"user":{} })})
   .then(async (data)=>{
        if(data.status == 200)
        {
            var myData = await data.json();
            console.log(myData); 
            localStorage.setItem("token" , myData.token.toString());         
            if(myData.role=="Employee")
            {
              localStorage.setItem("Employee Id" , myData.userId.toString());
               navigate("/employeePage");               
            }          
            else if(myData.role=="Manager")
            {
              localStorage.setItem("Manager Id" , myData.userId.toString());
               navigate("/managerPage");
            }          
        }
      }).catch((err)=>{
        console.log(err.error)
      })
    }
  return (
    <div className="container">
      <div className="img-container">
      <div className="login-container">

        <h2 className="text-center">Login</h2>
        <div className="form login-form">
          <div className="form-group">
            <label htmlFor="email">User Id</label>
            <input type="number" className="form-control" id="email" placeholder="Enter Id" onChange={(event)=>{
                setUser({...user, "UserId":event.target.value})
              }}/>
          </div>
          <div className="form-group">
            <label htmlFor="password">Password</label>
            <input type="password" className="form-control" id="password" placeholder="Password" onChange={(event)=>{
                setUser({...user, "Password":(event.target.value)})
              }}/>
          </div>
          <button type="submit" className="btn btn-dark btn-block" onClick={login}>Login</button>  
          <div className="text-center mt-3">
            <p className="mb-0">Not a registered user?</p>
            <Link className="btn btn-dark" to="/register">Register Here</Link>
          </div>
        </div>
      </div>
      </div>
    </div>
  );
}

export default Login;
