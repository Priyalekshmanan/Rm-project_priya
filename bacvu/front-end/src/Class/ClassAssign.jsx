import axios from 'axios'
import React, { useEffect, useState } from 'react'
import { useNavigate } from 'react-router-dom'


export default function ClassAssign() {
    const [classId, setCid] = useState("")
    const [semName, setSem] = useState("")
    const [streamName, setName] = useState("")
    const [teacherid, setTid] = useState("")
    const navigate=useNavigate()

    const Assign=()=>{
        if (sessionStorage.getItem("token") != null) {
            console.log(sessionStorage.getItem("token"));
            const headers = {
              Authorization: `Bearer ${sessionStorage.getItem("token")}`,
            };
        let values={
            classId: classId,
            semName:semName,
            streamName: streamName,
            teacherid: teacherid,
        }
        axios
        .post("http://localhost:5099/api/ClassM/AssignClass",values,{headers})
        .then((response)=>{
            console.log(response.data);
            alert("Assigned  Successfully")
        })
        .catch((err)=>{
            console.log("error in fetching user",err);
            alert("error in fetching");
        })
    }
        else {
            navigate("/login");
          }
       
    }

  return (
    <div className="main-content position-relative max-height-vh-100 h-100 border-radius-lg">
        <h1>Assign Class</h1>
        <table>
            <tr>
                <td>
                    <input type='text' placeholder='Class Id' value={classId} onChange={(e)=>setCid(e.target.value)}/>
                </td>
                <td>
                    <input type='text' placeholder='Semester' value={semName} onChange={(e)=>setSem(e.target.value)}/>
                </td>
                <td>
                    <input type='text' placeholder='Stream Name' value={streamName} onChange={(e)=>setName(e.target.value)}/>
                </td>
                <td>
                    <input type='text' placeholder='Teacher Id' value={teacherid} onChange={(e)=>setTid(e.target.value)}/>
                </td>
            </tr>
            <tr>
                <td>
                    <button onClick={Assign} type='button'>Assign class</button>
                </td>
            </tr>
        </table>
    </div>
  )
}
