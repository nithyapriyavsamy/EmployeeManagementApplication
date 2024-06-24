import React from 'react';
import './Register.css';
import { useNavigate } from "react-router-dom";
import { useState } from "react";

function Register() {
  const navigate = useNavigate();
  const [employee,setEmployee] = useState({
    "employeeId": 0,
    "users": {
      "userId": 0,
    "managerId": 0,
    "role": "",
    "employeeState": "",
    "passwordHash": "",
    "passwordKey": ""
    },
    "name": "",
    "dateOfBirth": new Date(),
    "age": 0,
    "gender": "",
    "phone": "",
    "email": "",
    "address": "",
    "passportNumber": "",
    "licenseNumber": "",
    "password": ""
  });

  var register = ()=>{
    console.log(employee);
    fetch("http://localhost:5006/api/Employee/Register",{
      "method":"POST",
      headers:{
          "accept": "text/plain",
          "Content-Type": 'application/json'
      },
      "body":JSON.stringify({...employee,"employee":{}})})
 .then(async (data)=>{
      if(data.status == 201)
      {
          var myData = await data.json();      
          console.log(myData);
          localStorage.setItem("token" , myData.token.toString()); 
          if(myData.role=="Employee")
          {
            localStorage.setItem("Employee Id" ,myData.userId);
            navigate("/managerPage") 
          }        
          else if(myData.role=="Manager")
          {
            localStorage.setItem("Manager Id" , myData.userId);
            navigate("/employeePage") 
          }   
      }
      else {
        console.log("hello")
      }
    }).catch((err)=>{
      console.log(err.error)
    })
  }
  return (
    <div className="container">
      <div className="register-container">
        <h2 className="text-center">Register</h2>
        <div className="form">
          <div className="form-row">
            <div className="form-group col-md-6">
              <label htmlFor="email">Name</label>
              <input type="text" className="form-control" id="name" placeholder="Name" onChange={(event)=>{
                setEmployee({...employee, "name":event.target.value})
              }}/>
            </div>
            <div className="form-group col-md-6">
              <label htmlFor="dateofbirth">Date of Birth</label>
              <input type="datetime-local" className="form-control" id="dob" placeholder="Date of Birth" onChange={(event)=>{
                setEmployee({...employee, "dateOfBirth":event.target.value})
              }}/>
            </div>
          </div>
          <div className="form-row">
            <div className="form-group col-md-6">
              <label htmlFor="age">Age</label>
              <input type="number" className="form-control" id="age" placeholder="Age" onChange={(event)=>{
                setEmployee({...employee, "age":Number(event.target.value)})
              }}/>
            </div>
            <div className="form-group col-md-6">
              <label htmlFor="gender">Gender</label>              
              <select  className="form-control form-control-lg" id="gender" onChange={(event)=>{
                setEmployee({...employee, "gender":event.target.value})
              }}>
                <option value="" disabled selected>Select your gender</option>
                <option value="male">Male</option>
                <option value="female">Female</option>             
             </select>
            </div>
          </div>
          <div className="form-row">
            <div className="form-group col-md-6">
              <label htmlFor="Phone">Phone</label>
              <input type="text" className="form-control" id="age" placeholder="Phone" onChange={(event)=>{
                setEmployee({...employee, "phone":event.target.value})
              }}/>
            </div>
            <div className="form-group col-md-6">
              <label htmlFor="mail">Mail</label>              
              <input type="email" className="form-control" id="mail" placeholder="Mail" onChange={(event)=>{
                setEmployee({...employee, "email":event.target.value})
              }}/>
            </div>
          </div>
          <div className="form-row">
            <div className="form-group col-md-6">
              <label htmlFor="passport">Passport Number</label>
              <input type="text" className="form-control" id="passport" placeholder="Passport Number" onChange={(event)=>{
                setEmployee({...employee, "passportNumber":event.target.value})
              }}/>
            </div>
            <div className="form-group col-md-6">
              <label htmlFor="license">License Number</label>
              <input type="text" className="form-control" id="license" placeholder="License Number" onChange={(event)=>{
                setEmployee({...employee, "licenseNumber":event.target.value})
              }}/>
            </div>
          </div>
          <div className="form-row">
            <div className="form-group col-md-6">
              <label htmlFor="address">Address</label>
              <textarea className="form-control textarea-input" id="address" placeholder="Address" onChange={(event)=>{
                setEmployee({...employee, "address":event.target.value})
              }}></textarea> 
            </div>          
          </div>
          <div className="form-row">
            <div className="form-group col-md-6">
              <label htmlFor="password">Password</label>
              <input type="password" className="form-control password-input" id="Registerpassword" placeholder="Password" onChange={(event)=>{
                setEmployee({...employee, "password":event.target.value})
              }}/>
            </div>          
          </div>
          <button type="submit" className="btn btn-dark btn-block" onClick={register}>Register</button>  
        </div>
      </div>

      

    </div>
  );
}

export default Register;
