import axios from 'axios'
import React, { useEffect, useState } from 'react'
import { useNavigate } from 'react-router-dom'

export default function UpdateExam() {
    const [eid, setEid] = useState("")
    const [ename, setEname] = useState("")
    const [etime, setEtime] = useState("")
    const [cid, setCid] = useState("")
    const [edate, setEdate] = useState("")
    const [sid, setSid] = useState("")
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
    

    function Update(){
        // if (sessionStorage.getItem("token") != null) {
        //     console.log(sessionStorage.getItem("token"));
        //     const header = {
        //       Authorization: `Bearer ${sessionStorage.getItem("token")}`,
        //     };
            let values={
                examId:eid,
                examName:ename,
                examTime:etime,
                classId: cid,
                date:edate,
                subId: sid
            }
            axios
            .put("http://localhost:5099/api/Exam/UpdateXamDetails",values)
            .then((response)=>{
                console.log(response.data);
                alert("Updated Successfully")

            })
            .catch((err)=>console.log(err))
        };
        // else{
        //     navigate('/login')
        // }
        
    

  return (
    <div>
        <h1>Update Exam</h1>
        <table>
            <tr>
            <td>
                    <input type='text' placeholder='Exam Id' value={eid} onChange={(e)=>setEid(e.target.value)}/>
                </td>
                <td>
                    <input type='text' placeholder='Exam Name' value={ename} onChange={(e)=>setEname(e.target.value)}/>
                </td>
                <td>
                    <input type='text' placeholder='Exam Time' value={etime} onChange={(e)=>setEtime(e.target.value)}/>
                </td>
                <td>
                    <input type='text' placeholder='Class Id' value={cid} onChange={(e)=>setCid(e.target.value)}/>
                </td>
                <td>
                <input pattern="\d{4}-\d{2}-\d{2}" type='date' placeholder='Date' value={edate} onChange={(e)=>setEdate(e.target.value)}/>
                </td>
                <td>
                    <input type='text' placeholder='Subject Id' value={sid} onChange={(e)=>setSid(e.target.value)}/>
                </td>
            </tr>
            <tr>
                <td>
                    <button onClick={Update}>Update exam</button>
                </td>
            </tr>
        </table>
    </div>
  )

  }