import axios from 'axios'
import React, { useEffect, useState } from 'react'
import { useNavigate } from 'react-router-dom'


export default function ClassAssign() {
    const [classId, setCid] = useState("")
    const [semName, setSem] = useState("")
    const [streamName, setName] = useState("")
    const [teacherid, setTid] = useState("")
    const [error, setError] = useState("")
    const navigate=useNavigate()

    const Assign=()=>{
        setError("");
        //validation
        if(!classId ||!streamName || !semName || !teacherid){
            setError("All fields are required");
            return;
        }
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
                {/* <td>
                    <input type='text' placeholder='Semester' value={semName} onChange={(e)=>setSem(e.target.value)}/>
                </td> */}
                
                    <td>
                  <select className="form-control form-control-lg" value={semName} onChange={e => setSem( e.target.value )} >
                    <option value="">Semester</option>
                    <option value="Sem 1">Sem1</option>
                    <option value="Sem 2">Sem2 </option>
                    <option value="Sem 3">Sem3</option>
                    <option value="Sem 4">Sem4</option>
                    <option value="Sem 5">Sem5</option>
                    <option value="Sem 6">Sem6 </option>
                    <option value="Sem 7">Sem7</option>
                    <option value="Sem 8">Sem8</option>
                  </select>
                  {error.semName && <span className="error">{error.semName}</span>}
                  </td>
                
{/*                 
                <td>
                    <input type='text' placeholder='Stream Name' value={streamName} onChange={(e)=>setName(e.target.value)}/>
                </td> */}
                <td>
                
                  <select className="form-control form-control-lg" value={streamName} onChange={e => setName( e.target.value )} >
                    <option value="">Stream</option>
                    <option value="Stream 1">CSE</option>
                    <option value="Stream 2">EEE </option>
                    <option value="Stream 3">ECE</option>
                    <option value="Stream 4">MECH</option>
                    <option value="Stream 5">CIVIL</option>
                    <option value="Stream 6">IT </option>
                    <option value="Stream 7">AI</option>
                    <option value="Stream 8">BIO-TECH</option>
                  </select>
                  {error.streamName && <span className="error">{error.streamName}</span>}
               
                </td>
                <td>
                    <input type='text' placeholder='Teacher Id' value={teacherid} onChange={(e)=>setTid(e.target.value)}/>
                </td>
            </tr>
            <tr>
                <td colSpan="4">
                    {error &&<div style={{color :'red'}}>{error}</div>}
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
