import { useState,useCallback } from "react";

function IndividualLeave(props)
{

    const[leave,setLeave]=useState(props.object);

    const[leaveStatus,setLeaveStatus]=useState(leave.leaveStatus);

    const[leaveDTO,setleaveDTO]=useState(
        {
            "id": 0,
            "emp_Id": 0,
            "manager_Id": 0,
            "leaveStatus": ""
        }
    );

    var UpdateLeaveStatus=useCallback((event)=>
    {
        leaveDTO.id=leave.id;
        leave.leaveStatus=event.target.value;
        leaveDTO.leaveStatus=event.target.value;
        setLeaveStatus(event.target.value);
        console.log(leaveDTO.id);
        console.log(leave.leaveStatus);
        fetch("http://localhost:5252/api/Leave/action/Update",
        {
            "method":"PUT",
            headers:{
                "accept": "text/plain",
                "Content-Type": "application/json",
                'Authorization': 'Bearer ' + localStorage.getItem('token')
            },
            "body":JSON.stringify({...leaveDTO,"leaveDTO":{} })
        })
        .then(async (data)=>
        {
            // if(data.status == 200)
            // {
            //     setUser(await data.json());
            //     console.log(statuss);
            // }
        })
        .catch((err)=>
        {
                console.log(err.error)
        })
    },[],)

    return(
        <tr>
            <td>{leave.emp_Id}</td>
            <td>{leave.title}</td>
            <td>{leave.fromDate}</td>
            <td>{leave.toDate}</td>
            <td>{leave.duration}</td>
            <td>{leaveStatus}</td>
            <td>
                <select onChange={UpdateLeaveStatus}>
                    <option value="none" selected disabled hidden>Select</option>
                    <option value="Approve">Approve</option>
                    <option value="Denied">Denied</option>
                </select>
            </td>
        </tr>       
    )
}
export default IndividualLeave;