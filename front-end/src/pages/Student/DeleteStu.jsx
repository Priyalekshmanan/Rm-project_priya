import axios from 'axios'
import React, { useEffect, useState } from 'react'
import { useNavigate } from 'react-router-dom'

export default function DeleteStuById() {
    
        const [sid, setSid] = useState("")
        
        const navigate=useNavigate()

    
        function DeleteStuById(){
                let id= sid
              
            
        axios
        .delete("http://localhost:5099/api/Student/DeleteStudent/"+id)
        .then((response)=>{
            console.log(response.data);
            alert(" Student Deleted Successfully")
            setSid(response.data)
        })
        }
  return (
    <div>DeletestuById
    <table>
        <tr>
        <td>
             <input type='text' placeholder='Student Id' value={sid} onChange={(e)=>setSid(e.target.value)}/>
                </td>
        </tr>
        <tr>
            <td>
                <button onClick={DeleteStuById}>Click</button>
            </td>
        </tr>
    </table>
    </div>
  )
  };
