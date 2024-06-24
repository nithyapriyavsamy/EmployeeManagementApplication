import logo from './logo.svg';
import './App.css';
import Navbar from './Components/NavBar';
import 'bootstrap/dist/css/bootstrap.css';
import { BrowserRouter, Link, Outlet, Route, Routes } from 'react-router-dom';
import Home from './Components/Home';
import Login from './Components/Login';
import Register from './Components/Register'
import UpdateDetails from './Components/UpdateDetails'
import ManagerPage from './Components/ManagerPage';
import EmployeePage from './Components/EmployeePage';
import ApplyLeave from './Components/ApplyLeave';
import ApproveLeave from './Components/ApproveLeave';
import AllEmployees from './Components/AllEmployees';
import IndividualEmployee from './Components/IndividualEmployee';

function App() {
  return (
    <BrowserRouter>
      <div>
          <Navbar/>
          <Routes>
          <Route path='/' element={<Home/>} />
          <Route path='login' element={<Login/>} />
          <Route path='register' element={<Register/>} />
          <Route path='updateDetails'element={<UpdateDetails/>} />
          <Route path='managerPage' element={<ManagerPage/>} />
          <Route path='employeePage' element={<EmployeePage/>} />
          <Route path='applyLeave' element={<ApplyLeave/>} />
          <Route path='approveLeave' element={<ApproveLeave/>} />
          <Route path='getAll' element={<AllEmployees/>} />
          <Route path='get' element={<IndividualEmployee/>} />
          </Routes>
      </div>
    </BrowserRouter>  
  );
}

export default App;


