import React from 'react';
import { Link } from 'react-router-dom';
import './EmployeePage.css'; // Import your CSS file

function EmployeePage() {
  return (
    <div className="top-container">
      
      <h1 className="home-title">Welcome to SynergyTech!</h1>
      <div className="container">
        <ul className="function-list">
          <li>
            <Link to="/updateDetails" className="function-link">
              <div className="function-card">
                <h3>Update Details</h3>
              </div>
            </Link>
          </li>
          <li>
            <Link to="/applyLeave" className="function-link">
              <div className="function-card">
                <h3>Apply Leave</h3>
              </div>
            </Link>
          </li>
        </ul>
      </div>
      
    </div>
  );
}

export default EmployeePage;
