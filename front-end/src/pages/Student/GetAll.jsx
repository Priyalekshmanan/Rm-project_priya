import axios from 'axios'
import React, { useEffect, useState } from 'react'
import { useNavigate } from 'react-router-dom'


const GetStudent=()=> {
    
        const [stu, getStu] = useState([])
        const navigate=useNavigate();

        useEffect(() => {
            // if (sessionStorage.getItem("token") != null) {
            //     console.log(sessionStorage.getItem("token"));
            //     const header = {
            //       Authorization: `Bearer ${sessionStorage.getItem("token")}`,
            //     };

            axios
        .get("http://localhost:5099/api/Student/Get_all_Student")
        .then((response)=>{
            console.log(response.data);
            getStu(response.data);
        })
        .catch((error)=>{
            console.log(error);
        });
    
    // else{
    //     navigate('/login')
    // }
},[]);
  return (
    <div className='container'>
        <table className='table table-stripped'>
            <thead>
                <tr>
                    <th>StudentId</th>
                    <th>Firstname</th>
                    <th>Lastname</th>
                     <th>Email</th> 
                     <th>Number</th> 
                     <th>Dob</th> 
                     <th>Gender</th> 
                     <th>Std</th> 
                     <th>Section</th> 
                </tr>
            </thead>
            <tbody>
                  {
                    stu.map((item)=>{
                        return(
                            <tr key={item.id}>
                                 <td>{item.id}</td>
                                <td>{item.fname}</td>
                                <td>{item.lname}</td>
                                <td>{item.eMail}</td>
                                <td>{item.number}</td>
                                <td>{item.dob}</td>
                                <td>{item.gender}</td>
                                <td>{item.clss}</td>
                                <td>{item.section}</td>
                                </tr>  
                        )
                    })
                  }
            </tbody>
        </table>
    </div>
  )
  };
  export default GetStudent;
