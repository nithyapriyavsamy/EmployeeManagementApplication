import React, { useState } from 'react';
import './UpdateDetails.css';
function UpdateDetails() {
  const [Details, setDetails] = useState({
        "EmployeeId" : Number(localStorage.getItem("Employee Id")),
        "UpdatedLicenceNo" :"",
        "UpdatedPhoneNo" : "",
        "UpdatedPassportNo" : "",
        "UpdatedAddress" : ""
  });

  const update = () => {
    console.log(Details);
    fetch('http://localhost:5006/api/Employee/UpdateAll', {
      method: 'PUT',
      headers: {
        accept: 'text/plain',
        'Content-Type': 'application/json',
        'Authorization': 'Bearer ' + localStorage.getItem('token')
      },
      body: JSON.stringify({ ...Details, Details: {} }),
    })
      .then(async (data) => {
        if (data.status === 201) {
          var myData = await data.json();
          alert('Updated successfully');
        }
      })
      .catch((err) => {
        console.log(err.error);
      });
      alert("Updated successful");
  };

  return (
    <div className="container">
      <div className="body-container">
      <div className="update-container">
        <h2 className="text-center">Update Details</h2>
        <div className="form-group">
          <label htmlFor="title">Licence No</label>
          <input
            type="text"
            id="title"
            className="form-control"
            placeholder="Licence number"
            onChange={(event) => {
              setDetails({ ...Details, "UpdatedLicenceNo": event.target.value });
            }}
          />
        </div>
        <div className="form-group">
          <label htmlFor="duration">Phone No</label>
          <input
            type="text"
            id="duration"
            className="form-control"
            placeholder="phone number"
            onChange={(event) => {
              setDetails({ ...Details, "UpdatedPhoneNo": event.target.value });
            }}
          />
        </div>
        <div className="form-group">
          <label htmlFor="duration">Passport No</label>
          <input
            type="text"
            id="duration"
            className="form-control"
            placeholder="Passport No"
            onChange={(event) => {
              setDetails({ ...Details, "UpdatedPassportNo": event.target.value });
            }}
          />
        </div>
        <div className="form-group">
          <label htmlFor="fromDate">Address</label>
          <input
            type="text"
            id="fromDate"
            className="form-control"
            placeholder="Address"
            onChange={(event) => {
              setDetails({ ...Details, "UpdatedAddress": event.target.value });
            }}
          />
        </div>
        <div className="text-center">
          <button type="submit" className="btn btn-dark" onClick={update}>
            Update
          </button>
        </div>
      </div>
      </div>
    </div>
  );
}

export default UpdateDetails;