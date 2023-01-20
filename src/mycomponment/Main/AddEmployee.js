import React, { useState, useEffect } from 'react'
import { addData, updatedata } from '../../data/dataemployee';
import './Addemployee.css';
import { useNavigation } from "react-router-dom";

function AddEmployee({ cancelEmployeClick, tempData }) {

    const [employeeadd, setEmployeeadd] = useState({
        firstname: "",
        Lastname: "",
        email: "",
        phone: "",
        gender: "",
        department: "Php",
        skills: [],
        about: ""
    })
    useEffect(() => {
        if (tempData != {}) {
            editButtonSetData();
        }
        console.log("tempData", tempData)
    }, [])
    useEffect(() => {

    }, [employeeadd])
    const editButtonSetData = () => {
        console.log("ion edit button")
        setEmployeeadd(tempData);
    }

    const changecheckbox = (e) => {

     
         const skillsarry = employeeadd;
            if (skillsarry.skills.includes(e.target.name)) {
                let index = 0;
                for (let i = 0; i < skillsarry.skills.length; i++) {
                    if (e.target.name == skillsarry.skills[i]) {
                        console.log("its matching", i);
                        index = i;
                    }
                }
                const arr = skillsarry.skills;
                arr.splice(index, 1);
                skillsarry.skills = arr;
                console.log(skillsarry)
            } else {
                skillsarry.skills.push(e.target.name);
            }
            console.log(skillsarry.skills)

            console.log(e.target.name);
            console.log(skillsarry);
            setEmployeeadd(skillsarry);
        
    }

  

    const handlelable = (e) => {

        const name = e.target.name;
        const value = e.target.value;
        console.log(value);
        console.log(name);
        setEmployeeadd({
            ...employeeadd, [name]: value
        })

    }
    //    const navigation = useNavigation();
    const dataSubmit = (e) => {
        e.preventDefault();
        addData(employeeadd);

        cancelEmployeClick()
    }
    
    const updateEmployeeDetalis = (e) => {
        console.log(tempData);

        const name = e.target.name;
        const value = e.target.value;
        setEmployeeadd({
            ...employeeadd, id: tempData.id, [name]: value
        })
        console.log(employeeadd)
        updatedata(employeeadd);
        cancelEmployeClick()
    }
    return (
        <form onSubmit={dataSubmit}>
            <div className='container mt-4 py-4 container-addemployee'>
                <div className='row'>
                    <div className='col-md-3 text-end'>
                        <label className='fromMainLabel' htmlFor="firstname">Firstname :</label>
                    </div>
                    <div className='col-md-9'>
                        <input type="text" name="firstname" id="firstname" onChange={handlelable} value={employeeadd.firstname} required />
                    </div>
                </div>
                <div className='row mt-3'>
                    <div className='col-md-3 text-end'>
                        <label className='fromMainLabel' htmlFor="Lastname">Lastname :</label>
                    </div>
                    <div className='col-md-9'>
                        <input type="text" name="lastname" id="" required onChange={handlelable} value={employeeadd.lastname} />
                    </div>
                </div>
                <div className='row mt-3'>
                    <div className='col-md-3 text-end'>
                        <label className='fromMainLabel' htmlFor="Email">Email :</label>
                    </div>
                    <div className='col-md-9'>
                        <input type="email" name="email" id="" required onChange={handlelable} value={employeeadd.email} />
                    </div>
                </div>
                <div className='row mt-3'>
                    <div className='col-md-3 text-end'>
                        <label className='fromMainLabel' htmlFor="Phone">Phone :</label>
                    </div>
                    <div className='col-md-9'>
                        <input onChange={handlelable} value={employeeadd.phone} type="tel" name="phone" id="" required />
                    </div>
                </div>
                <div className='row mt-3'>
                    <div className='col-md-3 text-end'>
                        <label className='fromMainLabel' htmlFor="gender">Gender :</label>
                    </div>
                    <div className='col-md-9 d-flex'>
                        <div className='mx-2'>
                            <input onChange={handlelable} value="Male" type="radio" name="gender" id="male" checked={employeeadd.gender == "male" ? "true" : null} />
                            <label  htmlFor="male" className='px-2'>Male</label>
                        </div>

                        <div>
                            <input onChange={handlelable} value="Female" type="radio" name="gender" id="female" checked={employeeadd.gender == "Female" ? "true" : null} />
                            <label htmlFor="Female" className='px-2'>Female</label>
                        </div>
                    </div>
                </div>
                <div className='row mt-3'>
                    <div className='col-md-3 text-end'>
                        <label  className='fromMainLabel' htmlFor="deparment">Deparment :</label>
                    </div>
                    <div className='col-md-9'>
                        <select name="deparment" id="" onChange={handlelable} value={employeeadd.department} >
                            <option value="PHP">PHP</option>
                            <option value=".Net">.Net</option>
                            <option value="SEO">SEO</option>
                            <option value="Mobile">Mobile</option>
                            <option value="Admin/HR">Admin/HR</option>
                            <option value="Account">Account</option>
                        </select>
                    </div>
                </div>
                <div className='row mt-3'>
                    <div className='col-md-3 text-end'>
                        <label  className='fromMainLabel' htmlFor="skills">skills :</label>
                    </div>
                    <div className='col-md-9'>
                        <div className='row w-75'>
                            <div className='col-4'>
                                <input onChange={changecheckbox}  type="checkbox" name="Programming" className="me-1" id="Programming" />
                                <label htmlFor="Programming">Programming</label>
                            </div>
                            <div className='col-4'>
                                <input onChange={changecheckbox}  type="checkbox" name="Communication" className="me-1" id="Communication" />
                                <label htmlFor="Communication">Communication</label>
                            </div>
                            <div className='col-4'>
                                <input onChange={changecheckbox}  type="checkbox" name="ProCommunication" className="me-1" id="ProCommunication" />
                                <label htmlFor="ProCommunication">ProCommunication</label>
                            </div>
                            <div className='col-4'>
                                <input onChange={changecheckbox}  type="checkbox" name="Finance" className="me-1" id="Finance" />
                                <label htmlFor="Finance">Finance</label>
                            </div>
                            <div className='col-4'>
                                <input onChange={changecheckbox}  type="checkbox" name="Recruitment" className="me-1" id="Recruitment" />
                                <label htmlFor="Recruitment">Recruitment</label>
                            </div>
                            <div className='col-4'>
                                <input onChange={changecheckbox}  type="checkbox" name="Optimization" className="me-1" id="Optimization" />
                                <label htmlFor="Optimization">Optimization</label>
                            </div>
                            <div className='col-4'>
                                <input onChange={changecheckbox}  type="checkbox" name="AppDevelopment" className="me-1" id="AppDevelopment" />
                                <label htmlFor="AppDevelopment">App Development</label>
                            </div>
                            <div className='col-4'>
                                <input onChange={changecheckbox}  type="checkbox" name="FrontendDevelopment" className="me-1" id="FrontendDevelopment" />
                                <label htmlFor="FrontendDevelopment">Frontend Development</label>
                            </div>
                            <div className='col-4'>
                                <input onChange={changecheckbox}  type="checkbox" name="BackendDevelopment" className="me-1" id="BackendDevelopment" />
                                <label htmlFor="BackendDevelopment">Backend Development</label>
                            </div>
                        </div>
                    </div>
                </div>
                <div className='row mt-3'>
                    <div className='col-md-3 text-end'>
                        <label className='fromMainLabel' htmlFor="about">About :</label>
                    </div>
                    <div className='col-md-9'>
                        <textarea name="about" id="about" cols="30" rows="3" onChange={handlelable} value={employeeadd.about}></textarea>
                    </div>
                </div>
                <div className='row mt-3 '>
                    <div className='col-3'></div>
                    <div className='col-9'>
                        {tempData.id > 0 ? <input type="button" value="Update" className='btn btn-warning  ' onClick={updateEmployeeDetalis} /> :
                            <input type="submit" value="Add +" className='btn btn-success' />}
                        <input type="button" value="Cancel" className='btn ms-3 btn-primary' onClick={cancelEmployeClick} />
                    </div>
                </div>
            </div>
        </form>
    )
}

export default AddEmployee