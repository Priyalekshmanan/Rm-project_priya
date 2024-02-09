import axios from 'axios'
import React, { useEffect, useState } from 'react'
// import { useNavigate } from 'react-router-dom'

export default function ExamById() {
    
        const [eid, setEid] = useState("")
        const[dis,setDis]=useState([])
        // const navigate=useNavigate()

        function GetDet(){
            axios
            .get("http://localhost:5099/api/Exam/GetExamById/"+eid)
            .then((response)=>{
            console.log(response.data);
            setDis(response.data)
        })
           
       }
            
        
    
  return (
    <div>GetExam
    <table>
        <tr>
        <td>
            <input type='text' placeholder='Exam Id' value={eid} onChange={(e)=>setEid(e.target.value)}/>
        </td>
        </tr>
        <tr>
            <td>
                <button onClick={GetDet}>Click</button>
            </td>
        </tr>
    </table>
    <table className='table table-stripped'>
            <thead>
                <tr>
                    <th>examId</th>
                    <th>examName</th>
                    <th>examTime</th>
                    <th>classId</th>
                    <th>date</th>
                    <th>subId</th>

                
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>{dis.examId}</td>
                    <td>{dis.examName}</td>
                    <td>{dis.examTime}</td>
                    <td>{dis.classId}</td>
                    <td>{dis.date}</td>
                    <td>{dis.subId}</td>

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
  }
