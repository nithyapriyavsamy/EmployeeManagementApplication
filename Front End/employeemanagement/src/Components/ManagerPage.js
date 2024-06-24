import React from 'react';
import { Link } from 'react-router-dom';
import './ManagerPage.css'; // Import your CSS file

function ManagerPage() {
  return (
    <div className="top-container">
      
      <h1 className="home-title">Welcome to SynergyTech!</h1>
      <div className="container">
        <ul className="function-list">
          <li>
            <Link to="/approveLeave" className="function-link">
              <div className="function-card function1">
                <h3>Approve Leave</h3>
              </div>
            </Link>
          </li>
          <li>
            <Link to="/updateDetails" className="function-link">
              <div className="function-card function2">
                <h3>Update Details</h3>
              </div>
            </Link>
          </li>
          <li>
            <Link to="/getAll" className="function-link">
              <div className="function-card function3">
                <h3>Employee Details</h3>
              </div>
            </Link>
          </li>
        </ul>
      </div>
      
    </div>
  );
}

export default ManagerPage;
