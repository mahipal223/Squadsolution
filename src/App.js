import './App.css';

import Main from './mycomponment/Main/Main';
import '../node_modules/bootstrap/dist/css/bootstrap.min.css';
import AddEmployee from './mycomponment/Main/AddEmployee';
import { useState, useEffect } from 'react';

import Footer from './mycomponment/footer/Footer';
import Header from './mycomponment/header/Header';

function App() {
  const [inMain, setInMain] = useState(true);
  const [tempData,setTempData] = useState({});
  useEffect(() => {

  }, [inMain,tempData])
  const editItemClick = (temp) => {
    console.log(temp);
    setTempData(temp);
    setInMain(false);
  }
  const addEmployeClick = () => {
    setTempData({});
    setInMain(false);
  }
  const cancelEmployeClick = () => {
    setInMain(true);
  }
  
  return (
    <div>
      <Header addEmployeClick={addEmployeClick} cancelEmployeClick={cancelEmployeClick}/>
      <div>{inMain ? <Main editItemClick={editItemClick} /> : <AddEmployee addEmployeClick={addEmployeClick} cancelEmployeClick={cancelEmployeClick} tempData={tempData}/>} </div>
      <Footer />
    </div>
  );
}

export default App;
