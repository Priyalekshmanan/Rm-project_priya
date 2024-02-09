import axios from 'axios'
import React, { useEffect, useState } from 'react'
import { useNavigate } from 'react-router-dom'

export default function ClassAssign() {
    const [cid, setCid] = useState("")
    const [name, setName] = useState("")
    const [tid, setTid] = useState("")
    const navigate=useNavigate()

    // useEffect(() => {
    //     if (sessionStorage.getItem("token") != null) {
    //         console.log(sessionStorage.getItem("token"));
    //         const header = {
    //           Authorization: `Bearer ${sessionStorage.getItem("token")}`,
    //         };
    //     }
    //     else{
    //         navigate('/login')
    //     }
    // }, [])
    

    function Assign(){
        let values={
            classId: cid,
            className: name,
            teacherid: tid
        }
        axios
        .post("http://localhost:5099/api/ClassM/AssignClass",values)
        .then((response)=>{
            console.log(response.data);
            alert("Assigned  Successfully")
        })
    }

  return (
    <div>
        <h1>Assign Class</h1>
        <table>
            <tr>
                <td>
                    <input type='text' placeholder='Class Id' value={cid} onChange={(e)=>setCid(e.target.value)}/>
                </td>
                <td>
                    <input type='text' placeholder='Class Name' value={name} onChange={(e)=>setName(e.target.value)}/>
                </td>
                <td>
                    <input type='text' placeholder='Teacher Id' value={tid} onChange={(e)=>setTid(e.target.value)}/>
                </td>
            </tr>
            <tr>
                <td>
                    <button onClick={Assign}>Assign class</button>
                </td>
            </tr>
        </table>
    </div>
  )
}
