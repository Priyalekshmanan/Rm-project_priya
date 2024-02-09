import axios from 'axios'
import React, { useEffect, useState } from 'react'
import { useNavigate } from 'react-router-dom'

export default function DeleteExamById() {
    
        const [eid, setEid] = useState("")
        
        const navigate=useNavigate()

    
        function DeleteById(){
                let examId= eid
              
            
        axios
        .delete("http://localhost:5099/api/Exam/DeleteExam/"+examId)
        .then((response)=>{
            console.log(response.data);
            alert("Deleted Successfully")
            setEid(response.data)
        })
        }
  return (
    <div>DeleteById
    <table>
        <tr>
        <td>
             <input type='text' placeholder='Exam Id' value={eid} onChange={(e)=>setEid(e.target.value)}/>
                </td>
        </tr>
        <tr>
            <td>
                <button onClick={DeleteById}>Click</button>
            </td>
        </tr>
    </table>
    </div>
  )
  };
