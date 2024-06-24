import React from 'react';
import { Link } from 'react-router-dom';

function Navbar() {
  var logOut=()=>{ localStorage.clear()};
  return (
    <div>
      <nav className="navbar navbar-expand-lg navbar-dark bg-dark">
        <a className="navbar-brand" href="#">SynergyTech</a>
        <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
          <span className="navbar-toggler-icon"></span>
        </button>
        <div className="collapse navbar-collapse" id="navbarNav">
          <ul className="navbar-nav">
            <li className="nav-item">
              <Link className="nav-link" to="/">Home</Link>
            </li>
            <li className="nav-item">
              <Link className="nav-link" to="/login">Login</Link>
            </li>
            {/* <li className="nav-item">
              <Link className="nav-link" to="/updateDetails">Update Details</Link>
            </li>  
            <li className="nav-item">
              <Link className="nav-link" to="/managerPage">Manager Page</Link>
            </li>  
            <li className="nav-item">
              <Link className="nav-link" to="/applyLeave">Apply Leave</Link>
            </li> 
            <li className="nav-item">
              <Link className="nav-link" to="/approveLeave">Approve Leave</Link>
            </li>  
            <li className="nav-item">
              <Link className="nav-link" to="/getAll">All Employee</Link>
            </li>     */}
          </ul>
        </div>
        <ul className="navbar-nav ml-auto">
          <li className="nav-item">
            <Link className="nav-link logOut" to="/" onClick={logOut}>Log Out</Link>
          </li>
        </ul>
      </nav>
    </div>
  );
}

export default Navbar;
