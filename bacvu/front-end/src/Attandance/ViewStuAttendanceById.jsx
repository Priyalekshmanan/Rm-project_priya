
import React, { useEffect, useState } from 'react'
import axios from 'axios'
import { useNavigate } from 'react-router-dom';
//
// This is for student to view their attedance
//
export default function ViewStuAttendanceById() {
        const[dis,setDis]=useState([])
        let userId = sessionStorage.getItem("uid");
        const navigate=useNavigate()
        useEffect(()=>{
            if (sessionStorage.getItem("token") != null) {
                console.log(sessionStorage.getItem("token"));
                const headers = {
                  Authorization: `Bearer ${sessionStorage.getItem("token")}`,
                };
        
            axios
            .get("http://localhost:5099/api/S_Attendance/GetStudentAttandanceById/"+userId,{headers})
            .then((response)=>{
            console.log(response.data);
            setDis(response.data)
        })
        .catch((e)=>{
            console.log(e)
        })
    }
    else{
        navigate("/login")
    }
        },[])
            

  return (
    <div className="main-content position-relative max-height-vh-100 h-100 border-radius-lg">YOUR &nbsp; ATTENDANCE
    <table>
       
        {/* <tr>
            <td>
                <button onClick={DisplayAllStuById}>Click</button>
            </td>
        </tr> */}
    </table>
    <table className='table table-stripped'>
            <thead>
                <tr>                 
                    <th>studentId</th>
                    <th>classId</th>
                    <th>date</th>
                    <th>status</th>                
                </tr>
            </thead>
            <tbody>
               
                 {
                    dis.map((item)=>{
                        return(
                            <tr key={item.attendanceId}>    
                                <td>{item.studentId}</td>
                                <td>{item.classId}</td>
                                <td>{item.date}</td>
                                <td>{item.status?'Present':'Absent'}</td>
                            </tr>
                        )
                    })
                 }
            </tbody>
        </table>
    </div>
  )
}
