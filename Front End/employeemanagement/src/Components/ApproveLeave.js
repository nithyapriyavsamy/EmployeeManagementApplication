import { useState,useEffect } from "react";
import IndividualLeave from './IndividualLeave'
import './IndividualLeave.css'


function ApproveLeave()
{

    const[leaves,setLeaves]=useState([]);

    // const[employeeLeaves,setEmployeeLeaves]=useState([]);

    const[leaveDTO,setleaveDTO]=useState(
        {
            "id": 0,
            "emp_Id": 0,
            "manager_Id": 0,
            "leaveStatus": ""
        }
    );

    useEffect(() => {
        let ignore = false;
        
        if (!ignore)  Leaves()
        return () => { ignore = true; }
        },[]);


    var Leaves=()=>
    {
        leaveDTO.manager_Id=Number(localStorage.getItem("Manager Id"));
        fetch("http://localhost:5252/api/Leave/action/GetAllByManager",
        {
            "method":"POST",
            headers:{
                "accept": "text/plain",
                "Content-Type": "application/json",
                'Authorization': 'Bearer ' + localStorage.getItem('token')
            },
            "body":JSON.stringify({...leaveDTO,"leaveDTO":{} })
        })
        .then(async (data)=>
        {
            if(data.status == 200)
            {
                setLeaves(await data.json());
                console.log(leaves);
            }
        })
        .catch((err)=>
        {
                console.log(err.error);
        })
    }

    var GetEmployees=(event)=>
    {
        leaveDTO.emp_Id=event.target.value;
        fetch("http://localhost:5252/api/Leave/action/GetAllByEmp",
        {
            "method":"POST",
            headers:{
                "accept": "text/plain",
                "Content-Type": "application/json",
                'Authorization': 'Bearer ' + localStorage.getItem('token')
            },
            "body":JSON.stringify({...leaveDTO,"leaveDTO":{} })
        })
        .then(async (data)=>
        {
            if(data.status == 200)
            {
                setLeaves(await data.json());
                console.log(leaves);
            }
        })
        .catch((err)=>
        {
                console.log(err.error);
        })
    }
    

    return(
        <div>
            <div>
                <input onChange={GetEmployees} className="leaves" type="number"/>
            </div>
            <table>
                <thead>
                    <th>Employee ID</th>
                    <th>Title</th>
                    <th>From Date</th>
                    <th>To Date</th>
                    <th>Duration</th>
                    <th>Leave Status</th>
                    <th>Action</th>
                </thead>
                <tbody>
                {
                    leaves.map((leave,index)=>{
                        return(
                            <IndividualLeave  key={index} object={leave}/>
                        )
                    })
                }
                </tbody>
            </table>
        </div>
    )
}

export default ApproveLeave;