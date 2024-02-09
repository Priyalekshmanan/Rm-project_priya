import axios from 'axios'
import React, { useEffect, useState } from 'react'
import { useNavigate } from 'react-router-dom'

export default function DeleteById() {
    
        const [cid, setCid] = useState("")
        
        const navigate=useNavigate()

    
        function DeleteById(){
                let classId= cid
              
            
        axios
        .delete("http://localhost:5099/api/ClassM/DeleteClass?id="+classId)
        .then((response)=>{
            console.log(response.data);
            alert("Deleted Successfully")
            setCid(response.data)
        })
    }
  return (
    <div>DeleteById
    <table>
        <tr>
        <td>
                    <input type='text' placeholder='Class Id' value={cid} onChange={(e)=>setCid(e.target.value)}/>
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
