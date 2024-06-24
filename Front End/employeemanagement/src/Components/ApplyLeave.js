import React, { useState } from 'react';
import './ApplyLeave.css';
function ApplyLeave() {
  const [leave, setLeave] = useState({
    "emp_Id": 0,
    "manager_Id": 0,
    "title": '',
    "duration": 0,
    "fromDate": new Date(),
    "leaveStatus": ''
  });

  const[id,setEmployeeId]=useState(
    {
      "userId":0
    }
  );

  var [managerId,setManagerId]=useState();
  

  var FetchManagerId=()=>
  {
    id.userId=localStorage.getItem("Employee Id");
    fetch('http://localhost:5006/api/Employee/GetUser', 
    {
      method: 'POST',
      headers: {
        accept: 'text/plain',
        'Content-Type': 'application/json',
        'Authorization': 'Bearer ' + localStorage.getItem('token')
      },
      body: JSON.stringify({ ...id, "id": {} }),
    })
      .then(async (data) => 
      {
        if (data.status == 200) {
          var myData = await data.json();
          localStorage.setItem("for",myData.managerId);
          setManagerId(myData.managerId);
          console.log("*********************************************************")
          console.log(myData.managerId)
          console.log(myData);
        }
      })
      .catch((err) => 
      {
        console.log(err.error);
      });
  }

  const apply = () => 
  {
    FetchManagerId();
    leave.emp_Id=localStorage.getItem("Employee Id");
    leave.manager_Id=localStorage.getItem("for");
    console.log(leave);
    fetch('http://localhost:5252/api/Leave/action/Add', 
    {
      method: 'POST',
      headers: {
        accept: 'text/plain',
        'Content-Type': 'application/json',
        'Authorization': 'Bearer ' + localStorage.getItem('token')
      },
      body: JSON.stringify({ ...leave, Leave: {} }),
    })
      .then(async (data) => 
      {
        if (data.status === 200) {
          var myData = await data.json();
          console.log(myData);
          alert('Leave applied successfully');
        }
      })
      .catch((err) => 
      {
        console.log(err.error);
      });
  };

  return (
    <div className="container">
      <div className="image-container">
      <div className="leave-container">
        <h2 className="text-center">Apply Leave</h2>
        <div className="form-group">
          <label htmlFor="title">Title</label>
          <select
            id="title"
            className="form-control"
            onChange={(event) => {
              setLeave({ ...leave, title: event.target.value });
            }}
          >
            <option value="Select type">Select Type</option>
            <option value="Personal Leave">Personal Leave</option>
            <option value="Medical Leave">Medical Leave</option>
          </select>
        </div>
        <div className="form-group">
          <label htmlFor="duration">Duration</label>
          <input
            type="number"
            id="duration"
            className="form-control"
            placeholder="No Of days"
            onChange={(event) => {
              setLeave({ ...leave, duration: Number(event.target.value) });
            }}
          />
        </div>
        <div className="form-group">
          <label htmlFor="fromDate">Start Date</label>
          <input
            type="datetime-local"
            id="fromDate"
            className="form-control"
            placeholder="Starting date"
            onChange={(event) => {
              setLeave({ ...leave, fromDate: event.target.value });
            }}
          />
        </div>
        <div className="text-center">
          <button type="submit" className="btn btn-dark" onClick={apply}>
            Apply
          </button>
        </div>
        </div>
      </div>
    </div>
  );
}

export default ApplyLeave;