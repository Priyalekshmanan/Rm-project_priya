import axios from 'axios';
import React, { useState } from 'react'

export default function ViewStudents() {
    const[students,setStudents]=useState([]);
    const [userId, setuserId] = useState('');
    const [studentById,setstudentById]=useState({})
    const [iderrors, setIdErrors] = useState('');
   
    
    // Fetching data from the server
    
    const GetById = (e) => {
         e.preventDefault(); // Prevent default form submission behavior
   
        // // Reset errors
        setIdErrors('');
       
        // // Validation
        let isValid = true;
       // if (!iderrors) {
            if(userId.trim()===''){
            setIdErrors('Student id is required');
            isValid = false;
        }
       
         if (isValid) {
            axios
            .get("http://localhost:5099/api/Student/GetStudentById/"+userId)
        .then((res)=>{
            setstudentById(res.data);
            console.log(res.data);
           
        })
        .catch((err)=>{
            console.log(err);
        });
    }
    };
    
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
        });
        
    }
    const Delete=(index,e)=>{
        axios.delete("http://localhost:5099/api/Student/DeleteStudent/"+index)
        .then((res)=>{
            console.log(res.data);
            //e.target.deleteRow(index)
           // setuserId(res.data);
            alert("deleted successfully")
            window.location.reload();
  
        })
        .catch((err)=>{
            console.log("error in fetching user",err);
            alert("error in fetching");
        })
  
    }
  return (
    <div className="main-content position-relative max-height-vh-100 h-100 border-radius-lg">
    
         <form className="d-flex justify-content-end">
                    <div className="mb-3">
                        <input 
                            onChange={(e) => setuserId(e.target.value)}
                            type="text"
                            className={`form-control ${iderrors && 'is-invalid'}`}
                            placeholder="Enter ID"
                        />
                         {iderrors && <div className="invalid-feedback">{iderrors}</div>}
                       
                    </div>
                    <button onClick={GetById} className="btn btn-success ms-2" type="submit">
                        View
                    </button>
                  
                </form> 
        
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
        {studentById.id?(
            <tr key={studentById.id}>
                    <td> {studentById.id} </td>
                    {studentById.id?<td> {studentById.fName+" "+studentById.lName} </td>:""}
                    <td> {studentById.dob} </td>
                    <td> {studentById.gender} </td>
                    <td> {studentById.semName} </td>
                
                    <td> {studentById.eMail} </td>
                    <td> {studentById.number} </td>


                    <td> {studentById.streamName} </td>
                    {/* <td>
                    <button onClick={(e) => Delete(studentById.id)}>Delete</button>
                    </td> */}
                    <td>
                   {studentById.id?<td><button onClick={(e) => Delete(studentById.id)}>Delete</button></td>:""} 
                    </td>
            </tr>

            ):(
            students.map((item,index)=>(
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
            )))}
                   
        </tbody>
      </table>
  
      <button onClick={GetAllStudents } type="button"className="btn btn-outline-primary">View Students</button>
    
    </div>
  )
    
        }    