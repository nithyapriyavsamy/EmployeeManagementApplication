import React, { useState,useEffect} from "react";
import 'bootstrap/dist/css/bootstrap.css';
import './IndividualEmployee.css'

function IndividualEmployee(props)
{
    const [Employee,setEmployee]=useState(props.user);

    var [id,setId]=useState(
        {
            "userId":0
        }
    );

    var [statuss,setStatus]=useState(
        {
            "managerID": 0,
            "employeeID": 0
        }
    );

    const[user,setUser]=useState(
        {
            "userId": 0,
            "managerId": 0,
            "role": "",
            "employeeState": "",
            "passwordHash": "",
            "passwordKey": ""
        }
    );

    useEffect(() => {
        let ignore = false;
        
        if (!ignore)  Users()
        return () => { ignore = true; }
        },[]);

    var Users=()=>
    {
        id.userId=Employee.employeeId;
        fetch("http://localhost:5006/api/Employee/GetUser",
        {
            "method":"POST",
            headers:{
                "accept": "text/plain",
                "Content-Type": "application/json"
            },
            "body":JSON.stringify({...id,"id":{} })
        })
        .then(async (data)=>
        {
            if(data.status == 200)
            {
                setUser(await data.json());
                console.log(user.employeeState)
            }
        })
        .catch((err)=>
        {
                console.log(err.error)
        });
    }

    var UpdateStatus=()=>
    {
        statuss.managerID=localStorage.getItem("Manager Id");
        statuss.employeeID=Employee.employeeId;
        fetch("http://localhost:5006/api/Employee/UpdateEmployeeStatus",
        {
            "method":"PUT",
            headers:{
                "accept": "text/plain",
                "Content-Type": "application/json"
            },
            "body":JSON.stringify({...statuss,"statuss":{} })
        })
        .then(async (data)=>
        {
            if(data.status == 200)
            {
                setUser(await data.json());
                console.log(statuss);
            }
        })
        .catch((err)=>
        {
                console.log(err.error)
        })
    }

    return(
        <div>
            <div>
            <div className="card IndividualEmployee card-body card text-white bg-dark mb-3 shadow p-3 mb-5 rounded">
                
                    {/* <h5 className="card-title">{Employee.employeeID}</h5> */}
                    <h5 className="card-title">{Employee.name}</h5>
                    <h6 className="card-subtitle mb-2 text-body-secondary">{Employee.email}</h6>
                    <p className="card-text">{Employee.dateOfBirth}</p>
                    <p className="card-text">
                        <b>Age - </b>{Employee.age}</p>
                    <p className="card-text">
                        <b>Gender - </b>{Employee.gender}</p>
                    <p className="card-text">
                    <b>Phone - </b>{Employee.phone}</p>
                    <p className="card-text">
                    <b>City - </b>{Employee.address}</p>
                    {/* <p className="card-text">
                        {Employee.passportNumber}</p>
                    <p className="card-text">{Employee.licenseNumber}</p> */}
                    <p className="card-text">
                    <b>Role - </b>{user.role}</p>
                    <p className="card-text">
                    <b>State - </b>{user.employeeState}</p>
                    <button onClick={UpdateStatus} className="card-link btn btn-secondary">Change Status</button>
                
            </div>
        </div>
        </div>
    );
}

export default IndividualEmployee;