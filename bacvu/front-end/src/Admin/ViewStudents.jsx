import axios from 'axios';
import React, { useState } from 'react'

export default function ViewStudents() {
    const[students,setStudents]=useState([]);
    // const[id,setId]=useState({});
    

    // const GetById=(e)=>{
    //     e.preventDefault();
    //     axios.get("http://localhost:5099/api/Student/GetStudentById/"+id)
    //     .then((res)=>{
    //         console.log(res.data);
    //         setStudents(res.data);
    //     })
    //     .catch((err)=>{
    //         console.log(err);
    //     });
    // }
    
    // Fetching data from the server 
    const GetAllStudents=() =>{
      
        axios
        .get("http://localhost:5099/api/Student/Get_all_Student")
        .then((response)=>{
            console.log(response.data);
            setStudents(response.data);
        })
        .catch((error)=>{
            console.log("Error in retrieving students",error);
            alert("Error in retrieving students");
        })
        
    }
    const Delete=(index,e)=>{
        axios.delete("http://localhost:5099/api/Student/DeleteStudent/"+index)
        .then((res)=>{
            console.log(res.data);
            //e.target.deleteRow(index)
           // setuserId(res.data);
            alert("deleted successfully")
  
        })
        .catch((err)=>{
            console.log("error in fetching user",err);
            alert("error in fetching");
        })
  
    }
  return (
    <div className="main-content position-relative max-height-vh-100 h-100 border-radius-lg">
         {/* <form className="d-flex justify-content-end">
                    <div className="mb-3">
                        <input value={id}
                            onChange={(e) => setId(e.target.value)}
                            type="text"
                            placeholder="Enter ID"
                        />
                       
                    </div>
                    <button onClick={GetById} className="btn btn-success ms-2" type="submit">
                        View
                    </button>
                  
                </form>  */}
        
      <table  className="table table-striped">
        <thead>
            <tr>
                <th>StudentId</th>
                <th>Name</th>
                <th>Email</th>
                <th>Number</th>
                <th>DOB</th>
                <th>Gender</th>
                <th>SemName</th>
                <th>StreamName</th>
            </tr>
        </thead>
        <tbody>
            {students.map((item,index)=>(
                <tr key={index}>
                    <td> {item.id} </td>
                    <td> {item.fName+" "+item.lName} </td>
                    <td> {item.eMail} </td>
                    <td> {item.number} </td>
                    <td> {item.dob} </td>
                    <td> {item.gender} </td>
                    <td> {item.semName} </td>
                    <td> {item.streamName} </td>
                    <td><button onClick={(e) => Delete(item.id,e)}>Delete</button></td> 
                </tr>
            ))}
        </tbody>
      </table>
      <button onClick={GetAllStudents } type="button"className="btn btn-outline-primary">View Students</button>
    
    </div>
  )
}
