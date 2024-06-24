import React from "react";
import { useState,useEffect } from "react";
import IndividualEmployee from "./IndividualEmployee";
import './AllEmployees.css'
import { Link } from "react-router-dom";
import './AllEmployees.css'


function AllEmployees()
{
    var [id,setId]=useState(
        {
            "userId":0
        }
    );

    const [employees,setEmployees]=useState([]);

    useEffect(() => {
        let ignore = false;
        
        if (!ignore)  Employees()
        return () => { ignore = true; }
        },[]);

    var Employees=()=>
    {
        id.userId=Number(localStorage.getItem("Manager Id"));
        fetch("http://localhost:5006/api/Employee/GetEmployees",
        {
            "method":"POST",
            headers:{
                "accept": "text/plain",
                "Content-Type": 'application/json',
                'Authorization': 'Bearer ' + localStorage.getItem('token')
            },
            "body":JSON.stringify({...id,"id":{} })
        })
        .then(async (data)=>
        {
            if(data.status == 200)
            {
                setEmployees(await data.json());
                console.log(employees);
            }
        })
        .catch((err)=>
        {
                console.log(err.error);
        })
    }


    var GetAllEmployees=()=>
    {
        fetch("http://localhost:5006/api/Employee/GetAllEmployees",
        {
            "method":"GET",
            headers:{
                "accept": "text/plain",
                'Authorization': 'Bearer ' + localStorage.getItem('token')
            },
        })
        .then(async (data)=>
        {
            if(data.status == 200)
            {
                setEmployees(await data.json());
                console.log(employees);
            }
        })
        .catch((err)=>
        {
                console.log(err.error);
        })
    }

    var filters=(event)=>
    {
        if(event.target.value=="particular")
            {Employees()};
        if(event.target.value=="all")
            {GetAllEmployees()};
    }


    return(
        <div>
            <div>
                <select onChange={filters}>
                    <option value="none"  disabled hidden>Filter</option>
                    <option value="particular">Particular</option>
                    <option value="all">AllEmployees</option>
                </select>
            </div>
            <div className="GetAll">
                {
                    employees.map((Employee,index)=>{
                        return(<IndividualEmployee key={index} user={Employee}/>)
                    })
                }
            </div>
        </div>
    );
}

export default AllEmployees;