
import axios from 'axios'
import React, { useEffect, useState } from 'react'
import { useNavigate } from 'react-router-dom'
import AttendanceButton from '../AttendanceButton'

export default function DisplayStudentAttendaceById() {
        const [sstartdate, setSstartdate] = useState("")
        const [senddate, setSenddate] = useState("")
        const[dis,setDis]=useState({})
        const[sid,setId]= useState("")
        let userId = sessionStorage.getItem("uid");
        const navigate=useNavigate()

       function Result(){
        if (sessionStorage.getItem("token") != null) {
            console.log(sessionStorage.getItem("token"));
            const headers = {
              Authorization: `Bearer ${sessionStorage.getItem("token")}`,
            };
        console.log(sstartdate);
        console.log("end"+senddate);
            axios
            .get("http://localhost:5099/api/DisplayAttendance/SAttendance/"+userId+"/"+sstartdate+"/"+senddate,{headers})
            .then((response)=>{
                setDis(response.data)
             console.log(response.data);
        })
        .catch((e)=>{
            console.log(e)
        })
    }
    else{
        navigate("/login")
    }
    }
            
           
       
            
        
    
  return (
    <div className="main-content position-relative max-height-vh-100 h-100 border-radius-lg">
        <AttendanceButton/>
    <table>
        <tr>
        <td>
            <input type="text" className="form-control" placeholder= "Enter Student ID"  onChange={(e) => setId(e.target.value)} />
            <input type='date' placeholder='Start Date' value={sstartdate} onChange={(e)=>setSstartdate(e.target.value)}/>
            <input  type='date' placeholder='End Date' value={senddate} onChange={(e)=>setSenddate(e.target.value)}/>
            <input type="button" value="GET" onClick={Result} />
        </td>
        </tr>
        {/* <tr>
            <td>
                <button onClick={DisplayAllStuById}>Click</button>
            </td>
        </tr> */}
    </table>
    <table className='table table-stripped'>
            <thead>
                <tr>
                 
                    {/* <th>teacherId</th> */}
                    <th>presentDays</th>
                    <th>absentDays</th>
                    <th>totalWorking</th>
                  

                
                </tr>
            </thead>
            <tbody>           
                 {
                <tr key={dis.studentId}>
                    <td>{dis.presentDays}</td>
                    <td>{dis.absentDays}</td>
                    <td>{dis.totalWorking}</td>
                </tr>        
                 }
            </tbody>
        </table>
    </div>
  )
  }