import axios from 'axios'
import React, { useEffect, useState } from 'react'
// import { useNavigate } from 'react-router-dom'

export default function StuBySection() {
    
        const [ssection, setSsection] = useState("")
        const[dis,setDis]=useState([])
        // const navigate=useNavigate()

        function GetclassBySec(){
            axios
            .get("http://localhost:5099/api/Student/GetStudentBySection/"+ssection)
            .then((response)=>{
            console.log(response.data);
            setDis(response.data)
        })
           
       }
            
        
    
  return (
    <div>GetStudentBySection
    <table>
        <tr>
        <td>
            <input type='text' placeholder='Section' value={ssection} onChange={(e)=>setSsection(e.target.value)}/>
        </td>
        </tr>
        <tr>
            <td>
                <button onClick={GetclassBySec}>Click</button>
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
                   dis.map((item)=>{
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
