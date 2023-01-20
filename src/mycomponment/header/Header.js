import React from 'react'
import { Link,NavLink } from "react-router-dom";

const header = ({addEmployeClick,cancelEmployeClick}) => {
  const addEmployeClick1 = () =>{
    addEmployeClick();
  }
  const serchEmployeeClick=()=>{
    
  }
   
  return (
    <nav className="navbar navbar-expand-lg bg-dark  ">
    <div className="container-fluid px-4 py-2">
    <a className="navbar-brand" style={{color: 'white'}} href="#">Crud Opeartion</a>
      <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarScroll" aria-controls="navbarScroll" aria-expanded="false" aria-label="Toggle navigation">
        <span className="navbar-toggler-icon"></span>
      </button>
      <div className="collapse navbar-collapse" id="navbarScroll">
        <ul className="navbar-nav me-auto my-2 my-lg-0 navbar-nav-scroll">
          <li className="nav-item">
             <button className="nav-link active bg-dark border-0" onClick={cancelEmployeClick}  style={{color: 'white'}}>Home</button>
          </li>
          <li className="nav-item">
            <button className="nav-link active bg-dark border-0" onClick={addEmployeClick1}  style={{color: 'white'}}>Add Emplyoee</button>
          </li>
        </ul>
        <form className="d-flex" role="search">
          <input className="form-control me-2" type="search" placeholder="Search" aria-label="Search" />
          <button className="btn btn-success bg-success" type="submit" onClick={serchEmployeeClick} >Search</button>
        </form>
      </div>
    </div>
  </nav>
  )
}

export default header;