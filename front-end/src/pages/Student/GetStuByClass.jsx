import axios from 'axios'
import React, { useEffect, useState } from 'react'
// import { useNavigate } from 'react-router-dom'

export default function StuByClass() {
    
        const [sclss, setSclss] = useState("")
        const[idclass,setCls]=useState([])
        // const navigate=useNavigate()

        function Getclass(){
            axios
            .get("http://localhost:5099/api/Student/GetStudentByClass/"+sclss)
            .then((response)=>{
            console.log(response.data);
            setCls(response.data)
        })
        .catch((e)=>{
            console.log(e)
        })
           
       }
            
        
    
  return (
    <div>GetStudentByClass
    <table>
        <tr>
        <td>
            <input type='text' placeholder='Class STD' value={sclss} onChange={(e)=>setSclss(e.target.value)}/>
        </td>
        </tr>
        <tr>
            <td>
                <button onClick={Getclass}>Click</button>
            </td>
        </tr>
    </table>
    <table className='table table-stripped'>
            <thead>
                <tr>
                    <th>id</th>
                    <th>fName</th>
                    <th>lName</th>
                    <th>dob</th>
                    <th>gender</th>
                    <th>clss</th>
                   < th>section</th>

                
                </tr>
            </thead>
            <tbody>
               
               
                  {
                    idclass.map((item)=>{
                        return(
                            <tr key={item.id}>
                                <td>{item.id}</td>
                                <td>{item.fName}</td>
                                <td>{item.lName}</td>
                                <td>{item.dob}</td>
                                <td>{item.gender}</td>
                                <td>{item.clss}</td>
                                <td>{item.section}</td>

                            </tr>
                        )
                    })
                  }
            </tbody>
        </table>
    </div>
  )
  }
