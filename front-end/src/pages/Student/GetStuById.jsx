import axios from 'axios'
import React, { useEffect, useState } from 'react'
import { useNavigate } from 'react-router-dom'

export default function GetStuById() {
    
        const [sid, setSid] = useState("")
        const[dis,setDis]=useState({})
        const navigate=useNavigate()

        function GetStByID(){
            // let values={
            //     id: sid,
              
            // }
            axios
        .get("http://localhost:5099/api/Student/GetStudentById/"+sid)
        .then((response)=>{
            console.log(response.data);
            setDis(response.data)
        })
    }
  return (
    <div>GetById
    <table>
        <tr>
        <td>
            <input type='text' placeholder='Student Id' value={sid} onChange={(e)=>setSid(e.target.value)}/>
        </td>
        </tr>
        <tr>
            <td>
                <button onClick={GetStByID}>Click</button>
            </td>
        </tr>
    </table>
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
                <tr>
                        <td>{dis.id}</td>
                        <td>{dis.fName}</td>
                        <td>{dis.lName}</td>
                        <td>{dis.eMail}</td>
                        <td>{dis.number}</td>
                        <td>{dis.dob}</td>
                        <td>{dis.gender}</td>
                        <td>{dis.clss}</td>
                        <td>{dis.section}</td>

                </tr>
               
                  {/* {
                    dis.map((item)=>{
                        return(
                            <tr key={item.classId}>
                                <td>{item.classId}</td>
                                <td>{item.className}</td>
                                <td>{item.teacherid}</td>
                                <td>{item.teacher}</td>
                            </tr>
                        )
                    }) */}
                  {/* } */}
            </tbody>
        </table>
    </div>
  )
  };
