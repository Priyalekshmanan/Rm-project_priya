import axios from 'axios'
import React, { useEffect, useState } from 'react'
import { useNavigate } from 'react-router-dom'

export default function GetById() {
    
        const [cid, setCid] = useState("")
        const[dis,setDis]=useState({})
        const navigate=useNavigate()

        function GetByID(){
            let values={
                classId: cid,
              
            }
            axios
        .get("http://localhost:5099/api/ClassM/id?id=CS001",values)
        .then((response)=>{
            console.log(response.data);
            setDis(response.data)
        })
    }
  return (
    <div>GetById
    <table>
        <tr>
        <td>
            <input type='text' placeholder='Class Id' value={cid} onChange={(e)=>setCid(e.target.value)}/>
        </td>
        </tr>
        <tr>
            <td>
                <button onClick={GetByID}>Click</button>
            </td>
        </tr>
    </table>
    <table className='table table-stripped'>
            <thead>
                <tr>
                    <th>ClassId</th>
                    <th>ClassName</th>
                    <th>TeacherId</th>
                    <th>Teacher</th>

                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>{dis.classId}</td>
                    <td>{dis.className}</td>
                    <td>{dis.teacherid}</td>
                    <td>{dis.teacher}</td>

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
  };
