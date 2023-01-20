import React, { useState, useEffect } from 'react'
import Empdata, { paiginationFunction, sizeOfData } from '../../data/dataemployee'
import './main.css';
const Main = ({ editItemClick }) => {
  const [deletePress, setdeletePress] = useState(false);
  const [EmpData, setEmpData] = useState([]);
  const [prevBtnVisible, setPrevBtnVisible] = useState(true);
  const [nextBtnVisible, setNextBtnVisible] = useState(true);
  const [isFirstTime, setIsFirstTime] = useState(true);
  const [page, setPage] = useState(0);
  const pagePerData = 2;
  useEffect(() => {
    if (isFirstTime) {
      reloadDataAccordingToPaigination();
      setIsFirstTime(false)
    }
  }, [deletePress,EmpData])

  useEffect(() => {
    reloadDataAccordingToPaigination();
  }, [page]);

  const deleteEmp = (index) => {
    if (confirm('Are sure Delete ?')) {
      console.log(index);
      Empdata.splice(index, 1);
      setdeletePress(!deletePress); 
    } else {

    }

  }
  const editEmp = (e) => {
    editItemClick(e);
  }
  const prevBtnClick = () => {
    console.log(page);
    setPage(page-1);
    console.log(page);
    console.log("prev page click");

  }
  const nextBtnClick = () => {
    console.log(page);
    setPage(page + 1);
    console.log(page);
    console.log("next page click");
  }
  const reloadDataAccordingToPaigination = () => {
    console.log(page, pagePerData);
    const tempData = paiginationFunction(page, pagePerData);
    console.log(tempData);
    setEmpData(tempData);
    if (page == 0) {
      setPrevBtnVisible(false);
    } else {
      setPrevBtnVisible(true);
    }
    console.log("find length of ", (pagePerData * page), sizeOfData())
    if (pagePerData * page + pagePerData >= sizeOfData()) {
      setNextBtnVisible(false);
    } else {
      setNextBtnVisible(true);
    }
  }
  return (
    <>
      <div className='container mt-5' style={{minHeight:'65vh'}} >
        <table className='table list-table table-striped  table-hover text-center'>
          <thead className='table-dark'>
            <tr>
              <th>Firstname</th>
              <th>LastName</th>
              <th>Email</th>
              <th>Phone No</th>
              <th>Gender</th>
              <th>Deparment</th>
              <th>Skill</th>

              <th >Action</th>
            </tr>
          </thead>
          <tbody className='table-group-divider table-info'>
            {
              
              EmpData.map((Empobj, index) => {
                console.log("hello",Empdata);
                return (
                  <tr key={Empobj.id}>
                    <td>{Empobj.firstname}</td>
                    <td>{Empobj.lastname}</td>
                    <td>{Empobj.email}</td>
                    <td>{Empobj.phone}</td>
                    <td>{Empobj.gender}</td>
                    <td>{Empobj.department}</td>
                    <td>{Empobj.skills.map((data) => `${data}, `)}</td>
          
                    <td><button className='btn btn-primary bg-primary me-3' onClick={() => editEmp(Empobj)}>Edit</button>
                      <button className='btn btn-danger bg-danger' onClick={() => deleteEmp(index)}>Delete</button>
                    </td>
                  </tr>
                )
              })
            }
          </tbody>
        </table>
        <div className='btn-next-prev-div-main'>
          <div>{prevBtnVisible ? <button onClick={prevBtnClick} className='btn btn-dark'>Back</button> : <></>}</div>
          <div>{nextBtnVisible ? <button onClick={nextBtnClick} className='btn btn-dark'>Next</button> : <></>}</div>

        </div>
      </div>
    </>
  )
}

export default Main